using FluentAssertions;
using NUnit.Framework;
using ShoppingCartCaseStudy.Models;
using System;
using System.Linq;

namespace ShoppingCartCaseStudy.UnitTest
{
    /*
     * 1. The total of the cart is the sum of the subtotal of all the cart items plus shipping fee NTD 60
       2. A cart can only have maximum of 5 cart items at a time, if the customer try to add one more, the system would reject the request and alert the customer that which item is rejected.
       3. The quantity of the added cart item should not surpass the maximum purchase quantity of that product.
       4. Free shipping if the cart total is over 500.
     */
    public class BasicNeedsNotUseSpecFlow
    {
        private Cart Cart;
        private CardItem Erasier;
        private CardItem Pencial;
        private CardItem BluePen;
        private CardItem Ruler;
        private CardItem Notebook;
        private CardItem PencilSharpener;

        [SetUp]
        public void Setup()
        {
            Cart = new Cart();
            Erasier = new CardItem(name: "Erasiers", unitPrice: 10, maxPurchaseQty: 10);
            Pencial = new CardItem(name: "Pencial", unitPrice: 20, maxPurchaseQty: 10);
            BluePen = new CardItem(name: "BluePen", unitPrice: 30, maxPurchaseQty: 10);
            Ruler = new CardItem(name: "Ruler", unitPrice: 30, maxPurchaseQty: 10);
            Notebook = new CardItem(name: "Notebook", unitPrice: 50, maxPurchaseQty: 5);
            PencilSharpener = new CardItem(name: "PencilSharpener", unitPrice: 50, maxPurchaseQty: 5);
        }

        [Test]
        public void Test_total_should_be_the_sum_of_all_subtotals_plus_shipping_fee()
        {
            // Given 
            Erasier.Order(5);
            Pencial.Order(5);

            // When
            Add_To_Cart(Erasier, Pencial);

            // Then
            Cart.TotalPrice.Should().Be(210);
        }

        [Test]
        public void If_the_product_is_already_in_the_cart_the_quantity_should_be_added_to_the_existing_item()
        {
            // Given 
            Erasier.Order(5);

            // When
            Add_To_Cart(Erasier, Erasier);

            // Then
            Cart.OrderCartItems.Count().Should().Be(1);
            Cart.GetCardItem("Erasiers").Qty.Should().Be(10);
        }

        [Test]
        public void Test_system_should_error_given_cart_over_5_tiems()
        {
            // Given 
            Erasier.Order(1);
            Pencial.Order(1);
            BluePen.Order(1);
            Ruler.Order(1);
            Notebook.Order(1);
            PencilSharpener.Order(1);

            // When
            Action addToCart = () => { Add_To_Cart(Erasier, Pencial, BluePen, Ruler, Notebook, PencilSharpener); };

            // Then
            addToCart.Should().Throw<Exception>().WithMessage("Repeat order item over 5");

        }

        [Test]
        public void The_quantity_of_the_added_item_should_be_limited_to_the_max_purchase_quantity_of_the_product()
        {
            // Given 
            Erasier.Order(11);

            // When
            Action addToCart = () => { Add_To_Cart(Erasier); };

            // Then
            addToCart.Should().Throw<Exception>().WithMessage("Over the max purchase qty!" + $"Order:{Erasier.Qty}, Maximun:{Erasier.MaxPurchaseQty}");
        }

        private void Add_To_Cart(params CardItem[] orderItems)
        {
            foreach (var orderItem in orderItems)
            {
                Cart.AddOrderItems(orderItem);
            }
        }


    }
}