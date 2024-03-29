﻿using crm_back_test.Models;
using Microsoft.EntityFrameworkCore;

namespace crm_back_test.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Note> Notes { get; set; }
    }
}
