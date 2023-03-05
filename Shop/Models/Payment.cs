namespace Shop.Models
{
    public class Payment
    {
        public enum Method
        {
            COD = 1,
            ZALOPAY = 2
        }

        public enum Status
        {
            UNPAID = 1,
            PAID = 2,
            FAILED = 3
        }
    }
}
