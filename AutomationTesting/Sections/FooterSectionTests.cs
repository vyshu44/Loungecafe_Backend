//using Microsoft.Playwright;
//using NUnit.Framework;
//using System.Threading.Tasks;

//namespace AutomationTesting.Sections
//{
//    [TestFixture, Order(8)]  // Run after Subscription section
//    [NonParallelizable]

//    public class FooterSectionTests : SectionTestBase
//    {
//        [Test, Order(1)]
//        public async Task Footer_ShouldRenderLogoName()
//        {
//            await ResetState();
//            //await ScrollTo(".footer");

//            var logo = Page.Locator(".footer .logoName");
//            await Assertions.Expect(logo).ToBeVisibleAsync(new() { Timeout = 10000 });

//            string logoText = await logo.InnerTextAsync();
//            Assert.That(logoText, Is.EqualTo("Lounge."), "Footer logo text should be Lounge.");
//        }

//        [Test, Order(2)]
//        public async Task Footer_ShouldRenderSocialIcons()
//        {
//            await ResetState();
//            //await ScrollTo(".footer");

//            // Capture ANY child inside .apps (svg, i, span, etc.)
//            var icons = Page.Locator(".footer .apps *");
//            int iconCount = await icons.CountAsync();

//            TestContext.WriteLine($"Found {iconCount} social icons in footer");
//            Assert.Greater(iconCount, 0, "Expected at least one social media icon in footer");
//        }

//        [Test, Order(3)]
//        public async Task Footer_ShouldShowLocationContactAndHours()
//        {
//            await ResetState();
//            //await ScrollTo(".footer");

//            var location = Page.Locator(".footer .location .info p").First;
//            var contactEmail = Page.Locator(".footer .contacts .info p").First;
//            var contactPhone = Page.Locator(".footer .contacts .info p").Nth(1);
//            var weekDayHours = Page.Locator(".footer .openingHours .info p").First;

//            await Assertions.Expect(location).ToBeVisibleAsync(new() { Timeout = 10000 });
//            await Assertions.Expect(contactEmail).ToBeVisibleAsync();
//            await Assertions.Expect(contactPhone).ToBeVisibleAsync();
//            await Assertions.Expect(weekDayHours).ToBeVisibleAsync();

//            string locText = await location.InnerTextAsync();
//            string emailText = await contactEmail.InnerTextAsync();
//            string phoneText = await contactPhone.InnerTextAsync();
//            string hoursText = await weekDayHours.InnerTextAsync();

//            Assert.IsNotEmpty(locText, "Footer location should not be empty");
//            Assert.That(emailText, Does.Contain("@").IgnoreCase, "Footer should contain a valid email");
//            Assert.IsNotEmpty(phoneText, "Footer phone should not be empty");
//            Assert.That(hoursText, Does.Contain("Weekdays").IgnoreCase, "Footer should show opening hours");
//        }

//        [Test, Order(4)]
//        public async Task Footer_ShouldHaveBottomLine()
//        {
//            await ResetState();
//            //await ScrollTo(".footer");

//            var line = Page.Locator(".footer .lines");
//            await Assertions.Expect(line).ToBeVisibleAsync(new() { Timeout = 5000 });
//        }
//    }
//}
