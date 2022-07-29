using Microsoft.Extensions.Options;
using NeToro.DAL.Configuration;
using NeToro.DAL.PaymentCard.Contracts;
using NeToro.DAL.PaymentCard.Dto;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace NeToro.DAL.PaymentCard
{
    public class PaymentCardManagement : IPaymentCardManagment
    {
        private readonly DatabaseOptions options;

        public PaymentCardManagement(IOptions<DatabaseOptions> options)
        {
            this.options = options.Value;
        }
        public async Task<int> ExecuteCreatePaymentCardSP(PaymentCardDto dto, int userId)
        {
            int result = 0;

            using (var connection = new SqlConnection(options.ConnectionString))
            {
                var cmd = new SqlCommand("App.[CreatePaymentCard]", connection);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@TypeId", dto.TypeId);
                cmd.Parameters.AddWithValue("@CVC", dto.CVC);
                cmd.Parameters.AddWithValue("@BankName", dto.BankName);
                cmd.Parameters.AddWithValue("@CardHolder", dto.CardHolder);
                cmd.Parameters.AddWithValue("@CardNumber", dto.CardNumber);
                cmd.Parameters.AddWithValue("@ExpirationDate", dto.ExpirationDate);

                await connection.OpenAsync();
                result = Convert.ToInt32(await cmd.ExecuteScalarAsync());
            }

            return result;
        }
    }
}
