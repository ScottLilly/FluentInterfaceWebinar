using System;
using System.Collections.Generic;

namespace Engine.Report.WithFI
{
    public class CallingClass
    {
        public void MyFunction()
        {
            var reportStarter =
                ReportGenerator
                .CreateSalesReport()
                .From(DateTime.UtcNow.AddMonths(-1))
                .To(DateTime.UtcNow)
                .IncludeSalespersonID(23)
                .IncludeSalespersonID(45)
                .IncludeAllCategories()
                .GroupBy(ReportGenerator.GroupingMethod.Department)
                .SortBy(ReportGenerator.SortMethod.DateAscending)
                .IncludeReturnedOrders()
                .IncludeUnshippedOrders()
                .BuildReport();
        }
    }
}
