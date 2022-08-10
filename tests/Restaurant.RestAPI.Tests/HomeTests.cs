using System.Diagnostics.CodeAnalysis;
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
    public async Task HomeIsOk()
    {
        using var factory = new WebApplicationFactory<Startup>();
        var client = factory.CreateClient();

        var response = await client.GetAsync("");

        response.IsSuccessStatusCode.Should().BeTrue();
    }
}