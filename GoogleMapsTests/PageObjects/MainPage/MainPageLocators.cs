using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsTests.PageObjects.MainPage
{
    public class MainPageLocators
    {
        IWebDriver _driver;

        public MainPageLocators(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement AcceptCookiesButton => _driver.FindElement(By.XPath("//button[@class='VfPpkd-LgbsSe VfPpkd-LgbsSe-OWXEXe-k8QpJ VfPpkd-LgbsSe-OWXEXe-dgl2Hf nCP5yc AjY5Oe DuMIQc']"));

        public IWebElement RouteButton => _driver.FindElement(By.XPath("//img[@class='searchbox-directions-icon']"));

        public IWebElement ChangeDirectionRouteButton => _driver.FindElement(By.XPath("//div[@class='widget-directions-icon reverse']"));

        public IWebElement DecelineChromeInstallButton => _driver.FindElement(By.XPath("//button[@aria-label='NIE TERAZ']"));

        public IWebElement OnFootButton => _driver.FindElement(By.XPath("//img[@aria-label='Pieszo']"));

        public IWebElement ByBicycleButton => _driver.FindElement(By.XPath("//img[@aria-label='Na rowerze']"));

        public IWebElement FirstPlaceDirectionRouteTextbox => _driver.FindElement(By.XPath("//div[@id='directions-searchbox-0']//input[@class='tactile-searchbox-input']"));

        public IWebElement SecondPlaceDirectionRouteTextbox => _driver.FindElement(By.XPath("//div[@id='directions-searchbox-1']//input[@class='tactile-searchbox-input']"));

        public IWebElement SearchIconHover => _driver.FindElement(By.XPath("//div[@id='directions-searchbox-1']//button[@aria-label='Szukaj']"));

        public IWebElement RouteOptionsContainer => _driver.FindElement(By.XPath("//div[@role='main']//div[@class='section-layout']"));

        public IList<IWebElement> CollectionToCheckMinutes => RouteOptionsContainer.FindElements(By.XPath("//div[contains(text(),'min')]"));

        public IList<IWebElement> CollectionToCheckKilometers => RouteOptionsContainer.FindElements(By.XPath("//div[contains(text(),'km')]"));
    }
}
