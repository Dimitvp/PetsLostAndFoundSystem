using Microsoft.EntityFrameworkCore.Internal;
using PetsLostAndFoundSystem.Data.Enums;
using PetsLostAndFoundSystem.Reporters.Data.Models;
using PetsLostAndFoundSystem.Services;
using System;
using System.Collections.Generic;

namespace PetsLostAndFoundSystem.Reporters.Data
{
    public class ReportersDataSeeder : IDataSeeder
    {
        private static IEnumerable<Report> GetData()
            => new List<Report>
        {
            new Report {Title = "Pleace Help", Content = "We lost him ;(", Status = PetStatusType.Lost,  LostDate = new DateTime(2020, 03, 03), ImagesLinksPost = "https://pbs.twimg.com/profile_images/954554651449294849/lbjsiaCq_400x400.jpg", RewardSum = 100.00, LocationId = 1},
            new Report {Title = "Pleace Help", Content = "We lost him ;(", Status = PetStatusType.Lost, LostDate = new DateTime(2020, 03, 03), ImagesLinksPost = "https://i.pinimg.com/originals/8a/e8/52/8ae8527d64d3ccef869fe86fca32bcdc.jpg", RewardSum = 100.00, LocationId = 1 },
            new Report {Title = "Pleace Help", Content = "We lost him ;(", Status = PetStatusType.Lost, LostDate = new DateTime(2020, 03, 03), ImagesLinksPost = "https://www.rover.com/blog/wp-content/uploads/2017/02/mynameis2-960x540.jpg", RewardSum = 100.00, LocationId = 1 },
            new Report {Title = "Pleace Help", Content = "We Found this cutty ;(", Status = PetStatusType.Found, ImagesLinksPost = "https://cdn.pixabay.com/photo/2018/08/30/08/26/cute-3641563_960_720.jpg", LocationId = 1},
            new Report {Title = "Pleace Help", Content = "We Found this cutty ;(", Status = PetStatusType.Found, ImagesLinksPost = "https://pbs.twimg.com/profile_images/954554651449294849/lbjsiaCq_400x400.jpg", LocationId = 1 },
            new Report {Title = "Pleace Help", Content = "We Found this cutty ;(", Status = PetStatusType.Found, ImagesLinksPost = "https://pbs.twimg.com/profile_images/954554651449294849/lbjsiaCq_400x400.jpg", LocationId = 1}
        };

        private readonly ReportersDbContext db;

        public ReportersDataSeeder(ReportersDbContext db) => this.db = db;
        
        public void SeedData()
        {
            if (this.db.Reports.Any())
            {
                return;
            }

            foreach (var report in GetData())
            {
                this.db.Reports.Add(report);
            }

            this.db.SaveChanges();
        }
    }
}
