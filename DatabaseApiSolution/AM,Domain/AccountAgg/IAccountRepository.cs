namespace AM_Domain.AccountAgg
{
    public interface IAccountRepository
    {
        void Add(Account entity);
        Account GetAccountBy(string username);
        void SaveChanges();

    }
}
