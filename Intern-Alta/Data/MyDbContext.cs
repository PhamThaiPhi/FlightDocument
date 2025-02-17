﻿using Microsoft.EntityFrameworkCore;
using System;

namespace Intern_Alta.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Flight> Flights { get; set; } 
        public DbSet<Document> Documents { get; set; } 
        public DbSet<DocumentType> DocumentTypes { get; set; } 
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<ConfigDB> Configurations { get; set; }
    }
}