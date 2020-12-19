using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Value> Values { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subjects> Subjectss { get; set; }
        public DbSet<DailySchedule> DailySchedules { get; set; }
        public DbSet<Attendence> Attendences { get; set; }
    }
}
