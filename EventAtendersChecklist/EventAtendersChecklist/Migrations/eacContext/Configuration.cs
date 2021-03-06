﻿namespace EventAtendersChecklist.Migrations.eacContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EventAtendersChecklist.DAL.EacContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\eacContext";
        }

        protected override void Seed(EventAtendersChecklist.DAL.EacContext context)
        {
            context.Employees.AddOrUpdate(employee => employee.Id,
                new Models.Employee
                {
                    Id = 1,
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    Email = "jankowalski@wp.pl"
                },
                new Models.Employee
                {
                    Id = 2,
                    FirstName = "Zygmunt",
                    LastName = "Szmuda",
                    Email = "zygmuntszmuda@wp.pl",
                },
                new Models.Employee
                {
                    Id = 3,
                    FirstName = "Marcin",
                    LastName = "Pilarczyk",
                    Email = "marcinpilarczyk@wp.pl"
                },
                new Models.Employee
                {
                    Id = 4,
                    FirstName = "Jan",
                    LastName = "Trol",
                    Email = "jantrol@wp.pl"
                });

            //New Event
            context.Events.AddOrUpdate(e => e.Id,
                new Models.Event { Id = 1, Name = "First Integration", StartDate = new DateTime(2017,09,29).AddYears(2), EndDate = new DateTime(2017, 09, 29).AddYears(2).AddDays(3)},
                new Models.Event { Id = 2, Name = "Floryda", StartDate = new DateTime(2016, 09, 29), EndDate = new DateTime(2016, 09, 29) });

            // New Event connection
            context.EmployeeEventAssignments.AddOrUpdate(eea => eea.Id,

                //Event 1
                new Models.EmployeeEventAssignment { Id = 1, EventId = 1, EmployeeId = 1, ActionDictionaryId = 1, ActionValue = true },
                new Models.EmployeeEventAssignment { Id = 2, EventId = 1, EmployeeId = 2, ActionDictionaryId = 1, ActionValue = true },
                new Models.EmployeeEventAssignment { Id = 3, EventId = 1, EmployeeId = 3, ActionDictionaryId = 1, ActionValue = true },
                new Models.EmployeeEventAssignment { Id = 4, EventId = 1, EmployeeId = 4, ActionDictionaryId = 1, ActionValue = true },
                new Models.EmployeeEventAssignment { Id = 5, EventId = 1, EmployeeId = 1, ActionDictionaryId = 2, ActionValue = true },
                new Models.EmployeeEventAssignment { Id = 6, EventId = 1, EmployeeId = 2, ActionDictionaryId = 2, ActionValue = true },
                new Models.EmployeeEventAssignment { Id = 7, EventId = 1, EmployeeId = 3, ActionDictionaryId = 2, ActionValue = false },
                new Models.EmployeeEventAssignment { Id = 8, EventId = 1, EmployeeId = 4, ActionDictionaryId = 2, ActionValue = true },
                new Models.EmployeeEventAssignment { Id = 9, EventId = 1, EmployeeId = 1, ActionDictionaryId = 3, ActionValue = false },
                new Models.EmployeeEventAssignment { Id = 10, EventId = 1, EmployeeId = 2, ActionDictionaryId = 3, ActionValue = true },
                new Models.EmployeeEventAssignment { Id = 11, EventId = 1, EmployeeId = 3, ActionDictionaryId = 3, ActionValue = true },
                new Models.EmployeeEventAssignment { Id = 12, EventId = 1, EmployeeId = 4, ActionDictionaryId = 3, ActionValue = false },

                // Event 2
                new Models.EmployeeEventAssignment { Id = 5, EventId = 2, EmployeeId = 2, ActionDictionaryId = 1, ActionValue = true },
                new Models.EmployeeEventAssignment { Id = 6, EventId = 2, EmployeeId = 3, ActionDictionaryId = 1, ActionValue = false },
                new Models.EmployeeEventAssignment { Id = 7, EventId = 2, EmployeeId = 4, ActionDictionaryId = 1, ActionValue = true },
                new Models.EmployeeEventAssignment { Id = 8, EventId = 2, EmployeeId = 2, ActionDictionaryId = 3, ActionValue = true },
                new Models.EmployeeEventAssignment { Id = 9, EventId = 2, EmployeeId = 3, ActionDictionaryId = 3, ActionValue = false },
                new Models.EmployeeEventAssignment { Id = 10, EventId = 2, EmployeeId = 4, ActionDictionaryId = 3, ActionValue = true }
            );

            // New action
            context.ActionDictionary.AddOrUpdate(a => a.Id,
                new Models.ActionDictionary { Id = 1, Name = "Avilable" },
                new Models.ActionDictionary { Id = 2, Name = "T-Shirt" },
                new Models.ActionDictionary { Id = 3, Name = "Coach" });


            // New action assigment
            context.ActionGroups.AddOrUpdate(a => a.Id,
                // Event 1
                new Models.ActionGroup { Id = 1, EventId = 1, ActionDictionaryId = 1 },
                new Models.ActionGroup { Id = 2, EventId = 1, ActionDictionaryId = 2 },
                new Models.ActionGroup { Id = 3, EventId = 1, ActionDictionaryId = 3 },

                // Event 2
                new Models.ActionGroup { Id = 4, EventId = 2, ActionDictionaryId = 1 },
                new Models.ActionGroup { Id = 5, EventId = 2, ActionDictionaryId = 3 });

        }
    }
}
