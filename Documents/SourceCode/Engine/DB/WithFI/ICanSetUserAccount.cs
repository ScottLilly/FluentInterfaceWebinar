namespace Engine.DB.WithFI
{
    public interface ICanSetUserAccount
    {
        ICanSetTableName UsingTrustedConnection();
        ICanSetUserPassword UsingUserNamed(string userName);
    }
}