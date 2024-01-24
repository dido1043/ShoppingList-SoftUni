﻿using Microsoft.EntityFrameworkCore;

namespace ShoppingListApp.Data
{
    public class ShoppingListDbContext : DbContext
    {
        public ShoppingListDbContext(DbContextOptions options) 
            : base(options)
        {
        }

    }
}
