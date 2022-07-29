using System;

namespace NeToro.DAL.PaymentCard.Dto
{
    public class PaymentCardDto
    {
        public int TypeId { get; set; }

        public string CVC { get; set; }

        public string BankName { get; set; }

        public string CardHolder { get; set; }

        public string CardNumber { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
