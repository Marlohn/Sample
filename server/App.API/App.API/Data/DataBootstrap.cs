using App.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.API.Data
{
    public static class DataBootstrap
    {
        public static void Bootstrap()
        {
            var random = new Random(42);
            var officeNumber = 100;
            var usersMin = 15;
            var usersMax = 25;
            using var context = new SampleAppContext();
            context.Database.Migrate();

            if (context.Users.Any())
            {
                return;
            }

            Console.WriteLine("Initial data population is started. It can take some time. Please wait...");

            var offices = Enumerable.Range(0, officeNumber).SelectMany(o =>
                StreetNames.Select(oo => new Office
                {
                    Id = Guid.NewGuid(),
                    Address = $"{o * 20} {oo}"
                })
            ).ToArray();

            var user = new User
            {
                Id = Guid.NewGuid(),
                Office = offices[random.Next(0, offices.Length - 1)],
                Login = "admin"
            };

            var roles = new[]
            {
                new Role{ Id = Guid.NewGuid(), Name = "Admin" },
                new Role{ Id = Guid.NewGuid(), Name = "Agent" },
                new Role{ Id = Guid.NewGuid(), Name = "OfficeManager" }
            };

            var users = new List<User>();
            foreach (var office in offices)
            {
                var userNumber = random.Next(usersMin, usersMax);
                for (int i = 0; i < userNumber; i++)
                {
                    users.Add(new User
                    {
                        Id = Guid.NewGuid(),
                        Login = $"{FirstNames[random.Next(0, FirstNames.Length - 1)]} {LastNames[random.Next(0, LastNames.Length - 1)]}",
                        Office = offices[random.Next(0, offices.Length - 1)],
                    });
                }
            }

            var userRole = new UserRole
            {
                UserId = user.Id,
                RoleId = roles[0].Id
            };

            context.Users.Add(user);
            context.Users.AddRange(users);
            context.Roles.AddRange(roles);
            context.UserRoles.Add(userRole);
            context.Offices.AddRange(offices);

            context.SaveChanges();

            Console.WriteLine("Done.");
        }

        static string[] StreetNames = new[]
        {
            "ROCKAWAY PARKWAY",
            "178TH",
            "GRAND CONCOURSE",
            "CORTELYOU",
            "153RD",
            "MACDONOUGH",
            "HORACE HARDING",
            "BAINBRIDGE",
            "UTOPIA PARKWAY",
            "MACON",
            "VERNON",
            "SEVENTH",
            "SNYDER",
            "ASTORIA",
            "STEINWAY",
            "KENT",
            "BLEECKER",
            "ESSEX",
            "179TH",
            "216TH",
            "EVERGREEN",
            "BRUCKNER",
            "184TH",
            "174TH",
            "198TH",
            "NINTH",
            "MAPLE",
            "AVENUE I",
            "RIDGE",
            "AVENUE X",
            "177TH",
            "187TH",
            "EIGHTH",
            "BAY PARKWAY",
            "BEVERLEY",
            "MURDOCK",
            "SKILLMAN",
            "DITMARS",
            "NEW UTRECHT",
            "182ND",
            "173RD",
            "197TH",
            "HOWARD",
            "TENTH",
            "AVENUE V",
            "STILLWELL",
            "MANOR",
            "OVINGTON",
            "MORRIS",
            "195TH",
            "AVENUE W",
            "TOMPKINS",
            "SOUTHERN",
            "ELDERT",
            "MONTGOMERY",
            "BATH",
            "BEACH",
            "186TH",
            "BLAKE",
            "188TH",
            "COLUMBUS",
            "DAHILL",
            "176TH",
            "DUMONT",
            "192ND",
            "MORGAN",
            "190TH",
            "AVENUE O",
            "PAULDING",
            "CROPSEY",
            "199TH",
            "194TH",
            "GREENWICH",
            "189TH",
            "FREDERICK DOUGLASS",
            "BAYSIDE",
            "154TH",
            "GUY R BREWER",
            "AUSTIN",
            "CLEVELAND",
            "CROWN",
            "UNIVERSITY",
            "CLARKSON",
            "234TH",
            "209TH",
            "ROCKAWAY BEACH",
            "193RD",
            "LITTLE NECK PARKWAY",
            "VERMONT",
            "RIDGEWOOD",
            "FARMERS",
            "JEWEL",
            "AVENUE Y",
            "WALTON",
            "GROVE",
            "BARNES",
            "ARLINGTON",
            "LEONARD",
            "GREENPOINT",
            "GRANT"
            };

        static string[] FirstNames = new[]
        {
            "Dan",
            "Kevin",
            "Tom",
            "Matt",
            "Linda",
            "Rachel",
            "Steven",
            "Stephanie",
            "Mary",
            "Maria",
            "Ben",
            "Julie",
            "Bill",
            "Emily",
            "Sam",
            "Joseph",
            "Jane",
            "Nicole",
            "Anna",
            "Jim",
            "Matthew",
            "Melissa",
            "Andrea",
            "Carol",
            "George",
            "Greg",
            "Alan",
            "Josh",
            "Stephen",
            "Christine",
            "Rebecca",
            "Nick",
            "Kate",
            "Ellen",
            "Anne",
            "Charles",
            "William",
            "Sara",
            "Anthony",
            "Marc",
            "Frank",
            "Bob",
            "Ryan",
            "Amanda",
            "Liz",
            "Jon",
            "Judy",
            "Gary",
            "Patricia",
            "Thomas",
            "Beth",
            "Robin",
            "Wendy",
            "Julia",
            "Patrick",
            "Tim",
            "Christina",
            "Kim",
            "Rob",
            "Christopher",
            "Ann",
            "Justin",
            "Jay",
            "Sharon",
            "Ken",
            "Jack",
            "Diane",
            "Jill",
            "Caroline",
            "Leslie",
            "Katie",
            "Ron",
            "Tony",
            "Alexandra",
            "Allison",
            "Jamie",
            "Jeffrey",
            "Diana",
            "Catherine",
            "Larry",
            "Sean",
            "Deborah",
            "Danielle",
            "Angela",
            "Andy",
            "Heather",
            "Victoria",
            "Joan",
            "Helen",
            "Jenny",
            "Janet",
            "Lori",
            "Ed",
            "Donna",
            "Dana",
            "Kathy",
            "Nina",
            "Jackie",
            "Suzanne",
            "Michele"
        };

        static string[] LastNames = new[]
        {
            "Deutsch",
            "Blum",
            "McDonald",
            "Zhu",
            "Gardner",
            "Lane",
            "Frankel",
            "Freeman",
            "Strauss",
            "Patterson",
            "sutton",
            "Kane",
            "Doe",
            "Simmons",
            "Gottlieb",
            "Jacobson",
            "Myers",
            "Charles",
            "Zhou",
            "Goldsmith",
            "Mason",
            "Abrams",
            "Kay",
            "Baron",
            "Geller",
            "Wolfe",
            "Reid",
            "Wasserman",
            "Rosenfeld",
            "Hart",
            "Baum",
            "Freedman",
            "Morrison",
            "Ellis",
            "Reilly",
            "Zhao",
            "Rao",
            "Brenner",
            "Long",
            "Block",
            "Richardson",
            "Glass",
            "Foley",
            "Alvarez",
            "Shin",
            "Wells",
            "Song",
            "Sanders",
            "Warner",
            "RENTAL",
            "Rich",
            "Meyers",
            "Gill",
            "Barry",
            "Ali",
            "V",
            "Tucker",
            "Lai",
            "Richards",
            "Stark",
            "Leung",
            "Reynolds",
            "Simpson",
            "Jiang",
            "Sales Office",
            "Fishman",
            "Keller",
            "Watson",
            "Sandler",
            "Quinn",
            "Palmer",
            "Fitzgerald",
            "O'Connor",
            "Porter",
            "Leonard",
            "Abraham",
            "Romano",
            "Cohn",
            "Berg",
            "Zimmerman",
            "Jain",
            "Brody",
            "Tran",
            "Dunn",
            "N",
            "Griffin",
            "Tsai",
            "Fine",
            "Matthews",
            "Reed",
            "Lo",
            "Powell",
            "Farrell",
            "Oh",
            "Clarke",
            "Flynn",
            "Mills",
            "Chapman",
            "Ramirez",
            "Mayer"
        };
    }
}
