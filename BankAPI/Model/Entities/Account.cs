using BankAPI.Model.Validators;
using System.ComponentModel.DataAnnotations;

namespace BankAPI.Model.Entities
{
    public class Account
    {
        readonly Random random = new Random();
        public Account()
        {
            AccountId = Convert.ToString(random.NextInt64()); ;
            CreatedDate = DateTime.Now;
        }
        public string AccountId { get; }

        [Required(ErrorMessage = "User id should not be empty")]
        [MinLength(5,ErrorMessage ="User id should be more than 5 letters")]
        public string UserId { get; set; }

        [Required(ErrorMessage ="Account Type should not be empty")]
        [ValidEnumValue]
        public AccountType AccountType { get; set; }

        [Required(ErrorMessage = "Account Holdername should not be empty")]
        [MaxLength(50, ErrorMessage = "HolderName should be less than 50 letters")]
        public string HolderName { get; set; }

        [Required(ErrorMessage = "Amount should not be empty")]
        [Range(100, int.MaxValue, ErrorMessage = "Minimum amount should be $100")]
        public decimal Balance { get; set; }
        public DateTime CreatedDate { get; }
    }

    public enum AccountType
    {
        Savings,
        Checking
    }
}
