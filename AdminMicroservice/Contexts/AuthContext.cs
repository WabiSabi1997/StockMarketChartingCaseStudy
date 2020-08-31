using Microsoft.EntityFrameworkCore;
using StockMarketCharting.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace AuthMicroservice.Contexts
{
    public class AuthContext : DbContext
    {
        public AuthContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected AuthContext()
        {
        }
        public virtual DbSet<UserEntity> Users { get; set; }
    }
}
