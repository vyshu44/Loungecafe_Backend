//using Microsoft.Playwright;
//using NUnit.Framework;
//using System.Threading.Tasks;

//namespace AutomationTesting.Sections
//{
//    [TestFixture, Order(7)]  // Run after Description section
//    [NonParallelizable]

//    public class SubscriptionSectionTests : SectionTestBase
//    {
//        private async Task EnterEmail(string email)
//        {
//            var input = Page.Locator(".email-section");
//            await input.FillAsync("");
//            await input.TypeAsync(email, new() { Delay = 100 });
//        }

//        [Test, Order(1)]
//        public async Task Subscribe_WithValidEmail_ShouldShowSuccessMessage()
//        {
//            await ResetState();
//            //await ScrollTo(".subscription");

//            await EnterEmail("test@example.com");
//            await Page.ClickAsync(".subscribe-section");

//            var successLocator = Page.Locator(".successMsg").First;
//            await Assertions.Expect(successLocator).ToBeVisibleAsync(new() { Timeout = 5000 });

//            var successMsg = (await successLocator.InnerTextAsync()).Trim();
//            Assert.That(successMsg, Does.Contain("Almost finished").IgnoreCase,
//                "Success message should indicate subscription progress");
//        }

//        [Test, Order(2)]
//        public async Task Subscribe_WithInvalidEmail_ShouldShowValidationMessage()
//        {
//            await ResetState();
//            //await ScrollTo(".subscription");

//            await EnterEmail("invalidemail");
//            await Page.ClickAsync(".subscribe-section");

//            var errorLocator = Page.Locator(".message");
//            await Assertions.Expect(errorLocator).ToContainTextAsync(
//                "valid email address",
//                new() { Timeout = 5000 }
//            );
//        }

//        [Test, Order(3)]
//        public async Task Subscribe_WithEmptyEmail_ShouldShowErrorMessage()
//        {
//            await ResetState();
//            //await ScrollTo(".subscription");

//            // Try clicking subscribe without entering email
//            await Page.ClickAsync("button.subscribe-section");

//            var input = Page.Locator(".email-section");

//            // Browser-native validation
//            bool isValid = await input.EvaluateAsync<bool>("el => el.checkValidity()");
//            Assert.False(isValid, "Expected email input to be invalid when empty");

//            string validationMsg = await input.EvaluateAsync<string>("el => el.validationMessage");
//            TestContext.WriteLine($"Browser validation message: {validationMsg}");

//            Assert.That(validationMsg, Does.Contain("Please fill out this field")
//                .Or.Contain("Please enter an email").IgnoreCase);
//        }
//    }
//}
