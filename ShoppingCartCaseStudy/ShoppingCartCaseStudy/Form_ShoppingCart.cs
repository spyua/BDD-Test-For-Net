using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoppingCartCaseStudy
{
    public partial class Form_ShoppingCart : Form
    {
        List<BaseShoppingModel> AvailableShoppingList;
        public Form_ShoppingCart()
        {
            InitializeComponent();
            AvailableShoppingList = new List<BaseShoppingModel>();
            AvailableShoppingList.Add(new BaseShoppingModel()
            {
                Name="Erase",
                UnitPrice = 20,
                MaxPurchaseQty = 10
            });
            AvailableShoppingList.Add(new BaseShoppingModel()
            {
                Name = "Pencil",
                UnitPrice = 20,
                MaxPurchaseQty = 10
            });
            AvailableShoppingList.Add(new BaseShoppingModel()
            {
                Name = "Blue Pen",
                UnitPrice = 30,
                MaxPurchaseQty = 10
            });
            AvailableShoppingList.Add(new BaseShoppingModel()
            {
                Name = "Ruler",
                UnitPrice = 35,
                MaxPurchaseQty = 10
            });
            AvailableShoppingList.Add(new BaseShoppingModel()
            {
                Name = "Notebook",
                UnitPrice = 50,
                MaxPurchaseQty = 5
            });
            AvailableShoppingList.Add(new BaseShoppingModel()
            {
                Name = "Pencil Sharpener",
                UnitPrice = 200,
                MaxPurchaseQty = 2
            });
            AvailableShoppingList.Add(new BaseShoppingModel()
            {
                Name = "Computer Mouse",
                UnitPrice = 500,
                MaxPurchaseQty = 1
            });
            AvailableShoppingList.Add(new BaseShoppingModel()
            {
                Name = "Keyboard",
                UnitPrice = 800,
                MaxPurchaseQty = 1
            });
            dgv_ShoppingCart.DataSource = AvailableShoppingList;
        }
    }
}
