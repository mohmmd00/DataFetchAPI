using System.Text;
using AM_Domain.AccountAgg;

namespace AM.Infrastructure.EFCore.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountContext _context;

        public AccountRepository(AccountContext context)
        {
            _context = context;
        }

        public void Add(Account entity)
        {
            _context.accounts.Add(entity);
        }

        public Account GetAccountBy(string username)
        {
            var selectedaccount = _context.accounts.FirstOrDefault(ط=>ط.UserName == username);

            if (selectedaccount == null)
            {
                return null;
            }
            else
            {
                return selectedaccount;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
