using FloodGuardian.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodGuardian.Infrastructure.Data;

public class FloodGuardianContext : DbContext
{
    public FloodGuardianContext(DbContextOptions<FloodGuardianContext> options) : base(options)
    { }

    public DbSet<User> User { get; set; }
    public DbSet<SensorData> Sensor { get; set; }
    public DbSet<Alerta> Alertas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {  
        modelBuilder.Entity<Alerta>()
            .HasOne(a => a.SensorData)
            .WithMany()
            .HasForeignKey(a => a.SensorDataId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}
