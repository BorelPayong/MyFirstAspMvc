using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstAspMvc.service
{
    public class Sql
    {
        public string ConnectionString { get; private set; }

        private DbProviderFactory Factory;

        public Sql(string connectionStringName)
        {
            ConnectionString = ConfigurationManager.
                ConnectionStrings[connectionStringName].ConnectionString;
            string providerName = ConfigurationManager.
                ConnectionStrings[connectionStringName].ProviderName;

            Factory = DbProviderFactories.GetFactory(providerName);
        }

        public void Execute(string commandText, IEnumerable<Sql.Paramater> paramaters )
        {
            using (var com = Factory.CreateConnection())
            {
                com.ConnectionString = ConnectionString;
                com.Open();

                using(var command = Factory.CreateCommand())
                {
                    command.Connection = com;
                    command.CommandText = commandText;

                    if (paramaters != null)
                    {
                        foreach(var p in paramaters)
                        {
                            var param = Factory.CreateParameter();
                            param.ParameterName = p.Name;
                            param.Value = p.Value;
                            param.DbType = p.Type;
                            command.Parameters.Add(param);
                        }
                    }
                    command.ExecuteNonQuery();
                }
            }
        }

        public DbDataReader Read(string query, IEnumerable<Sql.Paramater> paramaters, bool isStoredProcedure = true)
        {
            var com = Factory.CreateConnection();
            com.ConnectionString = ConnectionString;
            com.Open();
            var command = Factory.CreateCommand();
            command.Connection = com;
            command.CommandText = query;
            if (isStoredProcedure)
                command.CommandType = CommandType.StoredProcedure;
            if (paramaters != null)
            {
                foreach (var p in paramaters)
                {
                    var param = Factory.CreateParameter();

                    param.ParameterName = p.Name;
                    param.Value = p.Value;
                    param.DbType = p.Type;

                    command.Parameters.Add(param);
                }
            }
            return command.ExecuteReader(CommandBehavior.CloseConnection); // fermeture du reader  ferme la connection
        }

        public class Paramater
        {
            public string Name { get; set; }
            public object Value { get; set; }
            public DbType Type { get; set; }

            public Paramater(string name, object value, DbType type)
            {
                Name = name;
                Value = value;
                Type = type;
            }
        }

    }
}
