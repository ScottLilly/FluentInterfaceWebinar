namespace Engine.DB.WithFI
{
    public interface ICanSetUserPassword
    {
        ICanSetTableName WithPasswordOf(string password);
    }
}