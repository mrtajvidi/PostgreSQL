using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace PostgreSQL.Query.Repositories
{
    public class DvdRentalRepository
    {

        public void GetActorName()
        {
            var connString = "Host=myserver;Username=mylogin;Password=mypass;Database=mydatabase";

            using (var conn = new NpgsqlConnection())
        }
    }
}
