using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication5.Models;

namespace WebApplication5.ViewModels
{
    public class ProductViewModel:System.ComponentModel.INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Product product;

        public ProductViewModel()
        {
            this.product = new Product();
        }
        [Key]
        public int ProductID
        {
            get => this.product.ProductID;

            set
            {
                this.product.ProductID = value;
                if (this.PropertyChanged != null)  this.PropertyChanged(this, new PropertyChangedEventArgs("ProductID"));
                
            }
        }

        [Required]
        [MaxLength(50)]
        public string Name {
            get => this.product.Name;
            set
            {
                this.product.Name = value;
                if (this.PropertyChanged != null) this.PropertyChanged(this, new PropertyChangedEventArgs("Name"));
                }
        }

        [Required]
        public decimal Price {
            get => this.product.Price;
            set
            {
                this.product.Price = value;
                if (this.PropertyChanged != null) this.PropertyChanged(this, new PropertyChangedEventArgs("Price"));
            }
        }

        [Required]
        public short QuantityOnHand {
            get => this.product.QuantityOnHand;
            set
            {
                this.product.QuantityOnHand = value;
                if (this.PropertyChanged != null) this.PropertyChanged(this, new PropertyChangedEventArgs("QuantityOnHand"));
            }
        }

        [Required]
        public DateTime ExpiresOn {
            get => this.product.ExpiresOn;
            set
            {
                this.product.ExpiresOn = value;
                if (this.PropertyChanged != null) this.PropertyChanged(this, new PropertyChangedEventArgs("ExpiresOn"));
            }
        }
                
        public bool IsInStock {
            get => this.product.IsInStock;
            set
            {
                this.product.IsInStock = value;
                if (this.PropertyChanged != null) this.PropertyChanged(this, new PropertyChangedEventArgs("IsInStock"));
            }
        }
    }
}