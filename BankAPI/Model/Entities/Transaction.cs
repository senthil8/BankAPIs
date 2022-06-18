using System.ComponentModel.DataAnnotations;

namespace BankAPI.Model.Entities
{
    public class Transaction
    {
        Random random = new Random();
        public Transaction()
        {
            TransactionId = Convert.ToString(random.NextInt64()); ;
            TransactionDate = DateTime.Now;
        }
        public string TransactionId { get;  }
        [Required]
        public TransType TransactionType { get; set; }
        [Required(ErrorMessage = "Account id should not empty")]
        public string AccountId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public decimal TransactionAmount { get; set; }       
        public DateTime TransactionDate { get;  }
  
    }

    public enum TransType
    {
        Deposit,
        Withdraw
    }
}
