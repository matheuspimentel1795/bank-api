using ApiUserBank.DTO;
using ApiUserBank.Models;

namespace ApiUserBank.Services
{
    public interface IUserBanksService
    {
        Task<IEnumerable<UserBankDTO>> GetAll();
        Task<UserBankDTO> Create(UserBankDTO userBank);
        Task<UserBankDTO> Update(PayloadUserBank userBank, string action);

        Task<UserBankDTO> GetUserByAccount(int userAccount);

    }
}
