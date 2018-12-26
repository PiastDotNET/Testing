using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Shouldly;

namespace Piast.Web.Tests.UI
{
    [TestFixture]
    public class CeneoTests
    {
        [Test]
        public void Title_After_Search()
        {
            using(var driver = CreateDriver())
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("http://ceneo.pl");

                IWebElement searchFieldElement = driver
                    .FindElement(By.Name("search-query"));
                IWebElement searchButtonElement = driver
                    .FindElement(By.ClassName("header-search-form-button"));

                searchFieldElement.SendKeys("Apple macbook");
                searchButtonElement.Click();

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(x => x.Title.Contains("- Ceneo.pl", StringComparison.OrdinalIgnoreCase));

                driver.Title.ShouldBe("Apple macbook - Ceneo.pl");
            }
        }

        [Test]
        public void Title_After_Redirect_To_Category()
        {
            using(var driver = CreateDriver())
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("http://ceneo.pl");

                var categoryButtonElement = driver
                    .FindElement(By.ClassName("category-icon-470"));

                categoryButtonElement.Click();

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(x => x.Title.Contains("na Ceneo.pl", StringComparison.OrdinalIgnoreCase));

                driver.Title.ShouldBe("Gry - Ceny i opinie na Ceneo.pl");
                driver.Url.ShouldContain("/Gry");
            }
        }

        [Ignore("Not working yet")]
        [Test]
        public void Erotic_Should_Redirect_To_VerificationPage()
        {
            using(var driver = CreateDriver())
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("http://ceneo.pl");

                var categoryMenu = driver
                    .FindElement(By.Id("categories-menu"));

                var categoryButtonElement = driver
                    .FindElement(By.ClassName("category-icon-643"));

                categoryButtonElement.Click();

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(x => x.Title.Contains("- Weryfikacja", StringComparison.OrdinalIgnoreCase));

                driver.Title.ShouldBe("- Weryfikacja");
                driver.Url.ShouldContain("/StrefaDlaDoroslych%2cErotyka%2c643");
            }
        }

        private IWebDriver CreateDriver()
        {
            return new ChromeDriver("./../../../../../packages/selenium.webdriver.chromedriver/2.45.0/driver/mac64"); //change for yout operating system
        }
    }
}