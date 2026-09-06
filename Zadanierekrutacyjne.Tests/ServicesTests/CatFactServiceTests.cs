using System.Net;
using System.Net.Http.Json;
using Moq;
using Moq.Protected;
using ZadanieRekrutacyjne.Models;
using ZadanieRekrutacyjne.Services;

namespace Zadanierekrutacyjne.Tests.ServicesTests
{
    public class CatFactServiceTests
    {
        [Fact]
        public async Task GetCatFactAsync_ReturnsCatFactResponse_WhenApiCallIsSuccessful()
        {
            // Arrange
            var expectedFact = new CatFactResponse { Fact = "Cats sleep for 70% of their lives.", Length = 35 };

            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = JsonContent.Create(expectedFact)
                });

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("https://catfact.ninja/")
            };

            var service = new CatFactService(httpClient);

            // Act
            var result = await service.GetCatFactAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedFact.Fact, result.Fact);
            Assert.Equal(expectedFact.Length, result.Length);
        }
    }
}