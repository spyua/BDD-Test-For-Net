using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartCaseStudy
{
    public class BaseShoppingModel
    {
        /// <summary>
        /// Product Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Unit Price
        /// </summary>
        public int UnitPrice { get; set; }
        /// <summary>
        /// Purchase Qty
        /// </summary>
        public int Qty { get; set; }
        /// <summary>
        /// Maximum Purchase Qty
        /// </summary>
        public int MaxPurchaseQty { get; set; }

    }

    public class ShoppingCart
    {
        /// <summary>
        /// shopping fee
        /// </summary>
        int shippingFee = 60;
        /// <summary>
        /// shopping cart
        /// </summary>
        private List<BaseShoppingModel> cart;
        public ShoppingCart()
        {
            cart = new List<BaseShoppingModel>();
        }

        public bool AddShoppingItem(BaseShoppingModel item)
        {
            bool AddSuccess = false;
            int maxQty = item.MaxPurchaseQty;

            //check maximum 5 item
            var distinctItems = cart.Select(x => x.Name).Distinct().ToList();
            distinctItems.Add(item.Name);
            var distinctCount = distinctItems.Distinct().Count();
            if (distinctCount <= 5)
            {
                //check maximum qty
                int totalPurchaseCount = cart.Where(x => x.Name == item.Name).Select(x => x.Qty).Sum() + item.Qty;
                if (totalPurchaseCount <= maxQty)
                {
                    cart.Add(item);
                    AddSuccess = true;
                }
                else
                {
                    AddSuccess = false;
                    Console.WriteLine($@"Item : {item.Name}, add {item.Qty}, total ={totalPurchaseCount} excessess maximum available qty (MaxPurchaseQty={item.MaxPurchaseQty})");
                }
            }
            else
            {
                AddSuccess = false;
                Console.WriteLine($@"reached the purchase limit");
            }

          
            return AddSuccess;
        }

        /// <summary>
        /// Get Total Shopping Fee
        /// </summary>
        /// <returns></returns>
        public int GetTotalShoppingFee()
        {
            var totalFee = cart.Select(x => x.UnitPrice * x.Qty).Sum();
            return (totalFee>501)? totalFee : totalFee + shippingFee;
        }

        /// <summary>
        /// Get Shopping Cart Item Total Count
        /// </summary>
        /// <param name="ItemName">Shopping Item Name</param>
        /// <returns></returns>
        public int GetItemTotalCount(string ItemName)
        {
            return cart.Where(x => x.Name == ItemName).Select(x => x.Qty).Sum();
        }
    }
}
