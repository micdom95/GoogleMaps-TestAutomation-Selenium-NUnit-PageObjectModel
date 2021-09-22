﻿using FluentAssertions;
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
            //_driver.Url.Should().Be("https://www.google.pl/maps/");
        }

        public void AcceptCookiesButtonClick()
        {
            WaitForAction.WaitUntilElementClickable(_driver, AcceptCookiesButton);
            AcceptCookiesButton.Displayed.Should().BeTrue();
            AcceptCookiesButton.Click();
        }

        public void RouteButtonClick()
        {
            RouteButton.Displayed.Should().BeTrue();
            RouteButton.Click();
        }

        public void OnFootButtonClick()
        {
            OnFootButton.Displayed.Should().BeTrue();
            OnFootButton.Click();
        }

        public void ByBicycleButtonClick()
        {
            ByBicycleButton.Displayed.Should().BeTrue();
            ByBicycleButton.Click();
        }

        public void FirstPlaceDirectionRouteTextboxInput(string address)
        {
            WaitForAction.WaitUntilElementExists(_driver, By.XPath("//div[@class='gstl_51 sbib_a']//input[@class='tactile-searchbox-input']"));
            FirstPlaceDirectionRouteTextbox.Displayed.Should().BeTrue();
            FirstPlaceDirectionRouteTextbox.Click();
            FirstPlaceDirectionRouteTextbox.Clear();
            FirstPlaceDirectionRouteTextbox.SendKeys(address);
        }

        public void SecondPlaceDirectionRouteTextboxInput(string address)
        {
            WaitForAction.WaitUntilElementExists(_driver, By.XPath("//div[@class='gstl_52 sbib_a']//input[@class='tactile-searchbox-input']"));
            SecondPlaceDirectionRouteTextbox.Displayed.Should().BeTrue();
            SecondPlaceDirectionRouteTextbox.Click();
            SecondPlaceDirectionRouteTextbox.Clear();
            SecondPlaceDirectionRouteTextbox.SendKeys(address);
        }

        public void SearchIconHoverOperations()
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(SecondPlaceDirectionRouteTextbox).Click().Perform();
            actions.MoveToElement(SearchIconHover).Click().Perform();
        }

        public void ChangeDirectoryRouteButtonClick()
        {
            ChangeDirectionRouteButton.Displayed.Should().BeTrue();
            ChangeDirectionRouteButton.Click();
        }

        public void CheckMinutesValue(int minutesLimit)
        {
            foreach (var option in CollectionToCheckMinutes)
            {
                var textValue = option.Text.Replace(" min", "");
                var minutesValue = Convert.ToInt32(textValue);
                minutesValue.Should().BeLessThan(minutesLimit);
                
            }
        }

        public void CheckKilometersValue(double kilometersLimit)
        {
            foreach (var option in CollectionToCheckKilometers)
            {
                var textValue = option.Text.Replace(" km", "");
                var kilometersValue = Convert.ToDouble(textValue);
                kilometersValue.Should().BeLessThan(kilometersLimit);
            }
        }
    }
}