
using Data.Repository.Base;
using Model;
using Services.Base;
using Services.Contracts;
namespace Services
{
    public class UserScrewService : Service<UserScrew>, IUserScrewService
    {
        private readonly IRepository<UserScrew> userScrewRepository;
        public UserScrewService(IRepository<UserScrew> userScrewRepository)
            : base(userScrewRepository)
        {
            this.userScrewRepository = userScrewRepository;
        }
    }
}
