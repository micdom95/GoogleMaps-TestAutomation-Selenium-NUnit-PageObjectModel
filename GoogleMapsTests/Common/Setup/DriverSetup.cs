using GoogleMapsTests.Common.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using Microsoft.Edge.SeleniumTools;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsTests.Common.Setup
{
    public static class DriverSetup
    {
        public static IWebDriver ReturnDriver(DriverType driverType)
        {
            IWebDriver _driver;
            switch (driverType)
            {
                case DriverType.Chrome:
                    ChromeOptions chromeOptions = new ChromeOptions
                    {
                        AcceptInsecureCertificates = true,
                        PageLoadStrategy = PageLoadStrategy.Normal
                    };
                    chromeOptions.AddArgument("--start-maximized");

                    _driver = new ChromeDriver(chromeOptions);
                    break;

                case DriverType.FireFox:
                    _driver = new FirefoxDriver();
                    break;

                case DriverType.Edge:
                    var edgeOptions = new EdgeOptions()
                    {
                        AcceptInsecureCertificates = true,
                        PageLoadStrategy = PageLoadStrategy.Normal,
                    };
                    edgeOptions.UseChromium = true;
                    
                    _driver = new EdgeDriver(AppDomain.CurrentDomain.BaseDirectory, edgeOptions);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(driverType), driverType, null);
            }
            return _driver;
        }
    }
}
