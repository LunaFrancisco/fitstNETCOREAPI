﻿using Microsoft.EntityFrameworkCore;

namespace firstAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        public DbSet<Productos> Productos { get; set; }
    }
}
