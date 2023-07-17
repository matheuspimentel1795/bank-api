using ApiUserBank.DTO;
using ApiUserBank.Models;

namespace ApiUserBank.Repositories
{
    public interface IUserBankRepository
    {
        Task<IEnumerable<UserBank>> GetAll();
        Task<UserBank> Create(UserBank userBank);
        Task<UserBank> Update(UserBank userBank);
        Task<UserBank> GetUserByAccount(int userAccount);

    }
}
