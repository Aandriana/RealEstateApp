using Common.Configuration;
using Microsoft.AspNetCore.Http;
using RealEstate.BLL.Interfaces;

namespace RealEstate.BLL.Services
{
    public class AuthenticateService: IAuthenticateService
    {
        private readonly TokenManagement _tokenManagement;
        private readonly IHttpContextAccessor _context;

        public AuthenticateService(TokenManagement tokenManagement, IHttpContextAccessor context)
        {
            _tokenManagement = tokenManagement;
            _context = context;
        }


    }
}
