using GoogleMapsTests.Common.Enums;
using GoogleMapsTests.Common.Setup;
using GoogleMapsTests.PageObjects.MainPage;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoogleMapsTests.TestSuites.MainPageTests
{
    [TestFixture]
    public class MainPageTests
    {
        [Test]
        [TestCase(
            "Plac Defilad 1, " +
            "Warszawa", 
            "Chłodna 51, " +
            "Warszawa", 
            40, 
            3, 
            15, 
            3)]
        public void OpenMainPage_PageOpenedProperly(
            string firstAddress, 
            string secondAddress, 
            int onFootMinutesLimit, 
            double onFootKilometersLimit, 
            int byBicycleMinutesLimit, 
            double byBicycleKilometersLimit)
        {
            using (IWebDriver _driver = DriverSetup.ReturnDriver(DriverType.Chrome))
            {
                var mainPageActions = new MainPageActions(_driver);
                mainPageActions.OpenMainPage();
                mainPageActions.AcceptCookiesButtonClick();
                mainPageActions.RouteButtonClick();
                mainPageActions.FirstPlaceDirectionRouteTextboxInput(firstAddress);
                mainPageActions.SecondPlaceDirectionRouteTextboxInput(secondAddress);
                mainPageActions.OnFootButtonClick();
                mainPageActions.SearchIconHoverOperations();
                mainPageActions.CheckMinutesValue(onFootMinutesLimit);
                mainPageActions.CheckKilometersValue(onFootKilometersLimit);
                mainPageActions.ByBicycleButtonClick();
                mainPageActions.CheckMinutesValue(byBicycleMinutesLimit);
                mainPageActions.CheckKilometersValue(byBicycleKilometersLimit);
                mainPageActions.ChangeDirectoryRouteButtonClick();
                mainPageActions.CheckMinutesValue(byBicycleMinutesLimit);
                mainPageActions.CheckKilometersValue(byBicycleKilometersLimit);
                mainPageActions.OnFootButtonClick();
                mainPageActions.CheckMinutesValue(onFootMinutesLimit);
                mainPageActions.CheckKilometersValue(onFootKilometersLimit);
            }
        }
    }
}
