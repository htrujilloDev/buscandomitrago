using Microsoft.EntityFrameworkCore;

namespace BuscandoMiTrago.Models
{
    public class CoctelDBContext:DbContext
    {
        public CoctelDBContext()
        {

        }
        public CoctelDBContext(DbContextOptions<CoctelDBContext> options):base(options) 
        {

        }
        public virtual DbSet<CoctelFavorito>CoctelFavorito { get; set; }    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoctelFavorito>(entity =>
            {
                entity.ToTable("CoctelFavorito");
                entity.HasKey(e=>e.idDrink);
                entity.Property(e => e.idDrink).HasColumnName("idDrink");

                entity.Property(e => e.strDrink)
                      .HasColumnName("strDrink")
                      .HasMaxLength(50)
                      .IsUnicode(false);

                entity.Property(e => e.strDrinkThumb)
                      .HasColumnName("strDrinkThumb")
                      .HasMaxLength(255)
                      .IsUnicode(false);
            });

        }
    }

}
