using System.Net;
using System.Net.Http.Json;
using filipealmeida.Models;
using filipealmeida.Services;
using Moq;
using Moq.Protected;
using Xunit;

namespace filipealmeida.Tests;

public class DataServiceTests
{
    [Fact]
    public async Task EnsureLoadedAsync_LoadsAllDataSuccessfully()
    {
        // Arrange
        var handlerMock = new Mock<HttpMessageHandler>();
        
        var bio = new Bio("Test User", "Developer", "Summary", "https://linkedin.com");
        var experiences = new List<Experience> { new Experience("Title", new DateOnly(2020, 1, 1), null, "Test Co", "Location", "Description") };
        var skills = new List<Skill> { new Skill("C#", "Expert") };

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

        handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req => req.RequestUri != null && req.RequestUri.ToString().Contains("data/experience.json")),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = JsonContent.Create(experiences)
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
                Content = JsonContent.Create(skills)
            });

        var httpClient = new HttpClient(handlerMock.Object) { BaseAddress = new Uri("http://localhost/") };
        var service = new DataService(httpClient);

        // Act
        await service.EnsureLoadedAsync();

        // Assert
        Assert.NotNull(service.Bio);
        Assert.Equal("Test User", service.Bio.Name);
        Assert.NotNull(service.Experiences);
        Assert.Single(service.Experiences);
        Assert.NotNull(service.Skills);
        Assert.Single(service.Skills);
    }
}
