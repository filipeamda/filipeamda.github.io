using Bunit;
using filipealmeida.Layout;
using filipealmeida.Models;
using filipealmeida.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace filipealmeida.Tests;

public class NavMenuTests : TestContext
{
    [Fact]
    public void NavMenu_RendersTitleAndLinkedIn_WhenDataIsLoaded()
    {
        // Arrange
        var handlerMock = new Mock<HttpMessageHandler>();
        
        var bio = new Bio("Filipe Almeida", ".NET Developer", "Summary", "https://linkedin.com/in/filipealma");

        handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req => req.RequestUri != null && req.RequestUri.ToString().Contains("data/bio.json")),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = JsonContent.Create(bio)
            });

        // Other mocks for experience and skills (required by DataService)
        handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req => req.RequestUri != null && req.RequestUri.ToString().Contains("data/experience.json")),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = JsonContent.Create(new List<Experience>())
            });

        handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req => req.RequestUri != null && req.RequestUri.ToString().Contains("data/skills.json")),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = JsonContent.Create(new List<Skill>())
            });

        var httpClient = new HttpClient(handlerMock.Object) { BaseAddress = new Uri("http://localhost/") };
        Services.AddSingleton(httpClient);
        Services.AddSingleton<DataService>();
        
        // Mock JS Runtime for bUnit
        JSInterop.Mode = JSRuntimeMode.Loose;

        // Act
        var cut = RenderComponent<NavMenu>();

        // Assert
        var titleSpan = cut.Find(".left-span");
        Assert.Equal(".NET Developer", titleSpan.TextContent);
        
        var linkedInLink = cut.Find(".socials a");
        Assert.Equal("https://linkedin.com/in/filipealma", linkedInLink.GetAttribute("href"));
    }
}
