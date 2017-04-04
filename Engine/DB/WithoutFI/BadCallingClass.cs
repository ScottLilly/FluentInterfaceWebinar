using System.Data;
using System.Data.SqlClient;

namespace Engine.DB.WithoutFI
{
    public class BadCallingClass
    {
        private const string CONNECTION_STRING =
            "Data Source=(local);Initial Catalog=MyDatabase;Integrated Security=True";

        public void DeleteAccountsThatHaveNotLoggedInForOneYear()
        {
            using(SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "DELETE * FROM Account";

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}