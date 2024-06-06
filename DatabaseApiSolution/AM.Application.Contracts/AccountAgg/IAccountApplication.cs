namespace AM.Application.Contracts.AccountAgg
{
    public interface IAccountApplication
    {
        bool Register(AccountViewModel command);
        string Login(AccountViewModel command);
    }
}
