﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstateAgency.Service.Authentication.IdentityExtension;

public class UsersContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
{
    public UsersContext(DbContextOptions<UsersContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // It would be a good idea to move the connection string to user secrets
        options.UseSqlServer(
            "Server=localhost,1433;Database=RealEstateAgency;User Id=sa;Password=!DbPassword12345;TrustServerCertificate=true;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}