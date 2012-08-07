namespace TanksterCommand.Controllers.Api
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Http;
    using System.Web.Script.Serialization;
    using Models;

    public class LeaderboardController : ApiController
    {
        [Queryable(ResultLimit = 10)]
        public IQueryable<Profile> Get()
        {
            TanksterContext context = new TanksterContext();
            return context.Profiles;
        }
    }
}