using MTS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using MTS.Persistence.Context;

namespace MTS.Persistence.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(MtsDbContext context)
        {
            // 1. Veritabanının oluştuğundan emin ol
            await context.Database.EnsureCreatedAsync();

            // 2. Advisor tablosunu kontrol et
            if (!await context.Advisors.AnyAsync())
            {
                var advisors = new List<Advisor>
                {
                    new Advisor {
                        Name = "Prof. Dr. Ahmet Albayrak",
                        Email = "ahmetalbayrak@duzce.edu.tr",
                        Department = "Bilgisayar Mühendisliği"
                    },
                    new Advisor {
                        Name = "Doç. Dr. Ayşe Kaya",
                        Email = "ayse.kaya@uni.edu",
                        Department = "Elektrik-Elektronik Mühendisliği"
                    }
                };
                await context.Advisors.AddRangeAsync(advisors);
            }

            // 3. Student tablosunu kontrol et
            if (!await context.Students.AnyAsync())
            {
                var firstAdvisor = await context.Advisors.FirstAsync();

                var students = new List<Student>
                {
                    new Student {
                        StudentNumber = "211001019",
                        Name = "Mehmet Demir",
                        Password = "123456", // Test amaçlı plain text
                        AdvisorId = firstAdvisor.Id
                    },
                    new Student {
                        StudentNumber = "2305407041",
                        Name = "Hatice Acar",
                        Password = "654321",
                        AdvisorId = firstAdvisor.Id
                    }
                };
                await context.Students.AddRangeAsync(students);
            }

            // 4. Değişiklikleri kaydet
            await context.SaveChangesAsync();
        }
    }
}