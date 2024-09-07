using Microsoft.EntityFrameworkCore;
using MultiShop.Images.Entities;
using System.Collections.Generic;

namespace MultiShop.Images.Context
{
    public class ImagesContext : DbContext
    {
        public ImagesContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<ImageDrive> ImageDrives { get; set; }
    }
}
