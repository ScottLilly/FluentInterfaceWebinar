namespace Engine.DB.WithFI
{
    public interface ICanSetTableName
    {
        ICanTruncateTableOrAddWhereColumn InTable(string tableName);
    }
}