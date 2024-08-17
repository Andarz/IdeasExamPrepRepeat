using IdeasTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace IdeasTests.Tests
{
	public class BaseTest
	{
		public IWebDriver driver;

		public Actions actions;

		public WebDriverWait wait;

		public LoginPage loginPage;

		public CreatePage createPage;

		public MyIdeasPage myIdeasPage;

		public ReadPage readPage;




		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			var chromeOptions = new ChromeOptions();

			chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
			chromeOptions.AddArgument("--disable-search-engine-choice-screen");

			driver = new ChromeDriver(chromeOptions);
			driver.Manage().Window.Maximize();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
			actions = new Actions(driver);
			wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

			loginPage = new LoginPage(driver);
			createPage = new CreatePage(driver);
			myIdeasPage = new MyIdeasPage(driver);
			readPage = new ReadPage(driver);

			loginPage.OpenPage();
			loginPage.PerformLogin("testuser1@abv.bg", "123456");			
		}

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
			driver.Quit();
			driver.Dispose();
		}

		private const string CharSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
		public string GenerateRandomString(int length)
		{
			var random = new Random();
			return new string(Enumerable.Range(0, length)
										.Select(_ => CharSet[random.Next(CharSet.Length)])
										.ToArray());
		}
	}
}
