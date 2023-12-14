using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RealEstateAgency.Data;
using RealEstateAgency.Service.Authentication;
using RealEstateAgency.Service.Repository;

namespace RealEstateAgencyIntegrationTest;

[TestClass]
public class AuthTest
{
    private HttpClient client;
    private TestServer server;
    private UsersContext usersContext;

    [TestInitialize]
    public void TestSetUp()
    {
        var webHostBuilder = new WebHostBuilder()
            .UseStartup<Startup>() // Assuming Startup is your Startup class
            .ConfigureTestServices(services =>
            {
                // Replace the actual database with an in-memory database for testing
                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                services.AddDbContext<UsersContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryRealEstateDatabase");
                    options.UseInternalServiceProvider(serviceProvider);
                });
            });

        server = new TestServer(webHostBuilder);
        client = server.CreateClient();
        usersContext = server.Host.Services.GetRequiredService<UsersContext>();
    }


    [TestMethod]
    public async Task PostQnaWithoutLoginResultsInUnauthorizedStatusCode()
    {
        string endpoint = "/Qna/add";
        string jsonBody = JsonConvert.SerializeObject(new Qna(0, "Is it cloudy outside?", "No, it isn't."));

        var response = await SendPostRequestAsync(endpoint, jsonBody);

        Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
    }
    
    [TestMethod]
    public async Task PostLoginUsernameMatchesNameClaimInResponseJWT()
    {
        string userName = "admin";
        string password = "123456";
        var handler = new JwtSecurityTokenHandler();
        var token = await Login(userName, password);
        var jwtSecurityToken = handler.ReadJwtToken(token);
        var claims = jwtSecurityToken.Claims.ToList();
        foreach (var claim in claims)
        {
            if (claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")
            {
                Assert.AreEqual(userName, claim.Value);
            }
        }
    }
    
    [TestMethod]
    public async Task PostQnaWithAdminLoginResultsInCreatedStatusCode()
    {
        string userName = "admin";
        string password = "123456";
        var token = await Login(userName, password);
        string addEndpoint = "/Qna/add";
        string addJsonBody = JsonConvert.SerializeObject(new Qna(0, "Is it cloudy outside?", "No, it isn't."));
 
        var response = await SendPostRequestAsync(addEndpoint, addJsonBody, token);

        Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
    }
    
    [TestMethod]
    public async Task PostQnaWithUserLoginResultsInCreatedStatusCode()
    {
        string userName = "pelda";
        string password = "123456";
        var token = await Login(userName, password);
        string addEndpoint = "/Qna/add";
        string addJsonBody = JsonConvert.SerializeObject(new Qna(0, "Is it cloudy outside?", "No, it isn't."));
 
        var response = await SendPostRequestAsync(addEndpoint, addJsonBody, token);

        Assert.AreEqual(HttpStatusCode.Forbidden, response.StatusCode);
    }

    private async Task<HttpResponseMessage> SendPostRequestAsync(string endpoint, string jsonBody, string token = null)
    {
        using (HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json"))
        {
            // Add the authorization header if a token is provided
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            // Send the POST request
            HttpResponseMessage response = await client.PostAsync(endpoint, content);

            // Reset the authorization header to avoid affecting other requests
            client.DefaultRequestHeaders.Authorization = null;

            return response;
        }
    }
    
    private async Task<string> Login(string userName, string password)
    {
        string endpoint = "/Auth/login";
        string jsonBody = JsonConvert.SerializeObject(new AuthRequest(userName , password));
        var response = await SendPostRequestAsync(endpoint, jsonBody);
        response.EnsureSuccessStatusCode();
        var responseJson = await response.Content.ReadAsStringAsync();

        AuthResponse authResponse = JsonConvert.DeserializeObject<AuthResponse>(responseJson);

        return authResponse.Token;
    }

    [TestCleanup]
    public void TestCleanup()
    {
        client.Dispose();
        server.Dispose();
    }
}