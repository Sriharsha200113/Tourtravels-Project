using Microsoft.AspNetCore.Identity;
using Tourtravels.data;
using Tourtravels.data.Static;
using Tourtravels.Models;

namespace Tourtravels.data
{
    public class Intializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                //Package
                if (!context.Package.Any())
                {
                    context.Package.AddRange(new List<Package>()
                    {
                        new Package()
                        {
                            Image = "https://pbs.twimg.com/media/ETNOIrzU4AAbq83.jpg",
                            Name = "Package 1",
                            Description = "hello",


                        },
                        new Package()
                        {
                             Image = "http://dotnethow.net/images/actors/actor-1.jpeg",
                            Name = "Package 1",
                            Description = "hello"
                        },
                        new Package()
                        {
                            Image = "http://dotnethow.net/images/actors/actor-1.jpeg",
                            Name = "Package 1",
                            Description = "hello"
                        },
                        new Package()
                        {
                             Image = "http://dotnethow.net/images/actors/actor-1.jpeg",
                            Name = "Package 1",
                            Description = "hello"
                        },
                        new Package()
                        {
                            Image = "http://dotnethow.net/images/actors/actor-1.jpeg",
                            Name = "Package 1",
                            Description = "hello Sunny"
                        }
                    });
                    context.SaveChanges();

                }
                //Places
                if (!context.Place.Any())
                {
                    context.Place.AddRange(new List<Places>()
                    {
                        new Places()
                        {
                           ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-1.jpeg",
                            FullName = "Place1",


                        },
                        new Places()
                        {
                            ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-1.jpeg",
                            FullName = "Place1",
                        },
                        new Places()
                        {
                            ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-1.jpeg",
                            FullName = "Place1",
                        },
                        new Places()
                        {ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-1.jpeg",
                            FullName = "Place1",
                        },
                        new Places()
                        {
                            ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-1.jpeg",
                            FullName = "Place1",
                        }
                    });
                    context.SaveChanges();

                }
                //Guides
                if (!context.Guides.Any())
                {
                    context.Guides.AddRange(new List<Guide>()
                    {
                        new Guide()
                        {
                           ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-1.jpeg",
                            FullName = "Place1",
                            Bio=" guide"
                        },
                        new Guide()
                        {
                           ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-1.jpeg",
                            FullName = "Place1",
                            Bio=" guide"
                        },
                        new Guide()
                        {
                           ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-1.jpeg",
                            FullName = "Place1",
                            Bio=" guide"
                        },
                        new Guide()
                        {
                           ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-1.jpeg",
                            FullName = "Place1",
                            Bio=" guide"
                        },
                        new Guide()
                        {
                           ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-1.jpeg",
                            FullName = "Place1",
                            Bio=" guide"
                        },

                    });
                    context.SaveChanges();

                }
                //Tours
                if (!context.Tour.Any())
                {
                    context.Tour.AddRange(new List<Tour>()
                    {
                        new Tour()
                        {
                          Name = "tour 1",
                          Description= "about the tour",
                          Price=20000,
                          ImageUrl="http://dotnethow.net/images/actors/actor-1.jpeg",
                          StartDate=DateTime.Now,
                          EndDate=DateTime.Now,
                          Persons=4,
                          GuideId=1,
                          PackageId=3,
                          TourCategory=TourCategory.couple

                        },
                        new Tour()
                        {
                          Name = "tour 1",
                          Description= "about the tour",
                          Price=20000,
                          ImageUrl="http://dotnethow.net/images/actors/actor-1.jpeg",
                          StartDate=DateTime.Now,
                          EndDate=DateTime.Now,
                          Persons=4,
                          GuideId=1,
                          PackageId=5,
                          TourCategory=TourCategory.couple
                        },
                        new Tour()
                        {
                          Name = "tour 1",
                          Description= "about the tour",
                          Price=20000,
                          ImageUrl="http://dotnethow.net/images/actors/actor-1.jpeg",
                           StartDate=DateTime.Now,
                          EndDate=DateTime.Now,
                          Persons=4,
                          GuideId=2,
                          PackageId=4,
                          TourCategory=TourCategory.couple
                        },
                        new Tour()
                        {
                          Name = "tour 1",
                          Description= "about the tour",
                          Price=20000,
                          ImageUrl="http://dotnethow.net/images/actors/actor-1.jpeg",
                           StartDate=DateTime.Now,
                          EndDate=DateTime.Now,
                          Persons=4,
                          GuideId=5,
                          PackageId=3,
                          TourCategory=TourCategory.couple
                        },
                        new Tour()
                        {
                          Name = "tour 1",
                          Description= "about the tour",
                          Price=20000,
                          ImageUrl="http://dotnethow.net/images/actors/actor-1.jpeg",
                           StartDate=DateTime.Now,
                          EndDate=DateTime.Now,
                          Persons=4,
                          GuideId=2,
                          PackageId=3,
                          TourCategory=TourCategory.couple
                        },

                    }); ;
                    context.SaveChanges();

                }
                //tour & place
                if (!context.Tour_Places.Any())
                {
                    context.Tour_Places.AddRange(new List<Tour_place>()
                    {
                        new Tour_place()
                        {
                            TourId=1,
                            PlaceId=2,
                        },
                        new Tour_place()
                        {
                            TourId=3,
                            PlaceId=4,
                        },
                        new Tour_place()
                        {
                            TourId=2,
                            PlaceId=4,
                        },
                        new Tour_place()
                        {
                            TourId=4,
                            PlaceId=3,
                        },
                        new Tour_place()
                        {
                            TourId=2,
                            PlaceId=3,
                        },
                         new Tour_place()
                        {
                            TourId=3,
                            PlaceId=1,
                        },
                        new Tour_place()
                        {
                            TourId=4,
                            PlaceId=5,
                        },
                        new Tour_place()
                        {
                            TourId=5,
                            PlaceId=1,
                        },
                        new Tour_place()
                        {
                            TourId=4,
                            PlaceId=2,
                        },
                        new Tour_place()
                        {
                            TourId=2,
                            PlaceId=5,
                        }

                    });
                    context.SaveChanges();

                }
            }
        }


        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@Tours.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Sunny@123");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@Tours.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Sunny@123");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }


            }
        }



    }
}
