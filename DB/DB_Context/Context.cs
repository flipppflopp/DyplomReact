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
        public DbSet<Photo> Photoes { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        
        public DbSet<Admin> Admins { get; set; }


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
                new Category { ID = 3, Name = "Category 3" }
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
                                    VolonteerInfoID = 1},
                new Advertisement { ID = 2,
                                    Category = "Category 1",
                                    Header = "Header 2",
                                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas ac nunc at nisl hendrerit ornare eu eu tortor. Mauris et consequat massa. Donec laoreet ante quis interdum tristique. Nam a elit ut enim pharetra pharetra eget vel ex. Phasellus nec viverra lorem. Duis auctor ipsum tortor, ultricies pulvinar justo gravida ac. Sed pellentesque elit nec neque vehicula sodales. Sed congue non ligula pharetra egestas. Nam vel finibus ante. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.",
                                    VolonteerInfoID = 2,
                                    CollectedSum = 20,
                                    GoalSum = 100,},
                new Advertisement { ID = 3,
                                    Category = "Category 1",
                                    Header = "Header 3",
                                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas ac nunc at nisl hendrerit ornare eu eu tortor. Mauris et consequat massa. Donec laoreet ante quis interdum tristique. Nam a elit ut enim pharetra pharetra eget vel ex. Phasellus nec viverra lorem. Duis auctor ipsum tortor, ultricies pulvinar justo gravida ac. Sed pellentesque elit nec neque vehicula sodales. Sed congue non ligula pharetra egestas. Nam vel finibus ante. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.",
                                    VolonteerInfoID = 1,
                                    CollectedSum = 30,
                                    GoalSum = 100,},
                new Advertisement { ID = 4,
                                    Category = "Category 1",
                                    Header = "Header 4",
                                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas ac nunc at nisl hendrerit ornare eu eu tortor. Mauris et consequat massa. Donec laoreet ante quis interdum tristique. Nam a elit ut enim pharetra pharetra eget vel ex. Phasellus nec viverra lorem. Duis auctor ipsum tortor, ultricies pulvinar justo gravida ac. Sed pellentesque elit nec neque vehicula sodales. Sed congue non ligula pharetra egestas. Nam vel finibus ante. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.",
                                    VolonteerInfoID = 2,
                                    CollectedSum = 40,
                                    GoalSum = 100,},
                new Advertisement { ID = 5,
                                    Category = "Category 2",
                                    Header = "Header 5",
                                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas ac nunc at nisl hendrerit ornare eu eu tortor. Mauris et consequat massa. Donec laoreet ante quis interdum tristique. Nam a elit ut enim pharetra pharetra eget vel ex. Phasellus nec viverra lorem. Duis auctor ipsum tortor, ultricies pulvinar justo gravida ac. Sed pellentesque elit nec neque vehicula sodales. Sed congue non ligula pharetra egestas. Nam vel finibus ante. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.",
                                    VolonteerInfoID = 1,
                                    CollectedSum = 50,
                                    GoalSum = 100,},
                new Advertisement { ID = 6,
                                    Category = "Category 2",
                                    Header = "Header 6",
                                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas ac nunc at nisl hendrerit ornare eu eu tortor. Mauris et consequat massa. Donec laoreet ante quis interdum tristique. Nam a elit ut enim pharetra pharetra eget vel ex. Phasellus nec viverra lorem. Duis auctor ipsum tortor, ultricies pulvinar justo gravida ac. Sed pellentesque elit nec neque vehicula sodales. Sed congue non ligula pharetra egestas. Nam vel finibus ante. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.",
                                    VolonteerInfoID = 2,
                                    CollectedSum = 60,
                                    GoalSum = 100,},
                new Advertisement { ID = 7,
                                    Category = "Category 2",
                                    Header = "Header 7",
                                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas ac nunc at nisl hendrerit ornare eu eu tortor. Mauris et consequat massa. Donec laoreet ante quis interdum tristique. Nam a elit ut enim pharetra pharetra eget vel ex. Phasellus nec viverra lorem. Duis auctor ipsum tortor, ultricies pulvinar justo gravida ac. Sed pellentesque elit nec neque vehicula sodales. Sed congue non ligula pharetra egestas. Nam vel finibus ante. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.",
                                    VolonteerInfoID = 1,
                                    CollectedSum = 70,
                                    GoalSum = 100,},
                new Advertisement { ID = 8,
                                    Category = "Category 2",
                                    Header = "Header 8",
                                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas ac nunc at nisl hendrerit ornare eu eu tortor. Mauris et consequat massa. Donec laoreet ante quis interdum tristique. Nam a elit ut enim pharetra pharetra eget vel ex. Phasellus nec viverra lorem. Duis auctor ipsum tortor, ultricies pulvinar justo gravida ac. Sed pellentesque elit nec neque vehicula sodales. Sed congue non ligula pharetra egestas. Nam vel finibus ante. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.",
                                    VolonteerInfoID = 2,
                                    CollectedSum = 80,
                                    GoalSum = 100,},
                new Advertisement { ID = 9,
                                    Category = "Category 3",
                                    Header = "Header 9",
                                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas ac nunc at nisl hendrerit ornare eu eu tortor. Mauris et consequat massa. Donec laoreet ante quis interdum tristique. Nam a elit ut enim pharetra pharetra eget vel ex. Phasellus nec viverra lorem. Duis auctor ipsum tortor, ultricies pulvinar justo gravida ac. Sed pellentesque elit nec neque vehicula sodales. Sed congue non ligula pharetra egestas. Nam vel finibus ante. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.",
                                    VolonteerInfoID = 1,
                                    CollectedSum = 90,
                                    GoalSum = 100,},
                new Advertisement { ID = 10,
                                    Category = "Category 3",
                                    Header = "Header 10",
                                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas ac nunc at nisl hendrerit ornare eu eu tortor. Mauris et consequat massa. Donec laoreet ante quis interdum tristique. Nam a elit ut enim pharetra pharetra eget vel ex. Phasellus nec viverra lorem. Duis auctor ipsum tortor, ultricies pulvinar justo gravida ac. Sed pellentesque elit nec neque vehicula sodales. Sed congue non ligula pharetra egestas. Nam vel finibus ante. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.",
                                    VolonteerInfoID = 2,
                                    CollectedSum = 100,
                                    GoalSum = 100,},
                new Advertisement { ID = 11,
                                    Category = "Category 3",
                                    Header = "Header 11",
                                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas ac nunc at nisl hendrerit ornare eu eu tortor. Mauris et consequat massa. Donec laoreet ante quis interdum tristique. Nam a elit ut enim pharetra pharetra eget vel ex. Phasellus nec viverra lorem. Duis auctor ipsum tortor, ultricies pulvinar justo gravida ac. Sed pellentesque elit nec neque vehicula sodales. Sed congue non ligula pharetra egestas. Nam vel finibus ante. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.",
                                    VolonteerInfoID = 1,
                                    CollectedSum = 12,
                                    GoalSum = 100},
                new Advertisement { ID = 12,
                                    Category = "Category 3",
                                    Header = "Header 12",
                                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas ac nunc at nisl hendrerit ornare eu eu tortor. Mauris et consequat massa. Donec laoreet ante quis interdum tristique. Nam a elit ut enim pharetra pharetra eget vel ex. Phasellus nec viverra lorem. Duis auctor ipsum tortor, ultricies pulvinar justo gravida ac. Sed pellentesque elit nec neque vehicula sodales. Sed congue non ligula pharetra egestas. Nam vel finibus ante. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.",
                                    VolonteerInfoID = 2,
                                    CollectedSum = 85,
                                    GoalSum = 100}
            };

            modelBuilder.Entity<Advertisement>().HasData(advertisements);


            var photoes = new List<Photo>
            {
                new Photo { Id = 1,
                            URL="https://i.kym-cdn.com/entries/icons/original/000/043/403/cover3.jpg",
                            AdID = 1,
                           },
                new Photo { Id = 2,
                            URL="https://wegotthiscovered.com/wp-content/uploads/2022/09/Olli-The-Polite-Cat-Meme.jpeg?w=1200",
                            AdID = 2,
                           },
                new Photo { Id = 3,
                            URL="https://i.cbc.ca/1.5359228.1577206958!/fileImage/httpImage/image.jpg_gen/derivatives/16x9_940/smudge-the-viral-cat.jpg",
                            AdID = 3,
                           },
            };

            modelBuilder.Entity<Photo>().HasData(photoes);


            var users = new List<User>
            {
                new User { Id = 1, 
                           Name = "user1", 
                           Password="111",
                           Token="",
                           Balance = 100
                            },
                new User { Id = 2,
                           Name = "volonteer1",
                           Password="111",
                           Token="",
                           Balance = 200
                            },
                new User { Id = 3,
                           Name = "volonteer2",
                           Password="111",
                           Token="",
                           Balance = 300
                            },
                new User { Id = 4,
                           Name = "volonteer3",
                           Password="111",
                           Token="",
                           Balance = 200
                            },
                new User { Id = 5,
                           Name = "volonteer4",
                           Password="111",
                           Token="",
                           Balance = 300
                            },
                new User { Id = 6,
                           Name = "volonteer5",
                           Password="111",
                           Token="",
                           Balance = 200
                            },
                new User { Id = 7,
                           Name = "volonteer6",
                           Password="111",
                           Token="",
                           Balance = 300
                            },
                new User { Id = 8,
                           Name = "admin1",
                           Password="111",
                           Token="",
                           Balance = 400
                            },
            };

            modelBuilder.Entity<User>().HasData(users);

            var volonteers = new List<VolonteerInfo>
            {
                new VolonteerInfo { Id = 1,
                                    UserId = 2,
                                    Description = "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1"
                            },
                new VolonteerInfo { Id = 2,
                                    UserId = 3,
                                    Description = "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1"
                            },
                new VolonteerInfo { Id = 3,
                                    UserId = 4,
                                    Description = "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1"
                            },
                new VolonteerInfo { Id = 4,
                                    UserId = 5,
                                    Description = "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1"
                            },
                new VolonteerInfo { Id = 5,
                                    UserId = 6,
                                    Description = "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1"
                            },
                new VolonteerInfo { Id = 6,
                                    UserId = 7,
                                    Description = "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1" +
                                    "Test1 Test1 Test1 Test1 Test1 Test1"
                            }
            };

            modelBuilder.Entity<VolonteerInfo>().HasData(volonteers);

            var subscriptions = new List<Subscription>
            {
                new Subscription { ID = 1,
                                    UserID = 1,
                                    VolonteerID = 4,
                            },
                new Subscription { ID = 2,
                                    UserID = 1,
                                    VolonteerID = 5,
                            },
                new Subscription { ID = 3,
                                    UserID = 1,
                                    VolonteerID = 6,
                            }
            };

            modelBuilder.Entity<Subscription>().HasData(subscriptions);

        }
    }
}
