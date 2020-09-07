using System;
using System.Reflection;

namespace PostgreSQL.Query.Repositories
{
    public class GetActorByIdResponse
    {

        public int ActorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LastUpdate { get; set; }

    }
}