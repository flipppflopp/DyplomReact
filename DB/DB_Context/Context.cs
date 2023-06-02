using DB.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DB.DB_Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<VolonteerInfo> VolonteerInfos { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var categories = new List<Category>
            {
                new Category { ID = 1, Name = "Category 1" },
                new Category { ID = 2, Name = "Category 2" },
                new Category { ID = 3, Name = "Category 3" },
                new Category { ID = 4, Name = "Category 4" },
                new Category { ID = 5, Name = "Category 5" },
                new Category { ID = 6, Name = "Category 6" },
                new Category { ID = 7, Name = "Category 7" },
                new Category { ID = 8, Name = "Category 8" },
                new Category { ID = 9, Name = "Category 9" },
                new Category { ID = 10, Name = "Category 10" },
                new Category { ID = 11, Name = "Category 11" },
                new Category { ID = 12, Name = "Category 12" }
            };

            modelBuilder.Entity<Category>().HasData(categories);



            var advertisements = new List<Advertisement>
            {
                new Advertisement { ID = 1, 
                                    Category = "Category 1", 
                                    Header = "Header 1", 
                                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas ac nunc at nisl hendrerit ornare eu eu tortor. Mauris et consequat massa. Donec laoreet ante quis interdum tristique. Nam a elit ut enim pharetra pharetra eget vel ex. Phasellus nec viverra lorem. Duis auctor ipsum tortor, ultricies pulvinar justo gravida ac. Sed pellentesque elit nec neque vehicula sodales. Sed congue non ligula pharetra egestas. Nam vel finibus ante. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.",
                                    CollectedSum = 10,
                                    GoalSum = 100,
                                    VolonteerInfoID = 0},
                new Advertisement { ID = 2,
                                    Category = "Category 1",
                                    Header = "Header 2",
                                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas ac nunc at nisl hendrerit ornare eu eu tortor. Mauris et consequat massa. Donec laoreet ante quis interdum tristique. Nam a elit ut enim pharetra pharetra eget vel ex. Phasellus nec viverra lorem. Duis auctor ipsum tortor, ultricies pulvinar justo gravida ac. Sed pellentesque elit nec neque vehicula sodales. Sed congue non ligula pharetra egestas. Nam vel finibus ante. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.",
                                    VolonteerInfoID = 0,
                                    CollectedSum = 20,
                                    GoalSum = 100,},
                new Advertisement { ID = 3,
                                    Category = "Category 1",
                                    Header = "Header 3",
                                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas ac nunc at nisl hendrerit ornare eu eu tortor. Mauris et consequat massa. Donec laoreet ante quis interdum tristique. Nam a elit ut enim pharetra pharetra eget vel ex. Phasellus nec viverra lorem. Duis auctor ipsum tortor, ultricies pulvinar justo gravida ac. Sed pellentesque elit nec neque vehicula sodales. Sed congue non ligula pharetra egestas. Nam vel finibus ante. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.",
                                    VolonteerInfoID = 0,
                                    CollectedSum = 30,
                                    GoalSum = 100,},
                new Advertisement { ID = 4,
                                    Category = "Category 1",
                                    Header = "Header 4",
                                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas ac nunc at nisl hendrerit ornare eu eu tortor. Mauris et consequat massa. Donec laoreet ante quis interdum tristique. Nam a elit ut enim pharetra pharetra eget vel ex. Phasellus nec viverra lorem. Duis auctor ipsum tortor, ultricies pulvinar justo gravida ac. Sed pellentesque elit nec neque vehicula sodales. Sed congue non ligula pharetra egestas. Nam vel finibus ante. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.",
                                    VolonteerInfoID = 0,
                                    CollectedSum = 40,
                                    GoalSum = 100,},
                new Advertisement { ID = 5,
                                    Category = "Category 2",
                                    Header = "Header 5",
                                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas ac nunc at nisl hendrerit ornare eu eu tortor. Mauris et consequat massa. Donec laoreet ante quis interdum tristique. Nam a elit ut enim pharetra pharetra eget vel ex. Phasellus nec viverra lorem. Duis auctor ipsum tortor, ultricies pulvinar justo gravida ac. Sed pellentesque elit nec neque vehicula sodales. Sed congue non ligula pharetra egestas. Nam vel finibus ante. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.",
                                    VolonteerInfoID = 0,
                                    CollectedSum = 50,
                                    GoalSum = 100,},
                new Advertisement { ID = 6,
                                    Category = "Category 2",
                                    Header = "Header 6",
                                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas ac nunc at nisl hendrerit ornare eu eu tortor. Mauris et consequat massa. Donec laoreet ante quis interdum tristique. Nam a elit ut enim pharetra pharetra eget vel ex. Phasellus nec viverra lorem. Duis auctor ipsum tortor, ultricies pulvinar justo gravida ac. Sed pellentesque elit nec neque vehicula sodales. Sed congue non ligula pharetra egestas. Nam vel finibus ante. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.",
                                    VolonteerInfoID = 0,
                                    CollectedSum = 60,
                                    GoalSum = 100,},
                new Advertisement { ID = 7,
                                    Category = "Category 2",
                                    Header = "Header 7",
                                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas ac nunc at nisl hendrerit ornare eu eu tortor. Mauris et consequat massa. Donec laoreet ante quis interdum tristique. Nam a elit ut enim pharetra pharetra eget vel ex. Phasellus nec viverra lorem. Duis auctor ipsum tortor, ultricies pulvinar justo gravida ac. Sed pellentesque elit nec neque vehicula sodales. Sed congue non ligula pharetra egestas. Nam vel finibus ante. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.",
                                    VolonteerInfoID = 0,
                                    CollectedSum = 70,
                                    GoalSum = 100,},
                new Advertisement { ID = 8,
                                    Category = "Category 2",
                                    Header = "Header 8",
                                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas ac nunc at nisl hendrerit ornare eu eu tortor. Mauris et consequat massa. Donec laoreet ante quis interdum tristique. Nam a elit ut enim pharetra pharetra eget vel ex. Phasellus nec viverra lorem. Duis auctor ipsum tortor, ultricies pulvinar justo gravida ac. Sed pellentesque elit nec neque vehicula sodales. Sed congue non ligula pharetra egestas. Nam vel finibus ante. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.",
                                    VolonteerInfoID = 0,
                                    CollectedSum = 80,
                                    GoalSum = 100,},
                new Advertisement { ID = 9,
                                    Category = "Category 3",
                                    Header = "Header 9",
                                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas ac nunc at nisl hendrerit ornare eu eu tortor. Mauris et consequat massa. Donec laoreet ante quis interdum tristique. Nam a elit ut enim pharetra pharetra eget vel ex. Phasellus nec viverra lorem. Duis auctor ipsum tortor, ultricies pulvinar justo gravida ac. Sed pellentesque elit nec neque vehicula sodales. Sed congue non ligula pharetra egestas. Nam vel finibus ante. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.",
                                    VolonteerInfoID = 0,
                                    CollectedSum = 90,
                                    GoalSum = 100,},
                new Advertisement { ID = 10,
                                    Category = "Category 3",
                                    Header = "Header 10",
                                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas ac nunc at nisl hendrerit ornare eu eu tortor. Mauris et consequat massa. Donec laoreet ante quis interdum tristique. Nam a elit ut enim pharetra pharetra eget vel ex. Phasellus nec viverra lorem. Duis auctor ipsum tortor, ultricies pulvinar justo gravida ac. Sed pellentesque elit nec neque vehicula sodales. Sed congue non ligula pharetra egestas. Nam vel finibus ante. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.",
                                    VolonteerInfoID = 0,
                                    CollectedSum = 100,
                                    GoalSum = 100,},
                new Advertisement { ID = 11,
                                    Category = "Category 3",
                                    Header = "Header 11",
                                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas ac nunc at nisl hendrerit ornare eu eu tortor. Mauris et consequat massa. Donec laoreet ante quis interdum tristique. Nam a elit ut enim pharetra pharetra eget vel ex. Phasellus nec viverra lorem. Duis auctor ipsum tortor, ultricies pulvinar justo gravida ac. Sed pellentesque elit nec neque vehicula sodales. Sed congue non ligula pharetra egestas. Nam vel finibus ante. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.",
                                    VolonteerInfoID = 0,
                                    CollectedSum = 12,
                                    GoalSum = 100},
                new Advertisement { ID = 12,
                                    Category = "Category 3",
                                    Header = "Header 12",
                                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas ac nunc at nisl hendrerit ornare eu eu tortor. Mauris et consequat massa. Donec laoreet ante quis interdum tristique. Nam a elit ut enim pharetra pharetra eget vel ex. Phasellus nec viverra lorem. Duis auctor ipsum tortor, ultricies pulvinar justo gravida ac. Sed pellentesque elit nec neque vehicula sodales. Sed congue non ligula pharetra egestas. Nam vel finibus ante. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.",
                                    VolonteerInfoID = 0,
                                    CollectedSum = 85,
                                    GoalSum = 100}
            };

            modelBuilder.Entity<Advertisement>().HasData(advertisements);


        }
    }
}
