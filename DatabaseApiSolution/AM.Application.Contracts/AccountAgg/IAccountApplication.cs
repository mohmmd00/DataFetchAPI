namespace AM.Application.Contracts.AccountAgg
{
    public interface IAccountApplication
    {
        void Register(AccountViewModel command);
        bool Login(AccountViewModel command);
    }
}
