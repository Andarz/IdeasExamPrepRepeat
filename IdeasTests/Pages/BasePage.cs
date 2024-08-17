using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeasTests.Pages
{
	public class BasePage
	{
        protected IWebDriver driver;

		public string BaseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:83";
		public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
	}
}
