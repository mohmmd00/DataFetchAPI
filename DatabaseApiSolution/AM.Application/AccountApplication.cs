using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using AM.Application.Contracts.AccountAgg;
using AM_Domain.AccountAgg;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AM.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IAccountRepository _repository;
        private readonly IConfiguration _configuration;



        public AccountApplication(IAccountRepository repository , IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
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
        private string CreateToken(Account account)
        {
            List<Claim> listclaim = new List<Claim>
            {
                new Claim(ClaimTypes.Name , account.UserName)
            };

            var key = new SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: listclaim,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);


            return jwt;
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
        public string Login(AccountViewModel command)
        {
            bool operation = false;
            var chosenuser = _repository.GetAccountBy(command.UserName);


            if (chosenuser == null)
            {
                return null;
            }

            if (!VerifiedPasswordHash(command.Password, chosenuser.PasswordHash, chosenuser.PasswordSalt))
            {
                return null;
            }
            else
            {
                var Jwttoken = CreateToken(chosenuser);
                return Jwttoken;
            }
        }
    }
}

