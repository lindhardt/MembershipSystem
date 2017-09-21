using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MembershipSystem.Models
{
    public class MembershipInitializer : DropCreateDatabaseAlways<MembershipContext>
    {
        protected override void Seed(MembershipContext context)
        {
            var roles = new List<Role>
            {
                new Role
                {
                    Name = "Formand"
                },
               
                new Role
                {
                    Name = "Næsteformad"
                },

                new Role
                {
                    Name = "Sekretær"
                },

            };

            context.Roles.AddRange(roles);
            context.SaveChanges();

            var users = new List<User>
            {
                new User
                {
                    FirstName = "Flemming",
                    LastName = "Poulsen",
                    Email = "FP@Poulsen.dk",
                    Address = "Poulsengade 72"
                },
                new User
                {
                    FirstName = "Poul",
                    LastName = "Flemmingsen",
                    Email = "PF@Flemmingsen.dk",
                    Address = "Flemmingsensgade 27"
                },
            };

            users.ForEach(user => context.Users.Add(user));

            context.SaveChanges();

            users.ForEach(user => user.Roles.Add(new UserRole { RoleId = roles.First().RoleId, UserId = user.UserId}));

            context.SaveChanges();

            var activity = new Activity
            {
                Name = "Træning"
            };

            context.Activities.Add(activity);

            context.SaveChanges();

            var reservations = new List<Reservation>
            {
                new Reservation
                {
                    Date = DateTime.Now,
                    ReservationStart = DateTime.Now,
                    ReservationEnd = DateTime.Now.AddHours(2),
                    PlayingField = "Bat-01",
                    UserId = users.First().UserId,
                    ActivityId = activity.ActivityId
                },

                new Reservation
                {
                    Date = DateTime.Now,
                    ReservationStart = DateTime.Now,
                    ReservationEnd = DateTime.Now.AddHours(2),
                    PlayingField = "Bat-02",
                    UserId = users.Last().UserId,
                    ActivityId = activity.ActivityId
                },
            };

            reservations.ForEach(reservation => context.Reservations.Add(reservation));

            context.SaveChanges();
        }
    }
}