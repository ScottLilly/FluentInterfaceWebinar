namespace Engine.DB.WithFI
{
    public interface ICanAddWhereComparator
    {
        void IsLessThan(object value);
        void IsLessThanOrEqualTo(object value);
        void IsEqualTo(object value);
        void IsGreaterThan(object value);
        void IsGreaterThanOrEqualTo(object value);
    }
}