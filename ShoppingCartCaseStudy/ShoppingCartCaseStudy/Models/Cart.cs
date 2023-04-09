using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartCaseStudy.Models
{
    /// <summary>
    /// 購物車
    /// </summary>
    public class Cart
    {
        public List<CardItem> OrderCartItems { get; private set; }

        public float SHIPPING_FEE { get; set; }

        public float TotalPrice { get { return GetTotalPrice(); } }

        public Cart()
        {
            OrderCartItems = new List<CardItem>();
            SHIPPING_FEE = 60;
        }

        public void AddOrderItems(CardItem item)
        {
            if (!InvaildMaxNum())
                return;

            // Save exist order
            var existCardItem = GetCardItem(item.Name);
            if (existCardItem != null)
            {
                InvaildMaxPurchaseQty(existCardItem.Qty + item.Qty, existCardItem.MaxPurchaseQty);
                existCardItem.AddOrder(item.Qty);
                return;
            }

            // Add order
            InvaildMaxPurchaseQty(item.Qty, item.MaxPurchaseQty);
            OrderCartItems.Add(item);
        }


        public CardItem GetCardItem(string Name)
        {
            var cardItems = OrderCartItems.Where(x => x.Name.Equals(Name));

            if (cardItems.Count() > 0)
                return cardItems.FirstOrDefault();

            return null;
        }

        private float GetTotalPrice()
        {
            float totalPrice = 0;

            foreach (var orderItem in OrderCartItems)
            {
                totalPrice += (orderItem.UnitPrice * orderItem.Qty);
            }
            totalPrice = totalPrice < 500 ? totalPrice + SHIPPING_FEE : totalPrice;

            return totalPrice;
        }

        private bool InvaildMaxNum()
        {
            if (OrderCartItems.Count() + 1 > 5)
                throw new Exception("Repeat order item over 5");

            return true;
        }

        public bool InvaildMaxPurchaseQty(int qty, int maxPurchaseQty)
        {
            if (qty > maxPurchaseQty)
                throw new Exception("Over the max purchase qty!" + $"Order:{qty}, Maximun:{maxPurchaseQty}");

            return true;
        }
    }
}
