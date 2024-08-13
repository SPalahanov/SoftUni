using CinemaApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace CinemaApp.Infrastructure.Data.Configuration
{
    internal class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            string path = Path.Combine("bin", "Debug", "net6.0", "Data", "Datasets", "schedules.json");
            string data = File.ReadAllText(path);
            var schedules = JsonSerializer.Deserialize<List<Schedule>>(data);

            if (schedules != null)
            {
                builder
                .HasData(schedules);
            }
        }
    }
}
