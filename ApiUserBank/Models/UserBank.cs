using System.ComponentModel.DataAnnotations;

namespace ApiUserBank.Models
{
    public class UserBank
    {
        public int Id { get; set; }
    
        public int AccountNumber { get; set; }

        public Double AccountValue { get; set; }
    }
}
