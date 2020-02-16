namespace Engine.DB.WithFI
{
    public interface ICanTruncateTableOrAddWhereColumn
    {
        void TruncateTable();
        ICanAddWhereComparator DeleteRowsWhereColumn(string columnName);
    }
}