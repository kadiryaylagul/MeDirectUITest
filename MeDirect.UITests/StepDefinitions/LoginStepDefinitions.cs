using MeDirect.PageMethods;
using MeDirect.PageModels;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace MeDirect.UITests.StepBindings
{
    [Binding]

    public class Login : Hooks
    {
        LoginPage loginpage = new LoginPage();


        [Given(@"User navigates to login page")]
        public void NavigatesToLoginPage()
        {
            loginpage.NavigatesToLoginPage();
        }

        [When(@"User enters valid credentials '(.*)' and '(.*)'")]
        public void SetPasswordAndUsername(string username, string password)
        {
            loginpage.SetPasswordAndUsername(username, password);
        }

        [Then(@"User should be able to login")]
        public void CheckValidLogin()
        {
            loginpage.CheckValidLogin();
        }

        [When(@"User enters invalid credentials '(.*)' and '(.*)'")]
        public void SetInvalidCredentials(string username, string password)
        {
            loginpage.SetPasswordAndUsername(username, password);
        }

        [Then(@"User should not be able to login")]
        public void CheckInvalidLogin()
        {
            loginpage.CheckInvalidLogin();
        }

        [Then(@"User should be able to see the item names are different from product details")]
        public void CheckItemsNamesWithFalseCondition()
        {
            loginpage.CheckItemsNamesWithFalseCondition();
        }

        [Then(@"User should be able to see the items' images are different from product details")]
        public void CheckItemsImagesWithFalseCondition()
        {
            loginpage.CheckItemsImagesWithFalseCondition();
        }

        [Then(@"User should be able to see the items are same with product details")]
        public void CheckItemsNamesWithTrueCondition()
        {
            loginpage.CheckItemsNamesWithTrueCondition();
        }

        [When(@"User add a product")]
        public void AddProduct()
        {
            loginpage.AddProduct();

        }

        [Then(@"User should be able to purchase the product")]
        public void PurchaseProductSuccessfully()
        {
            Assert.True(loginpage.PurchaseProductSuccessfully().Equals("THANK YOU FOR YOUR ORDER")); 
        }

        [Then(@"User should not be able to login with locked user")]
        public void ThenUserShouldNotBeAbleToLoginWithLockedUser()
        {
            loginpage.CheckInvalidLoginForLockedUser(); ;
        }
    }
}
