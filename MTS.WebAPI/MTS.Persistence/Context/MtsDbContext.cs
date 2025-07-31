using Microsoft.EntityFrameworkCore;
using MTS.Domain.Entities;

namespace MTS.Persistence.Context
{
    public class MtsDbContext : DbContext
    {
        public MtsDbContext(DbContextOptions<MtsDbContext> options) : base(options)
        {
        }

        // Domain katmanındaki modelleri DbSet olarak tanımlıyoruz.
        public DbSet<Student> Students { get; set; }
        public DbSet<Advisor> Advisors { get; set; }
        public DbSet<ThesisTopic> ThesisTopics { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Connection string'i doğrudan burada belirtin
                optionsBuilder.UseSqlServer(
                    "Server=DESKTOP-I2E1T9B\\MSSQLSERVER01;Database=MezuniyetTakip;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
        // İlişkileri burada modelliyoruz
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Student-Advisor ilişkisi
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Advisor)
                .WithMany(a => a.Students)
                .HasForeignKey(s => s.AdvisorId)
                .OnDelete(DeleteBehavior.Restrict); // Cascade delete'i devre dışı bırak

            // Report ilişkileri
            modelBuilder.Entity<Report>()
                .HasOne(r => r.Student)
                .WithMany(s => s.Reports)
                .HasForeignKey(r => r.StudentId)
                .OnDelete(DeleteBehavior.Cascade); // Student üzerinden cascade delete

            modelBuilder.Entity<Report>()
                .HasOne(r => r.Advisor)
                .WithMany(a => a.Reports)
                .HasForeignKey(r => r.AdvisorId)
                .OnDelete(DeleteBehavior.Restrict); // Advisor üzerinden cascade delete'i devre dışı bırak

            // Message ilişkileri
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Student)
                .WithMany(s => s.Messages)
                .HasForeignKey(m => m.StudentId)
                .OnDelete(DeleteBehavior.Restrict); // Student üzerinden cascade delete'i kaldır

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Advisor)
                .WithMany(a => a.Messages)
                .HasForeignKey(m => m.AdvisorId)
                .OnDelete(DeleteBehavior.Restrict); // Advisor üzerinden cascade delete'i devre dışı bırak

            // Özel index'ler
            modelBuilder.Entity<Student>()
                .HasIndex(s => s.Email)
                .IsUnique(); // Email alanı için benzersiz bir index oluştur

            // Entity konfigürasyonları
            modelBuilder.Entity<Student>()
                .Property(s => s.Name)
                .HasMaxLength(100) // Name alanı için maksimum uzunluk
                .IsRequired(); // Name alanı zorunlu

            modelBuilder.Entity<Advisor>()
                .Property(a => a.Name)
                .HasMaxLength(100) // Name alanı için maksimum uzunluk
                .IsRequired(); // Name alanı zorunlu
        }
    }
}