using System;
using System.Threading.Tasks;
using RealEstate.DAL.Entities;

namespace RealEstate.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<User> GetUser(string email, string password)
    }
}
