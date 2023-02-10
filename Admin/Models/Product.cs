using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Admin.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
            WarehouseDetails = new HashSet<WarehouseDetail>();
        }

        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Code")]
        public string ProductCode { get; set; }

        [Display(Name = "Name")]
        public string ProductName { get; set; }

        [Display(Name = "Type ID")]
        public int ProductType { get; set; }

        [Display(Name = "Color ID")]
        public int ProductColor { get; set; }

        [Display(Name = "Quantity")]
        public int ProductQuantity { get; set; }

        [Display(Name = "Brand ID")]
        public int ProductBrand { get; set; }

        [Display(Name = "Images")]
        public string ProductImage { get; set; }

        [NotMapped]
        public List<IFormFile> ProfileImage { get; set; }

        [Display(Name = "Size ID")]
        public int ProductSize { get; set; }

        [Display(Name = "Description")]
        public string ProductDescription { get; set; }

        [Display(Name = "Price")]
        public double OutPrice { get; set; }

        [Display(Name = "Status")]
        public int Status { get; set; }

        [Display(Name = "Specifications")]
        public string ProductSpec { get; set; }


        [Display(Name = "Brand")]
        public virtual Brand ProductBrandNavigation { get; set; }

        [Display(Name = "Color")]
        public virtual Color ProductColorNavigation { get; set; }

        [Display(Name = "Size")]
        public virtual Size ProductSizeNavigation { get; set; }

        [Display(Name = "Type")]
        public virtual Type ProductTypeNavigation { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<WarehouseDetail> WarehouseDetails { get; set; }

        
    }
}
