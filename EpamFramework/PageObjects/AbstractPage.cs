using OpenQA.Selenium;

namespace EpamFramework.PageObjects
{
    public abstract class AbstractPage
    {
        protected IWebDriver driver;

        protected AbstractPage(IWebDriver driver)
        {
            this.driver = driver;
        }

    }
}
