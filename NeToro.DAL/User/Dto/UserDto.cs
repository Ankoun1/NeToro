namespace NeToro.DAL.User
{
    public class UserDto
    {
        public string Username { get; set; }

        public string HashedPassword { get; set; }

        public string Salt { get; set; }
    }
}
