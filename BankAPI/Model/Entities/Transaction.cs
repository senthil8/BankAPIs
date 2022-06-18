using BankAPI.Model.Validators;
using System.ComponentModel.DataAnnotations;

namespace BankAPI.Model.Entities
{
    public class Transaction
    {
        readonly Random random = new Random();
        public Transaction()
        {
            TransactionId = Convert.ToString(random.NextInt64()); ;
            TransactionDate = DateTime.Now;
        }

        public string TransactionId { get; }

        [Required(ErrorMessage = "TransactionType should not empty")]
        [ValidEnumValue]
        public TransType TransactionType { get; set; }

        [Required(ErrorMessage = "Account id should not empty")]
        public string AccountId { get; set; }

        [Required(ErrorMessage = "Amount should not empty")]
        [ValidateAmount("TransactionType", ErrorMessage = "Not a valid")]
        public decimal TransactionAmount { get; set; }
        public DateTime TransactionDate { get; }
    }

    //Validate the basic amount validation
    public class ValidateAmountAttribute : ValidationAttribute
    {
        private readonly string _transTypeProperty;

        public ValidateAmountAttribute(string comparisonProperty)
        {
            _transTypeProperty = comparisonProperty;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(_transTypeProperty);
            if (property == null)
            {
                ErrorMessage = "Not valid property";
                return new ValidationResult(ErrorMessage);
            }

            var transValue = (TransType)property.GetValue(validationContext.ObjectInstance);

            if (transValue == TransType.Deposit)
            {
                if (! (1 <= (decimal)value && (decimal)value <= 10000))
                {
                    ErrorMessage = "Deposit amount shoud be grater than $0 and less than $10000 ";
                    return new ValidationResult(ErrorMessage);
                }
            }
            if (transValue == TransType.Withdraw)
            {
                if ((decimal)value <= 0)
                {
                    ErrorMessage = "Withdraw amount shoud be greatr than $0 ";
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }

    public enum TransType
    {
        Deposit,
        Withdraw
    }
}
