using FluentAssertions;
using GoogleMapsTests.Common.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsTests.PageObjects.MainPage
{
    public class MainPageActions : MainPageLocators
    {
        IWebDriver _driver;

        public MainPageActions(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void OpenMainPage()
        {
            _driver.Navigate().GoToUrl("https://www.google.pl/maps/");
        }

        public void AcceptCookies()
        {
            WaitForAction.WaitUntilElementClickable(_driver, AcceptCookiesButton);
            AcceptCookiesButton.Displayed.Should().BeTrue();
            AcceptCookiesButton.Click();
        }

        public void DecelineChromeInstallButtonClick()
        {
            DecelineChromeInstallButton.Displayed.Should().BeTrue();
            DecelineChromeInstallButton.Click();
        }

        public void ClickOnRouteButton()
        {
            RouteButton.Displayed.Should().BeTrue();
            RouteButton.Click();
        }

        public void SelectTripOnFoot()
        {
            OnFootButton.Displayed.Should().BeTrue();
            OnFootButton.Click();
        }

        public void SelectBikeTrip()
        {
            ByBicycleButton.Displayed.Should().BeTrue();
            ByBicycleButton.Click();
        }

        public void EnterStartingPoint(string address)
        {
            WaitForAction.WaitUntilElementExists(_driver, By.XPath("//div[@class='gstl_51 sbib_a']//input[@class='tactile-searchbox-input']"));
            FirstPlaceDirectionRouteTextbox.Displayed.Should().BeTrue();
            FirstPlaceDirectionRouteTextbox.Click();
            FirstPlaceDirectionRouteTextbox.Clear();
            FirstPlaceDirectionRouteTextbox.SendKeys(address);
        }

        public void EnterDestination(string address)
        {
            WaitForAction.WaitUntilElementExists(_driver, By.XPath("//div[@class='gstl_52 sbib_a']//input[@class='tactile-searchbox-input']"));
            SecondPlaceDirectionRouteTextbox.Displayed.Should().BeTrue();
            SecondPlaceDirectionRouteTextbox.Click();
            SecondPlaceDirectionRouteTextbox.Clear();
            SecondPlaceDirectionRouteTextbox.SendKeys(address);
        }

        public void ClickOnSearchIcon()
        {
            SecondPlaceDirectionRouteTextbox.Displayed.Should().BeTrue();
            Actions actions = new Actions(_driver);
            actions.MoveToElement(SecondPlaceDirectionRouteTextbox).Click().Perform();
            SearchIconHover.Displayed.Should().BeTrue();
            actions.MoveToElement(SearchIconHover).Click().Perform();
        }

        public void ClickChangeDirectoryRouteButton()
        {
            ChangeDirectionRouteButton.Displayed.Should().BeTrue();
            ChangeDirectionRouteButton.Click();
        }

        public void CheckTravelTime(int minutesLimit)
        {
            foreach (var option in CollectionToCheckMinutes)
            {
                option.Displayed.Should().BeTrue();
                var textValue = option.Text.Replace(" min", "");
                var minutesValue = Convert.ToInt32(textValue);
                minutesValue.Should().BeLessThan(minutesLimit);
                
            }
        }

        public void CheckTravelDistance(double kilometersLimit)
        {
            foreach (var option in CollectionToCheckKilometers)
            {
                option.Displayed.Should().BeTrue();
                var textValue = option.Text.Replace(" km", "");
                var kilometersValue = Convert.ToDouble(textValue);
                kilometersValue.Should().BeLessThan(kilometersLimit);
            }
        }
    }
}
