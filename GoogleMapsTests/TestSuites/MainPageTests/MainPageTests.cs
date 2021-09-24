using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
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
using System.IO;

namespace GoogleMapsTests.TestSuites.MainPageTests
{
    [TestFixture]
    public class MainPageTests
    {
        IWebDriver _driver; 
        ExtentReports extent;
        ExtentHtmlReporter htmlReporter;
        ExtentTest test;
        string path = AppDomain.CurrentDomain.BaseDirectory;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            htmlReporter = new ExtentHtmlReporter(path, AventStack.ExtentReports.Reporter.Configuration.ViewStyle.Default);
            htmlReporter.Config.DocumentTitle = "Test Reports.html";
            htmlReporter.Config.ReportName = "Test automation for Google Maps";
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [SetUp]
        public void SetUp()
        {
            _driver = DriverSetup.ReturnDriver(DriverType.Chrome);
        }

        [Test]
        [TestCase("Plac Defilad 1, Warszawa", "Chłodna 51, Warszawa", 40, 3, 15, 3)]
        public void GoogleMaps_CheckTimeAndDistanceForGivenRoutes(
            string firstAddress, 
            string secondAddress, 
            int onFootMinutesLimit, 
            double onFootKilometersLimit, 
            int byBicycleMinutesLimit, 
            double byBicycleKilometersLimit)
        {
            try
            {
                test = extent.CreateTest("GoogleMaps_CheckTimeAndDistanceForGivenRoutes").AssignDevice("Google Chrome");
                var mainPageActions = new MainPageActions(_driver);
                mainPageActions.OpenMainPage();
                mainPageActions.AcceptCookies();
                mainPageActions.ClickOnRouteButton();
                mainPageActions.EnterStartingPoint(firstAddress);
                mainPageActions.EnterDestination(secondAddress);
                mainPageActions.SelectTripOnFoot();
                mainPageActions.ClickOnSearchIcon();
                mainPageActions.CheckTravelTime(onFootMinutesLimit);
                mainPageActions.CheckTravelDistance(onFootKilometersLimit);
                mainPageActions.SelectBikeTrip();
                mainPageActions.CheckTravelTime(byBicycleMinutesLimit);
                mainPageActions.CheckTravelDistance(byBicycleKilometersLimit);
                test.Log(Status.Pass, "Test that check time and distance for current route destination"); 
            }
            catch (Exception exception)
            {
                test.Fail(exception.StackTrace);
                test.Log(Status.Fail, exception);
            }
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            extent.Flush();
        }
    }
}
