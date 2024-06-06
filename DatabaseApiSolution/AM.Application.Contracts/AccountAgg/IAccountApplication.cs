namespace AM.Application.Contracts.AccountAgg
{
    public interface IAccountApplication
    {
        bool Register(AccountViewModel command);
        bool Login(AccountViewModel command);
    }
}
