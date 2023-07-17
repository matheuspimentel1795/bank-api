using ApiUserBank.DTO;
using ApiUserBank.ENUMS;
using ApiUserBank.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace ApiUserBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserBankController : ControllerBase
    {
        private readonly IUserBanksService _userBankService;
        public UserBankController(IUserBanksService userBankService)
        {
            _userBankService = userBankService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserBankDTO>>> Get()
        {
            var userBankDto = await _userBankService.GetAll();
            if (userBankDto is null)
                return NotFound();
            return Ok(userBankDto);
        }
        [HttpPut("{typeService}")]
        public async Task<ActionResult<UserBankRes>> Put(OptionTypes typeService, [FromBody] PayloadUserBank userBankPayload)
        {
            var checkAccount = await _userBankService.GetUserByAccount(userBankPayload.Conta);
            if(checkAccount == null )
            {
                return NotFound("Conta não existe.");

            }
            if (typeService.ToString().Equals("Saldo"))
            {
                return Ok(new
                {
                    saldo = checkAccount.AccountValue
                });
            }
            if (typeService.ToString().Equals("Sacar") && checkAccount.AccountValue < userBankPayload.Valor)
            {
                return NotFound("Saldo insuficiente.");
            }
           var userBankDto =  await _userBankService.Update(userBankPayload,typeService.ToString());
            var userBankRes = new UserBankRes
            {
                Conta = userBankDto.AccountNumber,
                Saldo = userBankDto.AccountValue
            };
            return Ok(userBankRes);
        }
    }
}
