using Npgsql;

namespace PostgreSQL.Models
{
    public class AccountDbOptions
    {
        public string Host { get; set; }
        public string Database { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ApplicationName { get; set; }
        public int? Port { get; set; }
        public int? MaximumPoolSize { get; set; }

        public string ConnectionString
        {
            get
            {
                var builder = new NpgsqlConnectionStringBuilder
                {
                    Host = Host,
                    Database = Database,
                    ApplicationName = ApplicationName,
                };

                if (!string.IsNullOrEmpty(Username)) builder.Username = Username;
                if (!string.IsNullOrEmpty(Password)) builder.Password = Password;

                if (Port.HasValue) builder.Port = Port.Value;
                if (MaximumPoolSize.HasValue) builder.MaxPoolSize = MaximumPoolSize.Value;

                return builder.ConnectionString;
            }
        }
    }
}