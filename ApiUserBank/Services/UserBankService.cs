using ApiUserBank.DTO;
using ApiUserBank.Models;
using ApiUserBank.Repositories;
using AutoMapper;

namespace ApiUserBank.Services
{
    public class UserBankService : IUserBanksService
    {
        private readonly IUserBankRepository _userBankRepository;
        private readonly IMapper _mapper;

        public UserBankService(IUserBankRepository userBankRepository, IMapper mapper)
        {
            _userBankRepository = userBankRepository;
            _mapper = mapper;
        }
        public async Task<UserBankDTO> Create(UserBankDTO userBank)
        {
            var userBankEntity = _mapper.Map<UserBank>(userBank);
            await _userBankRepository.Create(userBankEntity);
            return userBank;
        }

        public async Task<IEnumerable<UserBankDTO>> GetAll()
        {
            
                var userBank = await _userBankRepository.GetAll();
              
                return _mapper.Map<IEnumerable<UserBankDTO>>(userBank);

        }

        public async Task<UserBankDTO> GetUserByAccount(int userAccount)
        {
            var checkAccount = await _userBankRepository.GetUserByAccount(userAccount);
            return _mapper.Map<UserBankDTO>(checkAccount);
        }

        public async Task<UserBankDTO> Update(PayloadUserBank userBank, string action)
        {
            var checkAccount = await _userBankRepository.GetUserByAccount(userBank.Conta);
            if (action.Equals("Sacar"))
            {
                var saldo = checkAccount.AccountValue - userBank.Valor;
                checkAccount.AccountValue = saldo;
                checkAccount.Id = checkAccount.Id;
                
            }
            else
            {
                var saldo = checkAccount.AccountValue + userBank.Valor;
                checkAccount.AccountValue = saldo;
                checkAccount.Id = checkAccount.Id;
            }
            // var userBankEntity = _mapper.Map<UserBank>(checkAccount);
            await _userBankRepository.Update(checkAccount);
            return _mapper.Map<UserBankDTO>(checkAccount); 
        }


    }
}
