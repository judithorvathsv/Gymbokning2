using Gymbokning.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Gymbokning.Models.ViewModels;

namespace Gymbokning.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<GymClass> GymClass { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<ApplicationUserGymClass> ApplicationUserGymClass { get; set; }

        public DbSet<BookedGymClassViewModel> BookedGymClassViewModel { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUserGymClass>().HasKey(t => new
            {
                t.ApplicationUserId,
                t.GymClassId
            }
                );

            //builder.Entity<GymClass>().HasQueryFilter(s => s.StartTime >= DateTime.Now);

            var gymclasses = builder.Entity<GymClass>().HasData(
     new GymClass
     {
         Id=1,
         Name = "Aerobics",
         StartTime = DateTime.Now.AddDays(-21),
         Duration = new TimeSpan(1, 30, 00),
         Description = "Aerobics is a form of physical exercise that combines rhythmic aerobic exercise with " +
     "stretching and strength training routines with the goal of improving all elements of fitness (flexibility, muscular strength, and cardio-vascular fitness)."
     },

     new GymClass
     {
         Id = 2,
         Name = "Pilates",
         StartTime = DateTime.Now.AddDays(-19),
         Duration = new TimeSpan(1, 30, 00),
         Description = "Pilates improves flexibility, builds strength and develops control and endurance in the entire body. " +
     "It puts emphasis on alignment, breathing, developing a strong core, and improving coordination and balance."
     },

     new GymClass
     {
         Id = 3,
         Name = "Kickboxing",
         StartTime = DateTime.Now.AddDays(-19),
         Duration = new TimeSpan(1, 00, 00),
         Description = "Kickboxing is a group of stand-up combat sports based on kicking and punching, " +
     "historically developed from karate mixed with boxing. Kickboxing is practiced for self-defence, general fitness, or as a contact sport."
     },

     new GymClass
     {
         Id = 4,
         Name = "HIIT",
         StartTime = DateTime.Now.AddDays(-18),
         Duration = new TimeSpan(00, 30, 00),
         Description = "High-intensity interval training (HIIT) is a form of interval training, a cardiovascular exercise strategy alternating short periods of intense anaerobic exercise " +
     "with less intense recovery periods, until too exhausted to continue. " +
     "The method is not just restricted to cardio and frequently includes weights for the short periods as well."
     },

     new GymClass
     {
         Id = 5,
         Name = "Yoga",
         StartTime = DateTime.Now.AddDays(-17),
         Duration = new TimeSpan(1, 00, 00),
         Description = "Yoga is a mind-body practice that combines physical poses, controlled breathing, and meditation or relaxation. " +
     "Yoga may help reduce stress, lower blood pressure and lower your heart rate. And almost anyone can do it."
     },

     new GymClass
     {
         Id = 6,
         Name = "Zumba",
         StartTime = DateTime.Now.AddDays(-16),
         Duration = new TimeSpan(1, 30, 00),
         Description = "Zumba is an interval workout. The classes move between high- and low-intensity dance moves designed to get your heart rate up " +
     "and boost cardio endurance."
     },

     new GymClass
     {
         Id = 7,
         Name = "Circuit",
         StartTime = DateTime.Now.AddDays(-15),
         Duration = new TimeSpan(0, 45, 00),
         Description = "Boredom and time constraints are frequently cited reasons for giving up on a fitness routine. Sound familiar? " +
     "Circuit training offers a practical solution for both. " +
     "It’s a creative and flexible way to keep exercise interesting and saves time while boosting cardiovascular and muscular fitness. "
     },

     new GymClass
     {
         Id = 8,
         Name = "Skyrobics",
         StartTime = DateTime.Now.AddDays(-15),
         Duration = new TimeSpan(0, 45, 00),
         Description = "Burn up to 1,000 calories while having a blast. Feel that oh-so-rewarding burn in your legs, arms, " +
     "and core over an hour of fitness disguised as fun. " +
     "It’s one of the most dynamic, effective, and enjoyable workouts you'll ever have."
     },



     new GymClass
     {
         Id = 9,
         Name = "Aerobics",
         StartTime = DateTime.Now.AddDays(-14),
         Duration = new TimeSpan(1, 30, 00),
         Description = "Aerobics is a form of physical exercise that combines rhythmic aerobic exercise with " +
     "stretching and strength training routines with the goal of improving all elements of fitness (flexibility, muscular strength, and cardio-vascular fitness)."
     },

     new GymClass
     {
         Id = 10,
         Name = "Pilates",
         StartTime = DateTime.Now.AddDays(-13),
         Duration = new TimeSpan(1, 30, 00),
         Description = "Pilates improves flexibility, builds strength and develops control and endurance in the entire body. " +
     "It puts emphasis on alignment, breathing, developing a strong core, and improving coordination and balance."
     },

     new GymClass
     {
         Id = 11,
         Name = "Kickboxing",
         StartTime = DateTime.Now.AddDays(-12),
         Duration = new TimeSpan(1, 00, 00),
         Description = "Kickboxing is a group of stand-up combat sports based on kicking and punching, " +
     "historically developed from karate mixed with boxing. Kickboxing is practiced for self-defence, general fitness, or as a contact sport."
     },

     new GymClass
     {
         Id = 12,
         Name = "HIIT",
         StartTime = DateTime.Now.AddDays(-11),
         Duration = new TimeSpan(00, 30, 00),
         Description = "High-intensity interval training (HIIT) is a form of interval training, a cardiovascular exercise strategy alternating short periods of intense anaerobic exercise " +
     "with less intense recovery periods, until too exhausted to continue. " +
     "The method is not just restricted to cardio and frequently includes weights for the short periods as well."
     },

     new GymClass
     {
         Id = 13,
         Name = "Yoga", StartTime = DateTime.Now.AddDays(-10), Duration = new TimeSpan(1, 00, 00), Description = "Yoga is a mind-body practice that combines physical poses, controlled breathing, and meditation or relaxation. Yoga may help reduce stress, lower blood pressure and lower your heart rate. And almost anyone can do it." },

     new GymClass {
         Id = 14,
         Name = "Zumba", StartTime = DateTime.Now.AddDays(-16), Duration = new TimeSpan(1, 30, 00), Description = "Zumba is an interval workout. The classes move between high- and low-intensity dance moves designed to get your heart rate up and boost cardio endurance." },

     new GymClass
     {
         Id = 15,
         Name = "Circuit",
         StartTime = DateTime.Now.AddDays(-9),
         Duration = new TimeSpan(0, 45, 00),
         Description = "Boredom and time constraints are frequently cited reasons for giving up on a fitness routine. Sound familiar? Circuit training offers a practical solution for both. " +
     "It’s a creative and flexible way to keep exercise interesting and saves time while boosting cardiovascular and muscular fitness. "
     },

     new GymClass
     {
         Id = 16,
         Name = "Skyrobics",
         StartTime = DateTime.Now.AddDays(-8),
         Duration = new TimeSpan(0, 45, 00),
         Description = "Burn up to 1,000 calories while having a blast. Feel that oh-so-rewarding burn in your legs, arms, and core over an hour of fitness disguised as fun. " +
     "It’s one of the most dynamic, effective, and enjoyable workouts you'll ever have."
     },

      new GymClass
      {
          Id = 17,
          Name = "Aerobics",
          StartTime = DateTime.Now.AddDays(-1),
          Duration = new TimeSpan(1, 30, 00),
          Description = "Aerobics is a form of physical exercise that combines rhythmic aerobic exercise with " +
     "stretching and strength training routines with the goal of improving all elements of fitness (flexibility, muscular strength, and cardio-vascular fitness)."
      },

     new GymClass
     {
         Id = 18,
         Name = "Pilates",
         StartTime = DateTime.Now.AddDays(+1),
         Duration = new TimeSpan(1, 30, 00),
         Description = "Pilates improves flexibility, builds strength and develops control and endurance in the entire body. " +
     "It puts emphasis on alignment, breathing, developing a strong core, and improving coordination and balance."
     },

     new GymClass
     {
         Id = 19,
         Name = "Kickboxing",
         StartTime = DateTime.Now.AddDays(+2),
         Duration = new TimeSpan(1, 00, 00),
         Description = "Kickboxing is a group of stand-up combat sports based on kicking and punching, " +
     "historically developed from karate mixed with boxing. Kickboxing is practiced for self-defence, general fitness, or as a contact sport."
     },

     new GymClass
     {
         Id = 20,
         Name = "HIIT",
         StartTime = DateTime.Now.AddDays(+3),
         Duration = new TimeSpan(00, 30, 00),
         Description = "High-intensity interval training (HIIT) is a form of interval training, a cardiovascular exercise strategy alternating short periods of intense anaerobic exercise " +
     "with less intense recovery periods, until too exhausted to continue. " +
     "The method is not just restricted to cardio and frequently includes weights for the short periods as well."
     },

     new GymClass
     {
         Id = 21,
         Name = "Yoga", StartTime = DateTime.Now.AddDays(-10), Duration = new TimeSpan(1, 00, 00), Description = "Yoga is a mind-body practice that combines physical poses, controlled breathing, and meditation or relaxation. Yoga may help reduce stress, lower blood pressure and lower your heart rate. And almost anyone can do it." },

     new GymClass {
         Id = 22,
         Name = "Zumba", StartTime = DateTime.Now.AddDays(-16), Duration = new TimeSpan(1, 30, 00), Description = "Zumba is an interval workout. The classes move between high- and low-intensity dance moves designed to get your heart rate up and boost cardio endurance." },

     new GymClass
     {
         Id = 23,
         Name = "Circuit",
         StartTime = DateTime.Now.AddDays(+4),
         Duration = new TimeSpan(0, 45, 00),
         Description = "Boredom and time constraints are frequently cited reasons for giving up on a fitness routine. Sound familiar? Circuit training offers a practical solution for both. " +
     "It’s a creative and flexible way to keep exercise interesting and saves time while boosting cardiovascular and muscular fitness. "
     },

     new GymClass
     {
         Id = 24,
         Name = "Skyrobics",
         StartTime = DateTime.Now.AddDays(+5),
         Duration = new TimeSpan(0, 45, 00),
         Description = "Burn up to 1,000 calories while having a blast. Feel that oh-so-rewarding burn in your legs, arms, and core over an hour of fitness disguised as fun. " +
     "It’s one of the most dynamic, effective, and enjoyable workouts you'll ever have."
     },

      new GymClass
      {
          Id = 25,
          Name = "Aerobics",
          StartTime = DateTime.Now.AddDays(+6),
          Duration = new TimeSpan(1, 30, 00),
          Description = "Aerobics is a form of physical exercise that combines rhythmic aerobic exercise with " +
     "stretching and strength training routines with the goal of improving all elements of fitness (flexibility, muscular strength, and cardio-vascular fitness)."
      },

     new GymClass
     {
         Id = 26,
         Name = "Pilates",
         StartTime = DateTime.Now.AddDays(+7),
         Duration = new TimeSpan(1, 30, 00),
         Description = "Pilates improves flexibility, builds strength and develops control and endurance in the entire body. " +
     "It puts emphasis on alignment, breathing, developing a strong core, and improving coordination and balance."
     },

     new GymClass
     {
         Id = 27,
         Name = "Kickboxing",
         StartTime = DateTime.Now.AddDays(+8),
         Duration = new TimeSpan(1, 00, 00),
         Description = "Kickboxing is a group of stand-up combat sports based on kicking and punching, " +
     "historically developed from karate mixed with boxing. Kickboxing is practiced for self-defence, general fitness, or as a contact sport."
     },

     new GymClass
     {
         Id = 28,
         Name = "HIIT",
         StartTime = DateTime.Now.AddDays(+9),
         Duration = new TimeSpan(00, 30, 00),
         Description = "High-intensity interval training (HIIT) is a form of interval training, a cardiovascular exercise strategy alternating short periods of intense anaerobic exercise " +
     "with less intense recovery periods, until too exhausted to continue. " +
     "The method is not just restricted to cardio and frequently includes weights for the short periods as well."
     },

     new GymClass
     {
         Id = 29,
         Name = "Yoga", StartTime = DateTime.Now.AddDays(-10), Duration = new TimeSpan(1, 00, 00), Description = "Yoga is a mind-body practice that combines physical poses, controlled breathing, and meditation or relaxation. Yoga may help reduce stress, lower blood pressure and lower your heart rate. And almost anyone can do it." },

     new GymClass {
         Id = 30,
         Name = "Zumba", StartTime = DateTime.Now.AddDays(-16), Duration = new TimeSpan(1, 30, 00), Description = "Zumba is an interval workout. The classes move between high- and low-intensity dance moves designed to get your heart rate up and boost cardio endurance." },

     new GymClass
     {
         Id = 31,
         Name = "Circuit",
         StartTime = DateTime.Now.AddDays(+10),
         Duration = new TimeSpan(0, 45, 00),
         Description = "Boredom and time constraints are frequently cited reasons for giving up on a fitness routine. Sound familiar? Circuit training offers a practical solution for both. " +
     "It’s a creative and flexible way to keep exercise interesting and saves time while boosting cardiovascular and muscular fitness. "
     },

     new GymClass
     {
         Id = 32,
         Name = "Skyrobics",
         StartTime = DateTime.Now.AddDays(+11),
         Duration = new TimeSpan(0, 45, 00),
         Description = "Burn up to 1,000 calories while having a blast. Feel that oh-so-rewarding burn in your legs, arms, and core over an hour of fitness disguised as fun. " +
     "It’s one of the most dynamic, effective, and enjoyable workouts you'll ever have."
     });


        }
    }
}
