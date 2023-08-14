using Microsoft.AspNetCore.Identity;
using PurityPlus.Database;
using PurityPlus.Database.Entity;
using PurityPlus.Database.Repository;
using PurityPlus.Server.Contracts;
using System.Data;

namespace PurityPlus.Server.Services
{
    public class AccountService : IAccountService
    {

        private readonly UserManager<ApplicationUser> _userManager;

        public AccountService(UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public IUnitOfWork _unitOfWork { get; }
        public async Task<string[]> GetUserRolesByUserEmail(string email)
        {

            if (string.IsNullOrEmpty(email)) throw new ArgumentNullException("email");

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new Exception("User not found for the email");
            }

            var roles = await _userManager.GetRolesAsync(user);

            return roles.ToArray();
        }
        public async Task<ApplicationUser> LoginAsync(string email, string password)
        {
            var repo = _unitOfWork.GetRepository<ApplicationUser>();

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, password))
            {
                throw new Exception("Invalid username or password.");
            }
            return user;
        }
        public async Task RegisterAsync(string email, string password)
        {
            try
            {
                var user = await ValidateAndRegister(email, password);
                await _userManager.AddToRoleAsync(user, ApplicationRoles.customer.ToString());
            }
            catch
            {
                throw;
            }
        }
        public async Task RegisterWithRolesAsync(string email, string password, string role)
        {
            if (!Validator.ValidateRole(role))
            {
                throw new Exception("Invalid value for role");
            }

            var user = await ValidateAndRegister(email, password);
            await AddUserToRole(user, role);
        }
        private async Task AddUserToRole(ApplicationUser user, string role)
        {
            await _userManager.AddToRoleAsync(user, role);
        }
        private async Task<ApplicationUser> ValidateAndRegister(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                throw new Exception("Email already exists.");
            }
            var newUser = new ApplicationUser { Email = email, UserName = Guid.NewGuid().ToString(), Name = email.Split('@')[0] };
            var result = await _userManager.CreateAsync(newUser, password);

            if (!result.Succeeded)
            {
                throw new Exception($"Registration Failed for the user:{email}");
            }

            return await _userManager.FindByEmailAsync(email);
        }
    }
}
