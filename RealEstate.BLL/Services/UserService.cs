using RealEstate.DAL.Entities;
using System.Threading.Tasks;
using RealEstate.BLL.Interfaces;
using RealEstate.DAL.UnitOfWork;
using System;
using Common.Helpers;

namespace RealEstate.BLL.Services
{
    public class UserService: IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService (IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> GetUser(string email, string password)
        {
                var user = await _unitOfWork.Repository<User>().GetIncludingAll(u => u.Email == email);
                if (PasswordHasher.VerifyHashedPassword(user.PasswordHash, password))
                {
                    return user;
                }

            throw new NullReferenceException($"Cannot get user with {nameof(email)}: {email}.");
        }

        public void Dispose()
        {

        }

    }
}
