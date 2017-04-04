using System;
using System.Collections.Generic;

namespace Engine.Report.WithFI
{
    public class ReportGenerator : ICanSetFromDate, ICanSetToDate,
        ICanSetAllOrOneSalesperson, ICanSetAllOrOneCategory,
        ICanAddSalespersonIDOrSetCategories, ICanSetGroupBy,
        ICanAddCategoryIDOrSetGroupBy, ICanSetSortBy,
        ICanSetReturnedOrdersInclusion, ICanSetUnshippedOrdersInclusion,
        ICanBuildReport
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

        private DateTime _from;
        private DateTime _to;
        private bool _includeAllSalespeople;
        private List<int> _includedSalespeopleIDs = new List<int>();
        private bool _includeAllCategories;
        private List<int> _includedCategoryIDs = new List<int>();
        private GroupingMethod _groupBy;
        private SortMethod _sortBy;
        private bool _includeReturnedOrders;
        private bool _includeUnshippedOrders;

        private ReportGenerator()
        {
        }

        // Initializing functions
        public static ICanSetFromDate CreateSalesReport()
        {
            return new ReportGenerator();
        }

        // Chaining functions
        public ICanSetToDate From(DateTime from)
        {
            _from = from;
            return this;
        }

        public ICanSetAllOrOneSalesperson To(DateTime to)
        {
            _to = to;
            return this;
        }

        public ICanSetAllOrOneCategory IncludeAllSalespeople()
        {
            _includeAllSalespeople = true;
            return this;
        }

        public ICanAddSalespersonIDOrSetCategories IncludeSalespersonID(int id)
        {
            _includedSalespeopleIDs.Add(id);
            return this;
        }

        public ICanSetGroupBy IncludeAllCategories()
        {
            _includeAllCategories = true;
            return this;
        }

        public ICanAddCategoryIDOrSetGroupBy IncludeCategoryID(int id)
        {
            _includedCategoryIDs.Add(id);
            return this;
        }

        public ICanSetSortBy GroupBy(GroupingMethod groupBy)
        {
            _groupBy = groupBy;
            return this;
        }

        public ICanSetReturnedOrdersInclusion SortBy(SortMethod sortBy)
        {
            _sortBy = sortBy;
            return this;
        }

        public ICanSetUnshippedOrdersInclusion IncludeReturnedOrders()
        {
            _includeReturnedOrders = true;
            return this;
        }

        public ICanSetUnshippedOrdersInclusion ExcludeReturnedOrders()
        {
            _includeReturnedOrders = false;
            return this;
        }

        public ICanBuildReport IncludeUnshippedOrders()
        {
            _includeUnshippedOrders = true;
            return this;
        }

        public ICanBuildReport ExcludeUnshippedOrders()
        {
            _includeUnshippedOrders = false;
            return this;
        }

        // Ending functions
        public object BuildReport()
        {
            // This would have the report-generating code here.
            return new object();
        }

    }

    public interface ICanSetFromDate
    {
        ICanSetToDate From(DateTime from);
    }

    public interface ICanSetToDate
    {
        ICanSetAllOrOneSalesperson To(DateTime to);
    }

    public interface ICanSetAllOrOneSalesperson
    {
        ICanSetAllOrOneCategory IncludeAllSalespeople();
        ICanAddSalespersonIDOrSetCategories IncludeSalespersonID(int id);
    }

    public interface ICanSetAllOrOneCategory
    {
        ICanSetGroupBy IncludeAllCategories();
        ICanAddCategoryIDOrSetGroupBy IncludeCategoryID(int id);
    }

    public interface ICanAddSalespersonIDOrSetCategories
    {
        ICanAddSalespersonIDOrSetCategories IncludeSalespersonID(int id);
        ICanSetGroupBy IncludeAllCategories();
        ICanAddCategoryIDOrSetGroupBy IncludeCategoryID(int id);
    }

    public interface ICanSetGroupBy
    {
        ICanSetSortBy GroupBy(ReportGenerator.GroupingMethod groupBy);
    }

    public interface ICanAddCategoryIDOrSetGroupBy
    {
        ICanAddCategoryIDOrSetGroupBy IncludeCategoryID(int id);
        ICanSetSortBy GroupBy(ReportGenerator.GroupingMethod groupBy);
    }

    public interface ICanSetSortBy
    {
        ICanSetReturnedOrdersInclusion SortBy(ReportGenerator.SortMethod sortBy);
    }

    public interface ICanSetReturnedOrdersInclusion
    {
        ICanSetUnshippedOrdersInclusion IncludeReturnedOrders();
        ICanSetUnshippedOrdersInclusion ExcludeReturnedOrders();
    }

    public interface ICanSetUnshippedOrdersInclusion
    {
        ICanBuildReport IncludeUnshippedOrders();
        ICanBuildReport ExcludeUnshippedOrders();
    }

    public interface ICanBuildReport
    {
        object BuildReport();
    }
}