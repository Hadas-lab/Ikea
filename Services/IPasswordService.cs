namespace Services
{
    public interface IPasswordService
    {
        Task<int> passwordScore(string password);
    }
}