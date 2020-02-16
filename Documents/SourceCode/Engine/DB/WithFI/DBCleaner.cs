using System;
using System.Data;
using System.Data.SqlClient;

namespace Engine.DB.WithFI
{
    // LIMITED-CAPABILITY SAMPLE CODE
    // FOR DEMONSTRATION PURPOSES ONLY - NOT FOR PRODUCTION USE
    //
    // This shows how you could create a fluent interface, to perform a SQL DELETE, or TRUNCATE.
    //
    // This would prevent a developer from writing a DELETE query, 
    // and accidentally forgetting to add a WHERE condition - 
    // and deleting all the rows in the table.

    public class DBCleaner : ICanSetDatabase, ICanSetUserAccount, ICanSetUserPassword,
                             ICanSetTableName, ICanTruncateTableOrAddWhereColumn, ICanAddWhereComparator
    {
        private enum Comparator
        {
            IsEqualTo,
            IsLessThan,
            IsLessThanOrEqualTo,
            IsGreaterThan,
            IsGreaterThanOrEqualTo
        }

        private readonly string _dbServerName;
        private string _dbDatabaseName;
        private string _tableName;
        private string _dbUserName;
        private string _dbUserPassword;
        private bool _useTrustedConnection;
        private string _columnName;
        private Comparator _comparisonMethod;
        private object _comparisonValue;

        private DBCleaner(string serverName)
        {
            _dbServerName = serverName;
        }

        // Instantiating function(s)
        // These are static factories

        public static ICanSetDatabase OnServer(string serverName)
        {
            return new DBCleaner(serverName);
        }

        // Chaining function(s)
        public ICanSetUserAccount InDatabase(string databaseName)
        {
            _dbDatabaseName = databaseName;
            return this;
        }

        public ICanTruncateTableOrAddWhereColumn InTable(string tableName)
        {
            _tableName = tableName;
            return this;
        }

        public ICanSetTableName UsingTrustedConnection()
        {
            _useTrustedConnection = true;
            return this;
        }

        public ICanSetUserPassword UsingUserNamed(string userName)
        {
            _dbUserName = userName;
            return this;
        }

        public ICanSetTableName WithPasswordOf(string password)
        {
            _dbUserPassword = password;
            return this;
        }

        public ICanAddWhereComparator DeleteRowsWhereColumn(string columnName)
        {
            _columnName = columnName;
            return this;
        }

        // Ending function(s)
        // These perform an action, and return a result (or void)
        public void IsEqualTo(object value)
        {
            _comparisonMethod = Comparator.IsEqualTo;
            _comparisonValue = value;

            BuildAndExecuteQuery();
        }

        public void IsGreaterThan(object value)
        {
            _comparisonMethod = Comparator.IsGreaterThan;
            _comparisonValue = value;

            BuildAndExecuteQuery();
        }

        public void IsGreaterThanOrEqualTo(object value)
        {
            _comparisonMethod = Comparator.IsGreaterThanOrEqualTo;
            _comparisonValue = value;

            BuildAndExecuteQuery();
        }

        public void IsLessThan(object value)
        {
            _comparisonMethod = Comparator.IsLessThan;
            _comparisonValue = value;

            BuildAndExecuteQuery();
        }

        public void IsLessThanOrEqualTo(object value)
        {
            _comparisonMethod = Comparator.IsLessThanOrEqualTo;
            _comparisonValue = value;

            BuildAndExecuteQuery();
        }

        public void TruncateTable()
        {
            BuildAndExecuteTruncateQuery();
        }

        // Private functions
        private void BuildAndExecuteQuery()
        {
            using(SqlConnection connection = new SqlConnection(BuildConnectionString()))
            {
                connection.Open();

                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = $"DELETE * FROM {_tableName} WHERE {_columnName} {ComparisonSymbol()} @ComparisonValue";

                    command.Parameters.AddWithValue("@ComparisonValue", _comparisonValue);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void BuildAndExecuteTruncateQuery()
        {
            using(SqlConnection connection = new SqlConnection(BuildConnectionString()))
            {
                connection.Open();

                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = $"TRUNCATE TABLE {_tableName}";

                    command.ExecuteNonQuery();
                }
            }
        }

        private string BuildConnectionString()
        {
            return _useTrustedConnection
                       ? $"Data Source=({_dbServerName});Initial Catalog={_dbDatabaseName};Integrated Security=True"
                       : $"Data Source=({_dbServerName});Initial Catalog={_dbDatabaseName};User Id={_dbUserName};Password={_dbUserPassword}";
        }

        private string ComparisonSymbol()
        {
            switch(_comparisonMethod)
            {
                case Comparator.IsEqualTo:
                    return "=";
                case Comparator.IsGreaterThan:
                    return ">";
                case Comparator.IsGreaterThanOrEqualTo:
                    return ">=";
                case Comparator.IsLessThan:
                    return "<";
                case Comparator.IsLessThanOrEqualTo:
                    return "<=";
            }

            throw new ArgumentException("Invalid comparator value");
        }
    }
}