//using Microsoft.Playwright;
//using NUnit.Framework;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;

//namespace AutomationTesting.Sections
//{
//    [TestFixture, Order(4)]  // Run Menu after About
//    [NonParallelizable]

//    public class MenuSectionTests : SectionTestBase
//    {
//        [Test, Order(1)]
//        public async Task Menu_ShouldRenderHeadingAndNumber()
//        {
//            await ResetState();
//            //await ScrollTo(".menu");   // 👈 scroll into menu section

//            var heading = Page.Locator(".menu .headings").First;
//            var number = Page.Locator(".menu .numbers").First;

//            await Assertions.Expect(heading).ToBeVisibleAsync(new() { Timeout = 10000 });
//            await Assertions.Expect(number).ToBeVisibleAsync();

//            string headingText = await heading.InnerTextAsync();
//            string numberText = await number.InnerTextAsync();

//            Assert.That(headingText, Is.EqualTo("Our Menu"), "Menu heading should be 'Our Menu'");
//            Assert.That(numberText, Does.Contain("02").IgnoreCase, "Expected section number 02");
//        }

//        [Test, Order(2)]
//        public async Task Menu_ShouldDisplayCategories()
//        {
//            await ResetState();
//            //await ScrollTo(".menu");

//            var categories = Page.Locator(".menu .list-container .listss");
//            await Assertions.Expect(categories.First).ToBeVisibleAsync(new() { Timeout = 10000 });

//            int catCount = await categories.CountAsync();
//            Assert.Greater(catCount, 0, "Expected at least one category");

//            for (int i = 0; i < catCount; i++)
//            {
//                string catText = (await categories.Nth(i).InnerTextAsync()).Trim();
//                Assert.IsNotEmpty(catText, $"Category {i + 1} should not be empty");
//            }
//        }

//        [Test, Order(3)]
//        public async Task Menu_ShouldSwitchActiveCategory()
//        {
//            await ResetState();
//            //await ScrollTo(".menu");

//            var categories = Page.Locator(".menu .list-container .listss");

//            int catCount = await categories.CountAsync();
//            Assert.Greater(catCount, 1, "Need at least 2 categories to test switching");

//            // Click on second category
//            await categories.Nth(1).ClickAsync();

//            // Expect it to have 'active' class
//            await Assertions.Expect(categories.Nth(1)).ToHaveClassAsync(new Regex("active"));
//        }
//    }
//}
