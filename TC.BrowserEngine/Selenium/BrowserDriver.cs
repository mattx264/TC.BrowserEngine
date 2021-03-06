﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;
using TC.BrowserEngine.Helpers;
using TC.BrowserEngine.Helpers.Enums;

namespace TC.BrowserEngine.Selenium
{
    public class BrowserDriver
    {
        private readonly BrowserType _browserType;
        private readonly string _browserVersion;
        private readonly IWebDriver _driver;
     

        public BrowserDriver(BrowserType browserType)
        {
            _browserType = browserType;
            var path = FileHelper.GetRootPath();

            if (browserType == BrowserType.Chrome)
            {
                var co = new ChromeOptions();
                co.PageLoadStrategy = PageLoadStrategy.Eager;
                co.AddArguments("start-maximized");           


                //TODO get dynamic way to get version wmic datafile where name="C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe" get Version /value
                _browserVersion = "88";
                _driver = new ChromeDriver($"{path}/BrowserDrivers/Chrome/{_browserVersion}", co);

            } else if(browserType== BrowserType.Firefox)
            {
                _browserVersion = "0.24";
                _driver = new FirefoxDriver($"{path}/BrowserDrivers/Firefox/{_browserVersion}");
            }

        }    
        public IWebDriver GetDriver()
        {
            return _driver;
        }
    }
}
