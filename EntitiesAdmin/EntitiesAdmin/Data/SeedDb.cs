using EntitiesAdmin.Data.Entities;
using EntitiesAdmin.Helpers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EntitiesAdmin.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await _userHelper.CheckRoleAsync("Admin");
            await _context.SaveChangesAsync();
            await CheckUserAsync();
            await CheckStatusFieldAsync();
            await CheckCountryAsync();
            await CheckRosterAsync();
            await CheckRequestCategoryAsync();
            await CheckStatusEmployeeAsync();
            await CheckStatusRequestAsync();
            await CheckDepartmentAsync();
            await CheckSkillAsync();
            await CheckTypeRequestAsync();
            await CheckSiteAsync();
            await CheckJobPositionAsync();
            await CheckEmployeeAsync();
            await UpdateUserAsync();

        }

        private async Task UpdateUserAsync()
        {
            var user = await _userHelper.GetUserByNameAsync("Festrada");
            if (user != null)
            {
                var employee = _context.Employees.FirstOrDefault();

                user.Employee = employee;

                var result = await _userHelper.UpdateUserAsync(user);

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not update the user in seeder");
                }
            }

        }

        private async Task CheckUserAsync()
        {
            // Add user

            var user = await _userHelper.GetUserByNameAsync("Festrada");
            if (user == null)
            {
                var employee = _context.Employees.FirstOrDefault();
                user = new User
                {
                    Email = "francisco.estrada.g@hotmail.com",
                    UserName = "Festrada",
                    Employee = employee
                };

                var result = await _userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }

                await _userHelper.AddUserToRoleAsync(user, "Admin");
            }

            var isInRole = await _userHelper.IsUserInRoleAsync(user, "Admin");
            if (!isInRole)
            {
                await _userHelper.AddUserToRoleAsync(user, "Admin");
            }
        }

        private async Task CheckStatusFieldAsync()
        {
            if (!_context.StatusFields.Any())
            {
                _context.StatusFields.Add(new StatusField { Name = "Active" });
                _context.StatusFields.Add(new StatusField { Name = "Inactive" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckEmployeeAsync()
        {

            if (!_context.Employees.Any())
            {
                var jobposition = _context.JobPositions.FirstOrDefault(d => d.Name == "Administrator");
                var country = _context.Countries.FirstOrDefault(d => d.Name == "Guatemala");
                var site = _context.Sites.FirstOrDefault(d => d.Name == "Blue Tower");
                var statusemplotee = _context.StatusEmployees.FirstOrDefault(d => d.Name == "Active");
                var skill = _context.Skills.FirstOrDefault(d => d.Name == "Manager");
                AddEmployee("6853", "Cruz", "Francisco", "Estrada", "Gregorio", DateTime.Now.AddYears(-3), jobposition, site, statusemplotee, skill, country);
                await _context.SaveChangesAsync();
            }
        }

        private void AddEmployee(string employeecode, string firstname, string middlename, string firstsurname, string secondsurname, DateTime hiredate, JobPosition jobposition, Site site, StatusEmployee statusemplotee, Skill skill, Country country)
        {
            _context.Employees.Add(new Employee
            {
                EmployeeCode = employeecode,
                FirstName = firstname,
                MiddleName = middlename,
                FirstSurname = firstsurname,
                SecondSurname = secondsurname,
                HireDate = hiredate,
                JobPosition = jobposition,
                Site = site,
                StatusEmployee = statusemplotee,
                Skill = skill,
                Country = country
            });
        }

        private async Task CheckJobPositionAsync()
        {

            if (!_context.JobPositions.Any())
            {
                var date = DateTime.Now.ToUniversalTime();
                var user = _context.Users.FirstOrDefault(u => u.UserName == "Festrada");
                var statusfield = _context.StatusFields.FirstOrDefault(s => s.Name == "Active");
                _context.JobPositions.Add(new JobPosition { Name = "Collaborator", EditionDate = date, StatusField = statusfield, User = user });
                _context.JobPositions.Add(new JobPosition { Name = "Administrator", EditionDate = date, StatusField = statusfield, User = user });
                _context.JobPositions.Add(new JobPosition { Name = "Technitian", EditionDate = date, StatusField = statusfield, User = user });
                await _context.SaveChangesAsync();
            }

        }

        private async Task CheckSiteAsync()
        {

            if (!_context.Sites.Any())
            {
                var date = DateTime.Now.ToUniversalTime();
                var user = _context.Users.FirstOrDefault(u => u.UserName == "Festrada");
                var statusfield = _context.StatusFields.FirstOrDefault(s => s.Name == "Active");
                var country = _context.Countries.FirstOrDefault();
                AddSite("Orange Tower", country, date, statusfield, user);
                AddSite("Gray Edifice", country, date, statusfield, user);
                AddSite("Blue Tower", country, date, statusfield, user);
                AddSite("Green Edifice", country, date, statusfield, user);
                await _context.SaveChangesAsync();
            }
        }

        private void AddSite(string name, Country country, DateTime date, StatusField statusfield, User user)
        {
            _context.Sites.Add(new Site
            {
                Name = name,
                Country = country,
                StatusField = statusfield,
                EditionDate = date,
                User = user
            });
        }

        private async Task CheckTypeRequestAsync()
        {

            if (!_context.TypeRequests.Any())
            {
                var date = DateTime.Now.ToUniversalTime();
                var user = _context.Users.FirstOrDefault(u => u.UserName == "Festrada");
                var statusfield = _context.StatusFields.FirstOrDefault(s => s.Name == "Active");
                var department = _context.Departments.FirstOrDefault();
                var requestcategory = _context.RequestCategories.FirstOrDefault();
                AddTypeRequest("Assets", department, requestcategory, date, statusfield, user);
                AddTypeRequest("Configurations", department, requestcategory, date, statusfield, user);
                AddTypeRequest("Purchase", department, requestcategory, date, statusfield, user);
                AddTypeRequest("New employee", department, requestcategory, date, statusfield, user);
                await _context.SaveChangesAsync();
            }
        }

        private void AddTypeRequest(string name, Department department, RequestCategory requestcategory, DateTime date, StatusField statusfield, User user)
        {
            _context.TypeRequests.Add(new TypeRequest
            {
                Name = name,
                Department = department,
                RequestCategory = requestcategory,
                StatusField = statusfield,
                EditionDate = date,
                User = user
            });
        }

        private async Task CheckSkillAsync()
        {

            if (!_context.Skills.Any())
            {
                var date = DateTime.Now.ToUniversalTime();
                var user = _context.Users.FirstOrDefault(u => u.UserName == "Festrada");
                var statusfield = _context.StatusFields.FirstOrDefault(s => s.Name == "Active");
                var department = _context.Departments.FirstOrDefault();
                AddSkill("Assistant", department, date, statusfield, user);
                AddSkill("Manager", department, date, statusfield, user);
                await _context.SaveChangesAsync();
            }
        }

        private void AddSkill(string name, Department department, DateTime date, StatusField statusfield, User user)
        {
            _context.Skills.Add(new Skill
            {
                Name = name,
                Department = department,
                StatusField = statusfield,
                EditionDate = date,
                User = user
            });
        }

        private async Task CheckDepartmentAsync()
        {

            if (!_context.Departments.Any())
            {
                var date = DateTime.Now.ToUniversalTime();
                var user = _context.Users.FirstOrDefault(u => u.UserName == "Festrada");
                var statusfield = _context.StatusFields.FirstOrDefault(s => s.Name == "Active");
                var roster = _context.Rosters.FirstOrDefault();
                AddDepartment("Accounting", roster, date, statusfield, user);
                AddDepartment("Human Resources", roster, date, statusfield, user);
                await _context.SaveChangesAsync();
            }

        }

        private void AddDepartment(string name, Roster roster, DateTime date, StatusField statusfield, User user)
        {
            _context.Departments.Add(new Department
            {
                Name = name,
                Roster = roster,
                StatusField = statusfield,
                EditionDate = date,
                User = user
            });

        }

        private async Task CheckStatusRequestAsync()
        {

            if (!_context.StatusRequest.Any())
            {
                var date = DateTime.Now.ToUniversalTime();
                var user = _context.Users.FirstOrDefault(u => u.UserName == "Festrada");
                var statusfield = _context.StatusFields.FirstOrDefault(s => s.Name == "Active");
                _context.StatusRequest.Add(new StatusRequest { Name = "Open", EditionDate = date, StatusField = statusfield, User = user });
                _context.StatusRequest.Add(new StatusRequest { Name = "In Progress", EditionDate = date, StatusField = statusfield, User = user });
                _context.StatusRequest.Add(new StatusRequest { Name = "Awaiting Reply", EditionDate = date, StatusField = statusfield, User = user });
                _context.StatusRequest.Add(new StatusRequest { Name = "Closed", EditionDate = date, StatusField = statusfield, User = user });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckStatusEmployeeAsync()
        {

            if (!_context.StatusEmployees.Any())
            {
                var date = DateTime.Now.ToUniversalTime();
                var user = _context.Users.FirstOrDefault(u => u.UserName == "Festrada");
                var statusfield = _context.StatusFields.FirstOrDefault(s => s.Name == "Active");
                _context.StatusEmployees.Add(new StatusEmployee { Name = "Active", EditionDate = date, StatusField = statusfield, User = user });
                _context.StatusEmployees.Add(new StatusEmployee { Name = "Dismiss", EditionDate = date, StatusField = statusfield, User = user });
                _context.StatusEmployees.Add(new StatusEmployee { Name = "Resignation", EditionDate = date, StatusField = statusfield, User = user });
                _context.StatusEmployees.Add(new StatusEmployee { Name = "Discontinued", EditionDate = date, StatusField = statusfield, User = user });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckCountryAsync()
        {

            if (!_context.Countries.Any())
            {
                var date = DateTime.Now.ToUniversalTime();
                var user = _context.Users.FirstOrDefault(u => u.UserName == "Festrada");
                var statusfield = _context.StatusFields.FirstOrDefault(s => s.Name == "Active");
                _context.Countries.Add(new Country { Name = "Holland", EditionDate = date, StatusField = statusfield, User = user });
                _context.Countries.Add(new Country { Name = "Guatemala", EditionDate = date, StatusField = statusfield, User = user });
                _context.Countries.Add(new Country { Name = "England", EditionDate = date, StatusField = statusfield, User = user });
                _context.Countries.Add(new Country { Name = "Italy", EditionDate = date, StatusField = statusfield, User = user });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckRequestCategoryAsync()
        {


            if (!_context.RequestCategories.Any())
            {
                var date = DateTime.Now.ToUniversalTime();
                var user = _context.Users.FirstOrDefault(u => u.UserName == "Festrada");
                var statusfield = _context.StatusFields.FirstOrDefault(s => s.Name == "Active");
                _context.RequestCategories.Add(new RequestCategory { Name = "Presential", EditionDate = date, StatusField = statusfield, User = user });
                _context.RequestCategories.Add(new RequestCategory { Name = "Remoto", EditionDate = date, StatusField = statusfield, User = user });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckRosterAsync()
        {


            if (!_context.Rosters.Any())
            {
                var date = DateTime.Now.ToUniversalTime();
                var user = _context.Users.FirstOrDefault(u => u.UserName == "Festrada");
                var statusfield = _context.StatusFields.FirstOrDefault(s => s.Name == "Active");
                _context.Rosters.Add(new Roster { Name = "Finance", EditionDate = date, StatusField = statusfield, User = user });
                _context.Rosters.Add(new Roster { Name = "Operations", EditionDate = date, StatusField = statusfield, User = user });
                _context.Rosters.Add(new Roster { Name = "IT Operations", EditionDate = date, StatusField = statusfield, User = user });
                await _context.SaveChangesAsync();
            }
        }
    }

}
