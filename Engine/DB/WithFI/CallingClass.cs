using System;

namespace Engine.DB.WithFI
{
    public class CallingClass
    {
        public void DeleteAccountsThatHaveNotLoggedInForOneYear()
        {
            DBCleaner
                .OnServer("(local)")
                .InDatabase("MyDatabase")
                .UsingUserNamed("MyUserId")
                .WithPasswordOf("MyUserPassword")
                .InTable("Account")
               .DeleteRowsWhereColumn("LastLoginDate")
                .IsLessThan(DateTime.UtcNow.AddYears(-1));
        }

        public void DeleteAllAccounts()
        {
            DBCleaner
                .OnServer("MyServerName")
                .InDatabase("MyDatabase")
                .UsingTrustedConnection()
                .InTable("Account")
                .TruncateTable();
        }
    }
}