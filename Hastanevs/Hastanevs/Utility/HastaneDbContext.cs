﻿using Hastanevs.Models;
using Microsoft.EntityFrameworkCore;

namespace Hastanevs.Utility
{   
    //DbContext sınıfından nesnemizi oluşturuyoruz.Bu nesne entitiy'lerimiz ve veritabanı arasında köprü işlevi görecek. 
    public class HastaneDbContext : DbContext
    {
        public HastaneDbContext(DbContextOptions<HastaneDbContext> options) : base(options) { }

        //entity frameworkde bolum adlı sınıfa tekabul eden veritabanındaki tablomuzun ismi bolumler olacak şekilde ayarlıyoruz.
        public DbSet<Bolum> Bolumler { get; set; }
    }
}
