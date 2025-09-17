

using Genovationai.TaskManagement.Core.Entities;
using Genovationai.TaskManagement.Infrastructure.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Genovationai.TaskManagement.Infrastructure.Database;

public static class DataSeeder
{
    public static async System.Threading.Tasks.Task SeedDefaultData(this IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await context.Database.EnsureCreatedAsync();


            //Seed default roles if they don't exist
            string[] roleNames = { "Admin", "Developer" };

                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

                foreach (var roleName in roleNames)
                {
                    if (!await roleManager.RoleExistsAsync(roleName))
                    {
                        await roleManager.CreateAsync(new ApplicationRole(roleName));
                    }
                }

            

            //Seed Tasks if they don't exist
            var tasks = new List<Core.Entities.Task>
                {
                new Core.Entities.Task
                    {
                        Title = "Task 1",
                        Description = "I am task 1 description"
                    },
                    new Core.Entities.Task
                    {
                        Title = "Task 2",
                        Description = "I am task 2 description"
                    },
                    new Core.Entities.Task
                    {
                        Title = "Task 3",
                        Description = "I am task 3 description"
                    },
                    new Core.Entities.Task
                    {
                        Title = "Task 4",
                        Description = "I am task 4 description"
                    },
                    new Core.Entities.Task
                    {
                        Title = "Task 5",
                        Description = "I am task 5 description"
                    },
                    new Core.Entities.Task
                    {
                        Title = "Task 6",
                        Description = "I am task 6 description"
                    },
                    new Core.Entities.Task
                    {
                        Title = "Task 7",
                        Description = "I am task 7 description"
                    },
                    new Core.Entities.Task
                    {
                        Title = "Task 8",
                        Description = "I am task 8 description",

                    }
                };
            if (!await context.TeamMembers.AnyAsync())
            {
                await context.Tasks.AddRangeAsync(tasks);
                await context.SaveChangesAsync();
            }

            // Seed TeamMembers if they don't exist
            var users = new List<TeamMember>
            {
                new Core.Entities.TeamMember
                                    {
                                        FirstName = "Yazan",
                                        LastName = "Ati"

                                    },
                                    new Core.Entities.TeamMember
                                    {
                                        FirstName = "Ahmad",
                                        LastName = "Khaleel"
                                    },
                                    new Core.Entities.TeamMember
                                    {
                                        FirstName = "Tariq",
                                        LastName = "Sameer"
                                    },
                                    new Core.Entities.TeamMember
                                    {
                                        FirstName = "Khalid",
                                        LastName = "Omar"
                                    }
            };

            while (tasks.Count > 0)
            {
                foreach (var user in users)
                {
                    if (tasks.Count == 0) break;
                    var task = tasks[0];
                    tasks.RemoveAt(0);
                    user.Tasks.Add(task);
                }
            }


            if (!await context.TeamMembers.AnyAsync())
            {
                await context.TeamMembers.AddRangeAsync(users);
                await context.SaveChangesAsync();


                int counter = 0;
                foreach (var user in users)
                {
                    var identityUser = new ApplicationUser
                    {
                        UserName = $"{user.FirstName.ToLower()}.{user.LastName.ToLower()}@genovation.ai",
                        Email = $"{user.FirstName.ToLower()}.{user.LastName.ToLower()}@genovation.ai",
                        EmailConfirmed = true,
                        LockoutEnabled = false
                    };
                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    var userCreationResult = await userManager.CreateAsync(identityUser, "P@ssword1");
                    if (userCreationResult.Succeeded)
                    {
                        if (counter % 2 == 0)
                            await userManager.AddToRoleAsync(identityUser, "Admin");
                    }
                    else
                    {
                        await userManager.AddToRoleAsync(identityUser, "Developer");
                    }

                    // Link IdentityUser to TeamMember
                    user.Id = identityUser.Id;
                    context.TeamMembers.Update(user);
                    await context.SaveChangesAsync();
                }

                counter++;
            }
        }
    }
}


