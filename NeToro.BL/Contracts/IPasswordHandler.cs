namespace NeToro.BL.Contracts
{
    public interface IPasswordHandler
    {
        (string password, string salt) GeneratorPassword(string salt,string password);
    }
}
