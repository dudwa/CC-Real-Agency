﻿namespace RealEstateAgency.Service.Authentication;

public interface IAuthService
{
    Task<AuthResult> RegisterAsync(string email, string username, string password, string phonenumber, string firstname, string lastname);
    Task<AuthResult> LoginAsync(string username, string password);
}