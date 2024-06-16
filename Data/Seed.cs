namespace JobSearchApplication.Data
{
    using JobSearchApplication.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Linq;

    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDBContext>();

                context.Database.EnsureCreated();
                if (!context.Roles.Any())
                {
                    context.Roles.AddRange(
                        new Role { Name = "Пошукач роботи" },
                        new Role { Name = "Роботодавець" }
                    );

                    context.SaveChanges();
                }

                if (!context.Locations.Any())
                {
                    context.Locations.AddRange(
                        new Location { Title = "Київ" },
                        new Location { Title = "Львів" },
                        new Location { Title = "Одеса" },
                        new Location { Title = "Дніпро" },
                        new Location { Title = "Харків" },
                        new Location { Title = "Віддалена" }
                    );

                    context.SaveChanges();
                }

                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(
                        new Category { Title = "Інформаційні технології" },
                        new Category { Title = "Фінанси" },
                        new Category { Title = "Маркетинг" },
                        new Category { Title = "Освіта" },
                        new Category { Title = "Охорона здоров'я" }
                    );

                    context.SaveChanges();
                }

                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User { Email = "jobseeker1@example.com", Password = "password", RoleId = 1 },
                        new User { Email = "jobseeker2@example.com", Password = "password", RoleId = 1 },
                        new User { Email = "employer1@example.com", Password = "password", RoleId = 2 },
                        new User { Email = "employer2@example.com", Password = "password", RoleId = 2 }
                    );

                    context.SaveChanges();
                }

                if (!context.Jobseekers.Any())
                {
                    context.Jobseekers.AddRange(
                        new Jobseeker { UserId = context.Users.First(u => u.Email == "jobseeker1@example.com").Id, FullName = "Іван Іванов", PhoneNumber = "123456789" },
                        new Jobseeker { UserId = context.Users.First(u => u.Email == "jobseeker2@example.com").Id, FullName = "Марія Петрівна", PhoneNumber = "987654321" }
                    );

                    context.SaveChanges();
                }

                if (!context.Employers.Any())
                {
                    context.Employers.AddRange(
                        new Employer { UserId = context.Users.First(u => u.Email == "employer1@example.com").Id, CompanyName = "Компанія 1", CompanyDescription = "Опис компанії 1", Number = "111222333", EmployeeCount = 50, Address = "Адреса 1" },
                        new Employer { UserId = context.Users.First(u => u.Email == "employer2@example.com").Id, CompanyName = "Компанія 2", CompanyDescription = "Опис компанії 2", Number = "444555666", EmployeeCount = 100, Address = "Адреса 2" }
                    );

                    context.SaveChanges();
                }

                if (!context.Resumes.Any())
                {
                    context.Resumes.AddRange(
                        new Resume { Title = "Резюме 1", Content = "Зміст резюме 1", CreatedAt = DateTime.Now.ToUniversalTime(), Experience = "3 роки", LocationId = context.Locations.First(l => l.Title == "Київ").Id, Skills = "C#, SQL", Education = "Вища освіта", CategoryId = context.Categories.First(c => c.Title == "Інформаційні технології").Id, JobseekerId = context.Jobseekers.First(js => js.FullName == "Марія Петрівна").Id },
                        new Resume { Title = "Резюме 2", Content = "Зміст резюме 2", CreatedAt = DateTime.Now.ToUniversalTime(), Experience = "5 років", LocationId = context.Locations.First(l => l.Title == "Львів").Id, Skills = "Java, Python", Education = "Вища освіта", CategoryId = context.Categories.First(c => c.Title == "Фінанси").Id, JobseekerId = context.Jobseekers.First(js => js.FullName == "Іван Іванов").Id }
                    );

                    context.SaveChanges();
                }

                if (!context.Jobs.Any())
                {
                    context.Jobs.AddRange(
                        new Job { Jobs = "Розробник ПЗ", Description = "Опис роботи для розробника ПЗ", PostedDate = DateTime.Now.ToUniversalTime(), LocationId = context.Locations.First(l => l.Title == "Київ").Id, MinExperience = 3, Salary = 30000, CategoryId = context.Categories.First(c => c.Title == "Інформаційні технології").Id, EmployerId = context.Employers.First(e => e.CompanyName == "Компанія 1").Id },
                        new Job { Jobs = "Фінансовий аналітик", Description = "Опис роботи для фінансового аналітика", PostedDate = DateTime.Now.ToUniversalTime(), LocationId = context.Locations.First(l => l.Title == "Львів").Id, MinExperience = 2, Salary = 25000, CategoryId = context.Categories.First(c => c.Title == "Фінанси").Id, EmployerId = context.Employers.First(e => e.CompanyName == "Компанія 2").Id }
                    );

                    context.SaveChanges();
                }
                if (!context.Statuses.Any())
                {
                    context.Statuses.AddRange(
                        new Status { Name = "Розглядається" },
                        new Status { Name = "Прийнято" },
                        new Status { Name = "Відхилено" }
                    );

                    context.SaveChanges();
                }

                if (!context.Applications.Any())
                {
                    context.Applications.AddRange(
                        new Application { ResumeId = context.Resumes.First(r => r.Title == "Резюме 1").Id, JobId = context.Jobs.First(j => j.Jobs == "Розробник ПЗ").Id, RoleId = 1, StatusId = context.Statuses.First(s => s.Name == "Розглядається").Id, Comment = "Без коментарів" },
                        new Application { ResumeId = context.Resumes.First(r => r.Title == "Резюме 2").Id, JobId = context.Jobs.First(j => j.Jobs == "Фінансовий аналітик").Id, RoleId = 2, StatusId = context.Statuses.First(s => s.Name == "Прийнято").Id, Comment = "Гарний кандидат" }
                    );

                    context.SaveChanges();
                }
            }
        }
    }

}
