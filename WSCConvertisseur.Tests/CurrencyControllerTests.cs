using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSCConvertisseur.Controllers;
using WSCConvertisseur.Models;
using Xunit;

namespace WSCConvertisseur.Controllers.Tests
{
    public class CurrencyControllerTests
    {
        private readonly CurrencyController controller;

        public CurrencyControllerTests()
        {
            controller = new CurrencyController();
        }

        [Fact]
        public void GetAll_ReturnsRightItems()
        {
            var result = controller.GetAll();

            var currencies = Assert.IsAssignableFrom<IEnumerable<Currency>>(result);
            var list = currencies.ToList();

            Assert.Equal(3, list.Count);

            Assert.Contains(new Currency(1, "Dollar", 1.08), list);
            Assert.Contains(new Currency(2, "Swiss Franc", 1.07), list);
            Assert.Contains(new Currency(3, "Yen", 120), list);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            var result = controller.GetById(1);

            var actionResult = Assert.IsType<ActionResult<Currency>>(result);

            Assert.Null(actionResult.Result);
            Assert.IsType<Currency>(actionResult.Value);

            Assert.Equal(
                new Currency(1, "Dollar", 1.08),
                actionResult.Value
            );
        }

        [Fact]
        public void GetById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            var result = controller.GetById(999);

            var actionResult = Assert.IsType<ActionResult<Currency>>(result);

            Assert.IsType<NotFoundResult>(actionResult.Result);
            Assert.Null(actionResult.Value);
        }

        [Fact]
        public void Post_ValidObjectPassed_ReturnsObject()
        {
            var newCurrency = new Currency(4, "Pound", 0.85);

            var result = controller.Post(newCurrency);

            var actionResult = Assert.IsType<ActionResult<Currency>>(result);
            var createdResult = Assert.IsType<CreatedAtRouteResult>(actionResult.Result);

            Assert.Equal(
                StatusCodes.Status201Created,
                createdResult.StatusCode
            );

            Assert.Equal(newCurrency, createdResult.Value);
        }

        [Fact]
        public void Post_InvalidObjectPassed_ModelValidationIsNotTriggered()
        {
            var invalidCurrency = new Currency(4, null, 4.0);

            var result = controller.Post(invalidCurrency);

            var actionResult = Assert.IsType<ActionResult<Currency>>(result);
            var createdResult = Assert.IsType<CreatedAtRouteResult>(actionResult.Result);

            Assert.Equal(
                StatusCodes.Status201Created,
                createdResult.StatusCode
            );
        }

        [Fact]
        public void Put_ValidUpdate_ReturnsNoContent()
        {
            var updatedCurrency =
                new Currency(1, "Dollar Updated", 1.10);

            var result = controller.Put(1, updatedCurrency);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Put_IdDoesNotMatch_ReturnsBadRequest()
        {
            var currency =
                new Currency(1, "Dollar", 1.08);

            var result = controller.Put(99, currency);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void Put_CurrencyDoesNotExist_ReturnsNotFound()
        {
            var currency =
                new Currency(999, "Unknown", 1.0);

            var result = controller.Put(999, currency);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Delete_ExistingId_ReturnsDeletedCurrency()
        {
            var result = controller.Delete(1);

            var actionResult =
                Assert.IsType<ActionResult<Currency>>(result);

            Assert.Null(actionResult.Result);

            Assert.Equal(
                new Currency(1, "Dollar", 1.08),
                actionResult.Value
            );
        }

        [Fact]
        public void Delete_UnknownId_ReturnsNotFound()
        {
            var result = controller.Delete(999);

            var actionResult =
                Assert.IsType<ActionResult<Currency>>(result);

            Assert.IsType<NotFoundResult>(actionResult.Result);
            Assert.Null(actionResult.Value);
        }
    }
}