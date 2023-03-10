using System;
using System.Collections.Generic;

#nullable disable

namespace Shop.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string OrderId { get; set; }
        public int UserId { get; set; }
        public double TotalPrice { get; set; }
        public DateTime CreateAt { get; set; }
        public int? VoucherId { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }
        public string PaymentMethod { get; set; }
        public int? PaymentStatus { get; set; }
        public string PaymentDetail { get; set; }

        public virtual User User { get; set; }
        public virtual Voucher Voucher { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public bool IsOpen()
        {
            return Status.Equals(OrderStatus.New);
        }

        public bool IsCOD()
        {
            return PaymentMethod.Equals(Payment.Method.COD.ToString());
        }

        public bool IsPaid()
        {
            return PaymentStatus.Equals(Payment.Status.PAID);
        }

        public string StatusText
        {
            get
            {
                switch (Status)
                {
                    case OrderStatus.WaitingForConfirm: return "Chờ xác nhận";
                    case OrderStatus.Confirmed: return "Đã xác nhận";
                    case OrderStatus.InDelivery: return "Đang giao hàng";
                    case OrderStatus.Shipped: return "Đã giao hàng";
                    default: return "Chờ xác nhận";
                }
            }
        }
    }
}
