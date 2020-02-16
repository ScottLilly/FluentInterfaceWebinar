namespace Engine.DB.WithFI
{
    public interface ICanSetDatabase
    {
        ICanSetUserAccount InDatabase(string databaseName);
    }
}