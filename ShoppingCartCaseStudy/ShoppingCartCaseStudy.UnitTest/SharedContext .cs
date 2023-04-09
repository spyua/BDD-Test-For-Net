using ShoppingCartCaseStudy.Models;
using System;

namespace ShoppingCartCaseStudy.UnitTest
{
   public class SharedContext
    {
        public Action addToCart;
        public Cart Cart { get; set; }
        public CardItem Erasier { get; set; }
        public CardItem Pencial { get; set; }
        public CardItem BluePen { get; set; }
        public CardItem Ruler { get; set; }
        public CardItem Notebook { get; set; }
        public CardItem PencilSharpener { get; set; }
    }
}
