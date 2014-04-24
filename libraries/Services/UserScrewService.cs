
using Data.Repository.Base;
using Model;
using Services.Contracts;
namespace Services
{
    public class UserScrewService : IUserScrewService
    {
        private readonly IRepository<UserScrew> userScrewRepository;
        public UserScrewService(IRepository<UserScrew> userScrewRepository)
        {
            this.userScrewRepository = userScrewRepository;
        }
    }
}
