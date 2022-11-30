
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MeDirect.Driver
{
    public static class DriverControl
    {
        private static WebDriver driver = null;


        public static WebDriver DriverStart()
        {
            if (driver==null)
            {
                driver = new ChromeDriver();
            }
            return driver;
        }

        public static void DriverStop()
        {
            driver.Close();
            driver.Dispose();
        }

        public static void DriverMaximize()
        {
            driver.Manage().Window.Maximize();
        }

        public static void NavigateUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public static IWebElement FindElement(By by)
        {
            return driver.FindElement(by);
        }
        
        public static ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return driver.FindElements(by);
        }
        
        public static void SwitchToDefaultContent()
        {
            driver.SwitchTo().DefaultContent();
        }
        public static void NavigateBack()
        {
            driver.Navigate().Back();
        }


    }
}
