using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects.Cart
{
    public partial class CartPage
    {
        public By AddToCartButton = By.XPath("//button[@id='add-to-cart-sauce-labs-onesie']");
        public By CartIcon = By.XPath("//a[@class='shopping_cart_link']");
        public By SortDropDown = By.XPath("//select[@class='product_sort_container']");
    }
}
