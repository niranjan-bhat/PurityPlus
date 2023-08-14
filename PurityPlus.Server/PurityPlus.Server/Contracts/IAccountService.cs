using PurityPlus.Database.Entity;

namespace PurityPlus.Server.Contracts
{
    public interface IAccountService
    {
        Task RegisterAsync(string email, string password);
        Task RegisterWithRolesAsync(string email, string password, string role);
        Task<ApplicationUser> LoginAsync(string email, string password);
        Task<string[]> GetUserRolesByUserEmail(string email);
    }
}
