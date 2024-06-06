using System.Security.Cryptography;
using AM.Application.Contracts.AccountAgg;
using AM_Domain.AccountAgg;

namespace AM.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IAccountRepository _repository;

        public AccountApplication(IAccountRepository repository)
        {
            _repository = repository;
        }

        private void CreatePasswordHash(string password, out byte[] passwordhash, out byte[] passwordsalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordsalt = hmac.Key;
                passwordhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifiedPasswordHash(string password, byte[] hash, byte[] salt)
        {
            using (var hmac = new HMACSHA512(salt))
            {
                var computedhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedhash.SequenceEqual(hash);
            }
        }


        public bool Register(AccountViewModel command)
        {
            bool operation = false;
            var chosenuser = _repository.GetAccountBy(command.UserName);


            if (chosenuser == null)
            {
                operation = true;


                CreatePasswordHash(command.Password, out byte[] passwordhash, out byte[] passwordsalt);
                var newaccount = new Account(command.UserName, passwordhash, passwordsalt);

                _repository.Add(newaccount);
                _repository.SaveChanges();

                return operation;
            }
            else
            {
                return operation;
            }

        }

        public bool Login(AccountViewModel command)
        {
            bool operation = false;
            var chosenuser = _repository.GetAccountBy(command.UserName);

            if (chosenuser == null)
            {
                return operation;
            }

            if (!VerifiedPasswordHash(command.Password, chosenuser.PasswordHash, chosenuser.PasswordSalt))
            {
                return operation;
            }
            else
            {
                operation = true;
                return operation;
            }
        }
    }
}

