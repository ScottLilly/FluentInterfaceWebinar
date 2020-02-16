using System;
using System.Collections.Generic;

namespace Engine.Report.WithFI
{
    public class CallingClass
    {
        public void MyFunction()
        {
            List<int> salespeople = new List<int> {1, 3, 7};

            ICanAddSalespersonIDOrSetCategories reportStarter =
                ReportGenerator
                    .CreateSalesReport()
                    .From(DateTime.UtcNow.AddMonths(-1))
                    .To(DateTime.UtcNow)
                    .IncludeSalespersonID(23);

            foreach(int salesperson in salespeople)
            {
                reportStarter = reportStarter.IncludeSalespersonID(salesperson);
            }

            reportStarter
                .IncludeAllCategories()
                .GroupBy(ReportGenerator.GroupingMethod.Department)
                .SortBy(ReportGenerator.SortMethod.DateAscending)
                .IncludeReturnedOrders()
                .IncludeUnshippedOrders()
                .BuildReport();
        }
    }
}