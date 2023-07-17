using ApiUserBank.Context;
using ApiUserBank.DTO;
using ApiUserBank.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiUserBank.Repositories
{
    public class UserBankRepository : IUserBankRepository
    {
        private readonly AppDbContext _context;
        public UserBankRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<UserBank> Create(UserBank userBank)
        {
            _context.UserBank.Add(userBank);
            await _context.SaveChangesAsync();
            return userBank;
        }


        public async Task<IEnumerable<UserBank>> GetAll()
        {
            return await _context.UserBank.ToListAsync();
        }

        public async Task<UserBank> Update(UserBank userBank)
        {
            _context.Entry(userBank).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return userBank;
        }
        public async Task<UserBank> GetUserByAccount(int userAccount)
        {
            return await _context.UserBank.Where(c => c.AccountNumber == userAccount).FirstOrDefaultAsync();
        }

       
    }
}
