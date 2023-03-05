namespace Shop.Models
{
    public class OrderStatus
    {
        public const int New = 1;
        public const int WaitingForConfirm = 2;
        public const int Confirmed = 3;
        public const int InDelivery = 4;
        public const int Delivered = 5;
        public const int Shipped = 6;
    }
}
