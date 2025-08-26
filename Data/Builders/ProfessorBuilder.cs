using Microsoft.EntityFrameworkCore;
using CursoAPIWeb.Objects.Models;

namespace CursoAPIWeb.Data.Builders;

public class ProfessorBuilder
{
    public static void Build(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Professor>().HasKey(p => p.Id);
        modelBuilder.Entity<Professor>().Property(p => p.Nome).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<Professor>().Property(p => p.Email).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<Professor>().Property(p => p.Senha).IsRequired().HasMaxLength(256);

        modelBuilder.Entity<Professor>()
            .HasData(new List<Professor>
            {
                new (1, "José Carlos", "josecarlos@gmail.com", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92"),
                new (2, "César Júnior", "cesarjunior@gmail.com", "a10335a2644cd19e4af502cb5abe0d85c3878caff3449f8fe206b556d490d6b4")
            });
    }
}
