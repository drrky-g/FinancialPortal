namespace FinancialPortal.Migrations
{
    using FinancialPortal.Helpers;
    using FinancialPortal.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Configuration;

    internal sealed class Configuration : DbMigrationsConfiguration<FinancialPortal.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FinancialPortal.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var houseHelper = new HouseholdHelper();

            // Instance of RoleManager 
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));

            //Instance of UserManager
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            // Roles
            #region Seeded Roles
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }
            if (!context.Roles.Any(r => r.Name == "HouseholdMember"))
            {
                roleManager.Create(new IdentityRole { Name = "HouseholdMember" });
            }
            if (!context.Roles.Any(r => r.Name == "NoHousehold"))
            {
                roleManager.Create(new IdentityRole { Name = "NoHousehold" });
            }
            #endregion

            //List of Users (comment)
            #region User Index
            //Avengers Users Seed

            //-----------------------
            //Derrick (Derrick Gordon)
            //Fury (Nick Fury)
            //Iron Man (Tony Stark)
            //Captain America (Steve Roders)
            //Black Widow (Natasha Romanoff)
            //Captain Marvel (Carol Danvers)
            //Black Panther (T'Challa T'Chaka)
            //Thor (Thor Odinson)
            //Hulk (Bruce Banner)
            //Vision (Victor Shade)
            //Ant Man (Scott Lang)
            //Dr. Strange (Steven Strange)
            //Rocket (Rocket Raccoon)
            //Shuri (Shuri T'Chaka)
            //Hawkeye (Clint Barton)
            //Spider Man (Peter Parker)
            //Star Lord (Peter Quill)
            //Mantis (Mandy Celestine)
            //Scarlet Witch (Wanda Maximoff)
            //Winter Soldier (James Buchanan)
            //Pepper (Virginia Potts)
            //Falcon (Sam Wilson)
            #endregion

            //passwords
            #region Passwords from private.config
            var myPassword = WebConfigurationManager.AppSettings["myPassword"];
            var demoPassword = WebConfigurationManager.AppSettings["demoPassword"];
            var userPassword = WebConfigurationManager.AppSettings["seededPassword"];
            #endregion

            //Add Avengers User Accounts
            #region Add Avengers as users.
            if (!context.Users.Any(u => u.Email == "derrickwg17@gmail.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    Id = "master",
                    UserName = "derrickwg17@gmail.com",
                    Email = "derrickwg17@gmail.com",
                    FirstName = "Derrick",
                    LastName = "Gordon",
                    Alias = "Derrick"

                }, myPassword);
            }

            if (!context.Users.Any(u => u.Email == "Fury@Mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    Id = "nickfury",
                    UserName = "Fury@Mailinator.com",
                    Email = "Fury@Mailinator.com",
                    FirstName = "Nick",
                    LastName = "Fury",
                    Alias = "Fury",
                    AvatarPath = "/Avatars/AvengersAvatars/fury.jpeg"
                }, demoPassword);
            }

            if (!context.Users.Any(u => u.Email == "IronMan@Mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    Id = "ironman",
                    UserName = "IronMan@Mailinator.com",
                    Email = "IronMan@Mailinator.com",
                    FirstName = "Tony",
                    LastName = "Stark",
                    Alias = "Iron Man",
                    AvatarPath = "/Avatars/AvengersAvatars/ironman.jpg"
                }, demoPassword);
            }

            if (!context.Users.Any(u => u.Email == "CaptainAmerica@Mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    Id = "captamerica",
                    UserName = "CaptainAmerica@Mailinator.com",
                    Email = "CaptainAmerica@Mailinator.com",
                    FirstName = "Steve",
                    LastName = "Rogers",
                    Alias = "Captain America",
                    AvatarPath = "/Avatars/AvengersAvatars/cap.jpg"
                }, userPassword);
            }

            if (!context.Users.Any(u => u.Email == "BlackWidow@Mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    Id = "blackwidow",
                    UserName = "BlackWidow@Mailinator.com",
                    Email = "BlackWidow@Mailinator.com",
                    FirstName = "Natasha",
                    LastName = "Romanov",
                    Alias = "Black Widow",
                    AvatarPath = "/Avatars/AvengersAvatars/nat.jpg"
                }, userPassword);
            }

            if (!context.Users.Any(u => u.Email == "CaptainMarvel@Mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    Id = "captmarvel",
                    UserName = "CaptainMarvel@Mailinator.com",
                    Email = "CaptainMarvel@Mailinator.com",
                    FirstName = "Carol",
                    LastName = "Danvers",
                    Alias = "Captain Marvel",
                    AvatarPath = "/Avatars/AvengersAvatars/danvers.jpg"
                }, userPassword);
            }

            if (!context.Users.Any(u => u.Email == "Thor@Mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    Id = "thorodinson",
                    UserName = "Thor@Mailinator.com",
                    Email = "Thor@Mailinator.com",
                    FirstName = "Thor",
                    LastName = "Odinson",
                    Alias = "Thor",
                    AvatarPath = "/Avatars/AvengersAvatars/thor.jpg"
                }, userPassword);
            }

            if (!context.Users.Any(u => u.Email == "BlackPanther@Mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    Id = "blackpanther",
                    UserName = "BlackPanther@Mailinator.com",
                    Email = "BlackPanther@Mailinator.com",
                    FirstName = "T'Challa",
                    LastName = "T'Chaka",
                    Alias = "Black Panther",
                    AvatarPath = "/Avatars/AvengersAvatars/tchalla.jpg"
                }, userPassword);
            }

            if (!context.Users.Any(u => u.Email == "Hulk@Mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    Id = "thehulk",
                    UserName = "Hulk@Mailinator.com",
                    Email = "Hulk@Mailinator.com",
                    FirstName = "Bruce",
                    LastName = "Banner",
                    Alias = "Hulk",
                    AvatarPath = "/Avatars/AvengersAvatars/hulk.jpg"
                }, demoPassword);
            }

            if (!context.Users.Any(u => u.Email == "Vision@Mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    Id = "vision",
                    UserName = "Vision@Mailinator.com",
                    Email = "Vision@Mailinator.com",
                    FirstName = "Victor",
                    LastName = "Shade",
                    Alias = "Vision",
                    AvatarPath = "/Avatars/AvengersAvatars/vision.jpg"
                }, userPassword);
            }

            if (!context.Users.Any(u => u.Email == "AntMan@Mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    Id = "antman",
                    UserName = "AntMan@Mailinator.com",
                    Email = "AntMan@Mailinator.com",
                    FirstName = "Scott",
                    LastName = "Lang",
                    Alias = "AntMan",
                    AvatarPath = "/Avatars/AvengersAvatars/antman.jpg"
                }, userPassword);
            }

            if (!context.Users.Any(u => u.Email == "DrStrange@Mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    Id = "drstrange",
                    UserName = "DrStrange@Mailinator.com",
                    Email = "DrStrange@Mailinator.com",
                    FirstName = "Steven",
                    LastName = "Strange",
                    Alias = "Dr. Strange",
                    AvatarPath = "/Avatars/AvengersAvatars/strange.jpg"
                }, userPassword);
            }

            if (!context.Users.Any(u => u.Email == "Rocket@Mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    Id = "rocket",
                    UserName = "Rocket@Mailinator.com",
                    Email = "Rocket@Mailinator.com",
                    FirstName = "Rocket",
                    LastName = "Raccoon",
                    Alias = "Rocket",
                    AvatarPath = "/Avatars/AvengersAvatars/rocket.jpg"
                }, userPassword);
            }

            if (!context.Users.Any(u => u.Email == "Shuri@Mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    Id = "shuri",
                    UserName = "Shuri@Mailinator.com",
                    Email = "Shuri@Mailinator.com",
                    FirstName = "Shuri",
                    LastName = "T'Chaka",
                    Alias = "Shuri",
                    AvatarPath = "/Avatars/AvengersAvatars/shuri.png"
                }, userPassword);
            }

            if (!context.Users.Any(u => u.Email == "Hawkeye@Mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    Id = "hawkeye",
                    UserName = "Hawkeye@Mailinator.com",
                    Email = "Hawkeye@Mailinator.com",
                    FirstName = "Clint",
                    LastName = "Barton",
                    Alias = "Hawkeye",
                    AvatarPath = "/Avatars/AvengersAvatars/hawkeye.jpg"
                }, userPassword);
            }

            if (!context.Users.Any(u => u.Email == "SpiderMan@Mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    Id = "spiderman",
                    UserName = "SpiderMan@Mailinator.com",
                    Email = "SpiderMan@Mailinator.com",
                    FirstName = "Peter",
                    LastName = "Parker",
                    Alias = "Spider Man",
                    AvatarPath = "/Avatars/AvengersAvatars/spiderman.png"
                }, demoPassword);
            }

            if (!context.Users.Any(u => u.Email == "StarLord@Mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    Id = "starlord",
                    UserName = "StarLord@Mailinator.com",
                    Email = "StarLord@Mailinator.com",
                    FirstName = "Peter",
                    LastName = "Quill",
                    Alias = "Star Lord",
                    AvatarPath = "/Avatars/AvengersAvatars/starlord.jpg"
                }, userPassword);
            }

            if (!context.Users.Any(u => u.Email == "WarMachine@Mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    Id = "warmachine",
                    UserName = "WarMachine@Mailinator.com",
                    Email = "WarMachine@Mailinator.com",
                    FirstName = "James",
                    LastName = "Rhodes",
                    Alias = "War Machine",
                    AvatarPath = "/Avatars/AvengersAvatars/warmachine.jpg"
                }, userPassword);
            }

            if (!context.Users.Any(u => u.Email == "Mantis@Mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    Id = "mantis",
                    UserName = "Mantis@Mailinator.com",
                    Email = "Mantis@Mailinator.com",
                    FirstName = "Mandy",
                    LastName = "Celestine",
                    Alias = "Mantis",
                    AvatarPath = "/Avatars/AvengersAvatars/mantis.png"
                }, userPassword);
            }

            if (!context.Users.Any(u => u.Email == "ScarletWitch@Mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    Id = "scarletwitch",
                    UserName = "ScarletWitch@Mailinator.com",
                    Email = "ScarletWitch@Mailinator.com",
                    FirstName = "Wanda",
                    LastName = "Maximoff",
                    Alias = "Scarlet Witch",
                    AvatarPath = "/Avatars/AvengersAvatars/scarletwitch.jpg"
                }, userPassword);
            }

            if (!context.Users.Any(u => u.Email == "WinterSoldier@Mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    Id = "wintersoldier",
                    UserName = "WinterSoldier@Mailinator.com",
                    Email = "WinterSoldier@Mailinator.com",
                    FirstName = "James",
                    LastName = "Buchanan",
                    Alias = "Winter Soldier",
                    AvatarPath = "/Avatars/AvengersAvatars/wintersoldier.jpg"
                }, userPassword);
            }

            if (!context.Users.Any(u => u.Email == "Pepper@Mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    Id = "pepperpotts",
                    UserName = "Pepper@Mailinator.com",
                    Email = "Pepper@Mailinator.com",
                    FirstName = "Virginia",
                    LastName = "Potts",
                    Alias = "Pepper",
                    AvatarPath = "/Avatars/AvengersAvatars/pepperpotts.jpg"
                }, userPassword);
            }

            if (!context.Users.Any(u => u.Email == "Falcon@Mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    Id = "falcon",
                    UserName = "Falcon@Mailinator.com",
                    Email = "Falcon@Mailinator.com",
                    FirstName = "Sam",
                    LastName = "Wilson",
                    Alias = "Falcon",
                    AvatarPath = "/Avatars/AvengersAvatars/falcon.jpg"
                }, userPassword);
            }
            context.SaveChanges();
            #endregion

            //Avenger User Roles
            #region Role Assignment

            //
            //Admins:

            userManager.AddToRole("master", "Admin");


            //
            //HeadOfHouse:
            userManager.AddToRole("nickfury", "HouseholdMember");
            userManager.AddToRole("starlord", "HouseholdMember");
            userManager.AddToRole("ironman", "HouseholdMember");
            userManager.AddToRole("blackpanther", "HouseholdMember");


            //
            //HouseholdMember:

            //nickfury
            //-------------------------------------------
            userManager.AddToRole("blackwidow", "HouseholdMember");
            userManager.AddToRole("captmarvel", "HouseholdMember");
            userManager.AddToRole("antman", "HouseholdMember");
            userManager.AddToRole("hawkeye", "HouseholdMember");
            //starlord
            //------------------------------------------
            userManager.AddToRole("rocket", "HouseholdMember");
            userManager.AddToRole("thorodinson", "HouseholdMember");
            userManager.AddToRole("mantis", "HouseholdMember");
            //ironman
            //------------------------------------------
            userManager.AddToRole("vision", "HouseholdMember");
            userManager.AddToRole("warmachine", "HouseholdMember");
            userManager.AddToRole("pepperpotts", "HouseholdMember");
            userManager.AddToRole("spiderman", "HouseholdMember");
            //black panther
            //------------------------------------------
            userManager.AddToRole("wintersoldier", "HouseholdMember");
            userManager.AddToRole("falcon", "HouseholdMember");
            userManager.AddToRole("captamerica", "HouseholdMember");
            userManager.AddToRole("shuri", "HouseholdMember");

            //
            //NoHousehold:
            userManager.AddToRole("thehulk", "NoHousehold");
            userManager.AddToRole("drstrange", "NoHousehold");
            userManager.AddToRole("scarletwitch", "NoHousehold");

            context.SaveChanges();
            #endregion

            //AccountTypes
            #region Account Types

            context.AccountTypes.AddOrUpdate(
                acct => acct.Name,
                new AccountType { Name = "Checking" },
                new AccountType { Name = "Investment" },
                new AccountType { Name = "Savings" },
                new AccountType { Name = "Credit" });
            context.SaveChanges();
            #endregion

            //TransactionType
            #region Transaction Types

            context.TransactionTypes.AddOrUpdate(
                trans => trans.Name,
                new TransactionType { Name = "Deposit" },
                new TransactionType { Name = "Payment" });
            context.SaveChanges();
            #endregion

            //SeededHouseholds
            #region Households 

            context.Households.AddOrUpdate(
                hh => hh.Name,
                new Household
                {
                    Name = "Shield",
                    Created = DateTime.Now,
                    Description = "The S.H.I.E.L.D. group.",
                    HeadOfHouseId = "nickfury"
                },
                new Household
                {
                    Name = "Guardians",
                    Created = DateTime.Now,
                    Description = "The Guardians of the Galaxy (and friends).",
                    HeadOfHouseId = "starlord"
                },
                new Household
                {
                    Name = "Stark Industries",
                    Created = DateTime.Now,
                    Description = "Tony Stark's warmongering business.",
                    HeadOfHouseId = "ironman"
                },
                new Household
                {
                    Name = "Wakandians",
                    Created = DateTime.Now,
                    Description = "Members of the Wakanda royal family and their friends.",
                    HeadOfHouseId = "blackpanther"
                });
            context.SaveChanges();


            #endregion

            //Add users to their households
            #region Seed UserHouseholds
            var shieldId = context.Households.FirstOrDefault(house => house.Name == "Shield").Id;
            var guardiansId = context.Households.FirstOrDefault(house => house.Name == "Guardians").Id;
            var starkId = context.Households.FirstOrDefault(house => house.Name == "Stark Industries").Id;
            var wakandaId = context.Households.FirstOrDefault(house => house.Name == "Wakandians").Id;

            //Shield
            houseHelper.AddUserToHousehold("nickfury", shieldId);
            houseHelper.AddUserToHousehold("blackwidow", shieldId);
            houseHelper.AddUserToHousehold("captmarvel", shieldId);
            houseHelper.AddUserToHousehold("hawkeye", shieldId);
            houseHelper.AddUserToHousehold("antman", shieldId);
            //Guardians
            houseHelper.AddUserToHousehold("starlord", guardiansId);
            houseHelper.AddUserToHousehold("rocket", guardiansId);
            houseHelper.AddUserToHousehold("thorodinson", guardiansId);
            houseHelper.AddUserToHousehold("mantis", guardiansId);
            //Stark
            houseHelper.AddUserToHousehold("ironman", starkId);
            houseHelper.AddUserToHousehold("pepperpots", starkId);
            houseHelper.AddUserToHousehold("warmachine", starkId);
            houseHelper.AddUserToHousehold("vision", starkId);
            houseHelper.AddUserToHousehold("spiderman", starkId);
            //Wakanda
            houseHelper.AddUserToHousehold("captamerica", wakandaId);
            houseHelper.AddUserToHousehold("shuri", wakandaId);
            houseHelper.AddUserToHousehold("blackpanther", wakandaId);
            houseHelper.AddUserToHousehold("wintersoldier", wakandaId);
            houseHelper.AddUserToHousehold("falcon", wakandaId);

            context.SaveChanges();
            #endregion

        }
    }
}
