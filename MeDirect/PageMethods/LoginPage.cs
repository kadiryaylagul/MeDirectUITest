using MeDirect.Driver;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace MeDirect.PageModels
{
    public class LoginPage
    {
        public void NavigatesToLoginPage()
        {
            DriverControl.NavigateUrl("https://www.saucedemo.com/");
            Thread.Sleep(2000);
        }
        public void SetPasswordAndUsername(string username, string password)
        {
            var userName = DriverControl.FindElement(By.Id("user-name"));
            userName.SendKeys(username);
            var passwordInput = DriverControl.FindElement(By.Id("password"));
            passwordInput.SendKeys(password);
            var loginButton = DriverControl.FindElement(By.Id("login-button"));
            loginButton.Click();
        }
        public void CheckValidLogin()
        {            
            string title = DriverControl.FindElement(By.XPath("//span[@class='title']")).Text;
            Console.WriteLine(title);
            Assert.True(title.Contains("PRODUCTS"));
        }

        public void CheckInvalidLogin()
        {
            var errorMessage = "Epic sadface: Username and password do not match any user in this service";
            var actualMessage = DriverControl.FindElement(By.XPath("//div[@class='error-message-container error']")).Text;
            Console.WriteLine(actualMessage);
            Assert.True(actualMessage.Equals(errorMessage));
        }
        public void CheckInvalidLoginForLockedUser()
        {
            var errorMessage = "Epic sadface: Sorry, this user has been locked out.";
            var actualMessage = DriverControl.FindElement(By.XPath("//div[@class='error-message-container error']")).Text;
            Console.WriteLine(actualMessage);
            Assert.True(actualMessage.Equals(errorMessage));
        }
        public void CheckItemsNamesWithFalseCondition()
        {
            ReadOnlyCollection<IWebElement> displayedOptions = DriverControl.FindElements(By.XPath("//div[@class='inventory_item_name']"));
            for (int i = 0; i < displayedOptions.Count; i++)
            {
                DriverControl.SwitchToDefaultContent();
                var option = DriverControl.FindElement(By.XPath("(//div[@class='inventory_item_name'])[" + (i + 1) + "]"));
                if (option.Displayed)
                {
                    var firstProductTitle = option.Text;
                    option.Click();
                    System.Threading.Thread.Sleep(1000);
                    var ActualProductTitle = DriverControl.FindElement(By.XPath("//div[@class='inventory_details_name large_size']"));
                    Assert.False(firstProductTitle.Equals(ActualProductTitle.Text));
                    DriverControl.NavigateBack();
                    System.Threading.Thread.Sleep(2000);
                }
            }
        }
        public void CheckItemsImagesWithFalseCondition()
        {
            ReadOnlyCollection<IWebElement> displayedOptions = DriverControl.FindElements(By.XPath("//img[@class='inventory_item_img']"));
            for (int i = 0; i < displayedOptions.Count; i++)
            {
                DriverControl.SwitchToDefaultContent();
                var option = DriverControl.FindElement(By.XPath("(//img[@class='inventory_item_img'])[" + (i + 1) + "]"));
                if (option.Displayed)
                {
                    var productImage = option.GetAttribute("src");
                    option.Click();
                    Thread.Sleep(1000);
                    var ActualProductImage = DriverControl.FindElement(By.XPath("//img[@class='inventory_details_img']"));
                    Assert.False(productImage.Equals(ActualProductImage.GetAttribute("src")));
                    DriverControl.NavigateBack();
                    Thread.Sleep(2000);
                }
            }
        }
        public void CheckItemsNamesWithTrueCondition()
        {
            ReadOnlyCollection<IWebElement> displayedOptions = DriverControl.FindElements(By.XPath("//div[@class='inventory_item_name']"));
            for (int i = 0; i < displayedOptions.Count; i++)
            {
                DriverControl.SwitchToDefaultContent();
                var option = DriverControl.FindElement(By.XPath("(//div[@class='inventory_item_name'])[" + (i + 1) + "]"));
                if (option.Displayed)
                {
                    var firstProductTitle = option.Text;
                    option.Click();
                    System.Threading.Thread.Sleep(1000);
                    var ActualProductTitle = DriverControl.FindElement(By.XPath("//div[@class='inventory_details_name large_size']"));
                    Assert.True(firstProductTitle.Equals(ActualProductTitle.Text));
                    DriverControl.NavigateBack(); ;
                    System.Threading.Thread.Sleep(2000);
                }
            }
        }
        public void AddProduct()
        {
            var product = DriverControl.FindElement(By.XPath("(//div[@class='inventory_item_name'])[2]"));
            product.Click();
            var addToCart = DriverControl.FindElement(By.Id("add-to-cart-sauce-labs-bike-light"));
            addToCart.Click();

        }

        public string PurchaseProductSuccessfully()
        {
            var shoppingBadge = DriverControl.FindElement(By.XPath("//span[@class='shopping_cart_badge']"));
            shoppingBadge.Click();
            var checkout = DriverControl.FindElement(By.Id("checkout"));
            checkout.Click();
            var firstName = DriverControl.FindElement(By.Id("first-name"));
            firstName.SendKeys("Kadir");
            var lastName = DriverControl.FindElement(By.Id("last-name"));
            lastName.SendKeys("Yayla");
            var zipCode = DriverControl.FindElement(By.Id("postal-code"));
            zipCode.SendKeys("06930");
            var continuePurchase = DriverControl.FindElement(By.Id("continue"));
            continuePurchase.Click();
            var finishTransaction = DriverControl.FindElement(By.Id("finish"));
            finishTransaction.Click();
            string completePurchase = DriverControl.FindElement(By.XPath("//h2[@class='complete-header']")).Text;
            return completePurchase;

        }

    }
}
