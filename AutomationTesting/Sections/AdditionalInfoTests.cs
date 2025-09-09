//using Microsoft.Playwright;
//using NUnit.Framework;
//using System.Threading.Tasks;

//namespace AutomationTesting.Sections
//{
//    [TestFixture, Order(9)]  // Run after Footer section
//    [NonParallelizable]

//    public class AdditionalInfoSectionTests : SectionTestBase
//    {
//        [Test, Order(1)]
//        public async Task AdditionalInfo_ShouldRenderCopyright()
//        {
//            await ResetState();
//            //await ScrollTo(".additional-information");

//            var copyright = Page.Locator(".additional-information .copyright");
//            await Assertions.Expect(copyright).ToBeVisibleAsync(new() { Timeout = 10000 });

//            string text = (await copyright.InnerTextAsync()).Trim();
//            Assert.IsNotEmpty(text, "Copyright text should not be empty");
//        }

//        [Test, Order(2)]
//        public async Task AdditionalInfo_ShouldRenderDesignAndDistribution()
//        {
//            await ResetState();
//            //await ScrollTo(".additional-information");

//            var design = Page.Locator(".additional-information .styleshout .design");
//            var names = Page.Locator(".additional-information .styleshout .names");

//            var distribution = Page.Locator(".additional-information .themewagon .design");
//            var distNames = Page.Locator(".additional-information .themewagon .names");

//            await Assertions.Expect(design).ToBeVisibleAsync();
//            await Assertions.Expect(names).ToBeVisibleAsync();
//            await Assertions.Expect(distribution).ToBeVisibleAsync();
//            await Assertions.Expect(distNames).ToBeVisibleAsync();

//            string designText = (await design.InnerTextAsync()).Trim();
//            string distributionText = (await distribution.InnerTextAsync()).Trim();

//            Assert.IsNotEmpty(designText, "Design attribution should not be empty");
//            Assert.IsNotEmpty(distributionText, "Distribution attribution should not be empty");
//        }
//        [Test, Order(3)]
//        public async Task AdditionalInfo_ShouldHaveScrollToTopButton()
//        {
//            await ResetState();
//            //await ScrollTo(".additional-information");

//            var upArrow = Page.Locator(".additional-information .upArrow");
//            await Assertions.Expect(upArrow).ToBeVisibleAsync();

//            // Scroll down to simulate user scrolling
//            await Page.EvaluateAsync("() => window.scrollTo(0, document.body.scrollHeight)");

//            // Click the button
//            await upArrow.ClickAsync();

//            // ✅ Wait until page scrolls to the top
//            await Page.WaitForFunctionAsync("() => window.scrollY === 0", null, new() { Timeout = 5000 });

//            int scrollY = await Page.EvaluateAsync<int>("() => window.scrollY");
//            Assert.AreEqual(0, scrollY, "ScrollToTop button should scroll page to top");
//        }
//    }
//}
