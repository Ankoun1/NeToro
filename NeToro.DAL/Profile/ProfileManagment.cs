using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using NeToro.DAL.Configuration;
using NeToro.DAL.Profile.Contracts;
using NeToro.DAL.Profile.Dto;

namespace NeToro.DAL.Profile
{
    public class ProfileManagment : IProfileManagment
    {
        private readonly DatabaseOptions options;

        public ProfileManagment(IOptions<DatabaseOptions> options)
        {
            this.options = options.Value;
        }

        public async Task<int> ExecuteProfile(ProfileDto profileDto,int userId)
        {
            var result = 0;

            using (var conn = new SqlConnection(options.ConnectionString))
            {
                var cmd = new SqlCommand("[App].[CreateProfile]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@FirstName", profileDto.FirstName);
                cmd.Parameters.AddWithValue("@LastName", profileDto.LastName);
                cmd.Parameters.AddWithValue("@EGN", profileDto.EGN);
                cmd.Parameters.AddWithValue("@Nationality", profileDto.Nationality);
                cmd.Parameters.AddWithValue("@Address", profileDto.Address);

                await conn.OpenAsync();
                result = Convert.ToInt32(await cmd.ExecuteScalarAsync());

                return result;
            }
        }
    }
}
