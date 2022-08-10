using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Restaurant.RestAPI.Tests;

public class HomeTests
{
    [Fact]
    [SuppressMessage(
        "Usage", "CA2234:Pass system uri objects instead of strings",
        Justification = "URL isn't passed as a variable, but as literal.")]
    public async Task HomeReturnsJson()
    {
        await using var factory = new WebApplicationFactory<Startup>();
        var client = factory.CreateClient();

        using var request = new HttpRequestMessage(HttpMethod.Get, "");
        request.Headers.Accept.ParseAdd("application/json");
        var response = await client.SendAsync(request);

        response.IsSuccessStatusCode.Should().BeTrue();
        response.Content.Headers.ContentType!.MediaType.Should().Be("application/json");
    }
}