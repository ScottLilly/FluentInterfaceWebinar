using System;
using System.Collections.Generic;

namespace Engine.Report.WithoutFI
{
    public class CallingClass
    {
        public void MyFunction(List<int> categoryIDsToInclude, List<int> salespersonIDsToInclude)
        {
            object report =
                ReportGenerator
                    .CreateSalesReport(DateTime.UtcNow.AddDays(-90), DateTime.UtcNow,
                                       categoryIDsToInclude, salespersonIDsToInclude,
                                       ReportGenerator.GroupingMethod.Office,
                                       ReportGenerator.SortMethod.DateAscending, 
                                       true, true);
        }
    }
}