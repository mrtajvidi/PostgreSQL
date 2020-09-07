using Microsoft.EntityFrameworkCore;
using PostgreSQL.Models;
using System.Threading.Tasks;

namespace PostgreSQL.Handlers
{
    public class DvdRentalHandler
    {
        private readonly ActorContext _actorContext;

        public DvdRentalHandler(ActorContext actorContext)
        {
            _actorContext = actorContext;
        }

        public async Task<Actor> GetActorById(int id)
        {
            return await _actorContext.Actor.FirstOrDefaultAsync(x => x.ActorId == id);
        }
    }
}