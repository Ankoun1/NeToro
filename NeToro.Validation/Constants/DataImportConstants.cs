namespace NeToro.Validation.Constants
{
    public static class DataImportConstants
    {
        public class UserConst
        {
            public const int MinLengthUsername = 3;
            public const int MaxLengthUsername = 20;
            public const int MinLengthPassword = 5;
            public const int MaxLengthPassword = 30;            
        }
        public class PaymentCardConst
        {
            //public const int LengthCVC = 3;
            public const string ValidatePaternCVC = @"^[0-9]{3}";
            public const int MinLengthBankName = 2;
            public const int MaxLengthBankName = 30;
            public const int MinLengthCardHolder = 2;
            public const int MaxLengthCardHolder = 20;   
            public const int MinLengthCardNumber = 11;
            public const int MaxLengthCardNumber = 16;            
        }
    }
}
