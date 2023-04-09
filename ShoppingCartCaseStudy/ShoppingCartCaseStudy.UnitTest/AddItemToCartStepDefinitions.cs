using FluentAssertions;
using ShoppingCartCaseStudy.Models;
using System;
using TechTalk.SpecFlow;

namespace ShoppingCartCaseStudy.UnitTest
{
    [Binding]
    public class AddItemToCartStepDefinitions
    {
        private readonly SharedContext _sharedContext;

        public AddItemToCartStepDefinitions(SharedContext sharedContext)
        {
            _sharedContext = sharedContext;
        }

        [BeforeScenario]
        public void Setup()
        {
            _sharedContext.Cart = new Cart();
            _sharedContext.Erasier = new CardItem(name: "Erasiers", unitPrice: 10, maxPurchaseQty: 10);
            _sharedContext.Pencial = new CardItem(name: "Pencial", unitPrice: 20, maxPurchaseQty: 10);
            _sharedContext.BluePen = new CardItem(name: "BluePen", unitPrice: 30, maxPurchaseQty: 10);
            _sharedContext.Ruler = new CardItem(name: "Ruler", unitPrice: 30, maxPurchaseQty: 10);
            _sharedContext.Notebook = new CardItem(name: "Notebook", unitPrice: 50, maxPurchaseQty: 5);
            _sharedContext.PencilSharpener = new CardItem(name: "PencilSharpener", unitPrice: 50, maxPurchaseQty: 5);
        }
        private void Add_To_Cart(params CardItem[] orderItems)
        {
            foreach (var orderItem in orderItems)
            {
                _sharedContext.Cart.AddOrderItems(orderItem);
            }
        }

        [Given(@"there are cart items")]
        public void GivenThereAreCartItems()
        {
            _sharedContext.Erasier.Order(5);
        }
        [When(@"the customer completes the order")]
        public void WhenTheCustomerCompletesTheOrder()
        {
            Add_To_Cart(_sharedContext.Erasier);
        }
        [Then(@"the total price should be the sum of the subtotal of all the cart items plus shipping fee NTD (.*)")]
        public void ThenTheTotalPriceShouldBeTheSumOfTheSubtotalOfAllTheCartItemsPlusShippingFeeNTD(int p0)
        {
            _sharedContext.Cart.TotalPrice.Should().Be(50 + 60);
        }
        //
        [Given(@"there are five items in the cart")]
        public void GivenThereAreFiveItemsInTheCart()
        {
            _sharedContext.Erasier.Order(1);
            _sharedContext.Pencial.Order(1);
            _sharedContext.BluePen.Order(1);
            _sharedContext.Ruler.Order(1);
            _sharedContext.Notebook.Order(1);
            _sharedContext.PencilSharpener.Order(1);
        }

        [When(@"the customer tries to add one more item")]
        public void WhenTheCustomerTriesToAddOneMoreItem()
        {
            _sharedContext.addToCart = () => { Add_To_Cart(_sharedContext.Erasier
                                                            , _sharedContext.Pencial
                                                            , _sharedContext.BluePen
                                                            , _sharedContext.Ruler
                                                            , _sharedContext.Notebook
                                                            , _sharedContext.PencilSharpener); };
        }
        [Then(@"the system should alert the customer not to do so and indicate which item cannot be added")]
        public void ThenTheSystemShouldAlertTheCustomerNotToDoSoAndIndicateWhichItemCannotBeAdded()
        {
            _sharedContext.addToCart.Should().Throw<Exception>().WithMessage("Repeat order item over 5");
        }
        //
        [Given(@"the customer has added a quantity of items to the cart")]
        public void GivenTheCustomerHasAddedAQuantityOfItemsToTheCart()
        {
            _sharedContext.Erasier.Order(11);
        }

        [When(@"the quantity of items exceeds the purchase limit")]
        public void WhenTheQuantityOfItemsExceedsThePurchaseLimit()
        {
            _sharedContext.addToCart = () => { Add_To_Cart(_sharedContext.Erasier); };
        }

        [Then(@"the system should alert the customer and indicate that the item has reached its purchase limit")]
        public void ThenTheSystemShouldAlertTheCustomerAndIndicateThatTheItemHasReachedItsPurchaseLimit()
        {
            _sharedContext.addToCart.Should().Throw<Exception>().WithMessage("Over the max purchase qty!" + $"Order:{_sharedContext.Erasier.Qty}, Maximun:{_sharedContext.Erasier.MaxPurchaseQty}");
        }
        //

        [Given(@"the customer selects the cart items")]
        public void GivenTheCustomerSelectsTheCartItems()
        {
            _sharedContext.BluePen.Order(10);
            _sharedContext.Ruler.Order(10);
        }
        [When(@"the total price is over (.*)")]
        public void WhenTheTotalPriceIsOver(int p0)
        {
            Add_To_Cart(_sharedContext.BluePen, _sharedContext.Ruler);
        }

        [Then(@"the customer should receive free shipping")]
        public void ThenTheCustomerShouldReceiveFreeShipping()
        {
            _sharedContext.Cart.TotalPrice.Should().Be(600);
        }

    }
}
