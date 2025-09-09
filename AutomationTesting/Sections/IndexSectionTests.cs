//using Microsoft.Playwright;
//using NUnit.Framework;
//using System.Threading.Tasks;

//namespace AutomationTesting.Sections
//{
//    [TestFixture, Order(1)]
//    [NonParallelizable]
//    public class IndexSectionTests : SectionTestBase
//    {
//        [Test, Order(1)]
//        public async Task Index_ShouldRenderNavLinks()
//        {
//            var navLinks = Page.Locator(".navbar .nav-links li a");
//            await Assertions.Expect(navLinks).ToHaveCountAsync(4); // adjust if backend returns dynamic links
//        }

//        [Test, Order(2)]
//        public async Task Index_ClickNavLink_ShouldScrollToAbout()
//        {
//            var aboutLink = Page.Locator(".nav-links a", new() { HasTextString = "About" });
//            await aboutLink.ClickAsync();

//            // Wait until section is close to top (allowing for sticky header)
//            await Page.WaitForFunctionAsync(@"() => {
//        const el = document.querySelector('#about');
//        if (!el) return false;
//        const rect = el.getBoundingClientRect();
//        return rect.top >= 0 && rect.top <= 120;
//    }");

//            var aboutYAfter = await Page.EvaluateAsync<int>(
//                "() => document.querySelector('#about').getBoundingClientRect().top"
//            );

//            // ✅ Flexible assertion (not LessOrEqual anymore)
//            Assert.That(aboutYAfter, Is.InRange(0, 120),
//    $"Clicking About should bring section into viewport (got {aboutYAfter})");

//        }

//        [Test, Order(3)]
//        public async Task Index_ShouldShowPhoneNumber()
//        {
//            var phoneButton = Page.Locator(".phone .call-button");
//            await Assertions.Expect(phoneButton).ToHaveTextAsync("555-123-3456");
//            var href = await phoneButton.GetAttributeAsync("href");
//            Assert.AreEqual("tel:5551233456", href, "Phone button should be clickable with tel: link");
//        }
//    }
//}
