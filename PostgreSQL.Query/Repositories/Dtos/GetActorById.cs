using System;
using System.Collections.Generic;
using System.Text;

namespace PostgreSQL.Query.Repositories.Dtos
{
    public class GetActorById
    {
        public int actor_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public DateTime last_update { get; set; }
    }
}
