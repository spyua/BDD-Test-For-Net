namespace ShoppingCartCaseStudy.Models
{
    /// <summary>
    /// 產品
    /// </summary>
    public class CardItem
    {
        public string Name { get; private set; }

        public float UnitPrice { get; private set; }

        public int Qty { get; private set; }

        public int MaxPurchaseQty { get; private set; }

        public float SubTotal { get { return Qty * UnitPrice; } }
        public CardItem()
        {

        }
        public CardItem(string name, float unitPrice, int maxPurchaseQty, int qty = 0)
        {
            Name = name;
            UnitPrice = unitPrice;
            Qty = qty;
            MaxPurchaseQty = maxPurchaseQty;
        }

        public void Order(int qty)
        {
            Qty = qty;
        }

        public void AddOrder(int qty)
        {
            Qty += qty;
        }

        // DDD Test 方法預留
        //private bool InvaildMaxPurchaseQty(int qty)
        //{
        //    if (Qty + qty > MaxPurchaseQty)
        //        throw new Exception("Over the max purchase qty:" + MaxPurchaseQty);

        //    return true;
        //}
    }
}