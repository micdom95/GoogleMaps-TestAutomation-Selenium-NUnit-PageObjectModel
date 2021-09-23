﻿using AventStack.ExtentReports;
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
        ExtentReports extent;
        ExtentHtmlReporter htmlReporter;
        ExtentTest test;
        string path = AppDomain.CurrentDomain.BaseDirectory;

        [OneTimeSetUp]
        public void setUpReports()
        {
            htmlReporter = new ExtentHtmlReporter(path, AventStack.ExtentReports.Reporter.Configuration.ViewStyle.Default);
            htmlReporter.Config.DocumentTitle = (@"Test reports.html");
            htmlReporter.Config.ReportName = ("Test automation for Google Maps");
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [Test]
        [TestCase(
            "Plac Defilad 1, Warszawa", 
            "Chłodna 51, Warszawa", 
            40, 
            3, 
            15, 
            3)]
        public void CheckDifferentRoutes_CheckTimeAndDistanceOnGoogleChrome_TimeAndDistanceWithProperValue(string firstAddress, string secondAddress, int onFootMinutesLimit, double onFootKilometersLimit, int byBicycleMinutesLimit, double byBicycleKilometersLimit)
        {
            try
            {
                test = extent.CreateTest("CheckDifferentRoutes_CheckTimeAndDistanceOnGoogleChrome_TimeAndDistanceWithProperValue").AssignDevice("Google Chrome");
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
                    test.Log(Status.Pass, "Test that check time and distance for current route destination");
                }
            }
            catch (Exception exception)
            {
                test.Fail(exception.StackTrace);
                test.Log(Status.Fail, exception);
            }
        }

        [Test]
        [TestCase(
            "Plac Defilad 1, Warszawa",
            "Chłodna 51, Warszawa",
            40,
            3,
            15,
            3)]
        public void CheckDifferentRoutes_CheckTimeAndDistanceOnFirefox_TimeAndDistanceWithProperValue(string firstAddress, string secondAddress, int onFootMinutesLimit, double onFootKilometersLimit, int byBicycleMinutesLimit, double byBicycleKilometersLimit)
        {
            try
            {
                test = extent.CreateTest("CheckDifferentRoutes_CheckTimeAndDistanceOnFirefox_TimeAndDistanceWithProperValue").AssignDevice("Firefox");
                using (IWebDriver _driver = DriverSetup.ReturnDriver(DriverType.FireFox))
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
                    test.Log(Status.Pass, "Test that check time and distance for current route destination");
                }
            }
            catch (Exception exception)
            {
                test.Fail(exception.StackTrace);
                test.Log(Status.Fail, exception);
            }
        }

        [OneTimeTearDown]
        public void EndReport()
        {
            extent.Flush();
        }
    }
}
