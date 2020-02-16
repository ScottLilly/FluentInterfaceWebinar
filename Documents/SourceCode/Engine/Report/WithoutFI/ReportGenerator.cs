using System;
using System.Collections.Generic;

namespace Engine.Report.WithoutFI
{
    public class ReportGenerator
    {
        #region Enums

        public enum GroupingMethod
        {
            None,
            Salesperson,
            Office,
            Department
        }

        public enum SortMethod
        {
            DateAscending,
            DateDescending,
            OrderTotalAscending,
            OrderTotalDescending
        }

        #endregion

        public static object CreateSalesReport(
            DateTime startDate, DateTime endDate,
            List<int> categoryIDsToInclude, List<int> salespersonIDsToInclude,
            GroupingMethod groupBy, SortMethod sortBy,
            bool includeReturnedOrders = true, bool includeUnshippedOrders = false)
        {
            // Imaginary report-generating code goes here
            return new object();
        }

        #region Other versions

        public static object CreateSalesReportForAllCategories(
            DateTime startDate, DateTime endDate,
            List<int> salespersonIDsToInclude,
            GroupingMethod groupBy, SortMethod sortBy,
            bool includeReturnedOrders = true, bool includeUnshippedOrders = false)
        {
            // Imaginary report-generating code goes here
            return new object();
        }

        public static object CreateSalesReportForAllSalespeople(
            DateTime startDate, DateTime endDate,
            List<int> categoryIDsToInclude,
            GroupingMethod groupBy, SortMethod sortBy,
            bool includeReturnedOrders = true, bool includeUnshippedOrders = false)
        {
            // Imaginary report-generating code goes here
            return new object();
        }

        public static object CreateSalesReportForAllCategoriesAndAllSalespeople(
            DateTime startDate, DateTime endDate,
            GroupingMethod groupBy, SortMethod sortBy,
            bool includeReturnedOrders = true, bool includeUnshippedOrders = false)
        {
            // Imaginary report-generating code goes here
            return new object();
        }

        #endregion
    }
}