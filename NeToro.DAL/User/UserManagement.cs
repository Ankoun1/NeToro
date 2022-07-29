using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using NeToro.DAL.Configuration;
using NeToro.DAL.User.Contracts;

namespace NeToro.DAL.User{

    public class UserManagement : IUserManagement
    {
        private readonly DatabaseOptions options;

        public UserManagement(IOptions<DatabaseOptions> options)
        {
            this.options = options.Value;
          
        }      

        public async Task<int> CreateUser(UserDto userDto)
        {        
            using (var conn = new SqlConnection(options.ConnectionString))
            {
                var cmd = new SqlCommand("[App].[CreateUser]", conn);
               
             
                cmd.CommandType = CommandType.StoredProcedure;
                
                // (@username, @password, @salt, @createdOn, @isDelited, @lastUpdate)
                cmd.Parameters.AddWithValue("@username", userDto.Username);                              
                cmd.Parameters.AddWithValue("@password", userDto.HashedPassword);
                cmd.Parameters.AddWithValue("@salt",userDto.Salt);           
            
                await conn.OpenAsync();
                var result = Convert.ToInt32(await cmd.ExecuteScalarAsync());

                return result;
            }
        }        
    }
}
