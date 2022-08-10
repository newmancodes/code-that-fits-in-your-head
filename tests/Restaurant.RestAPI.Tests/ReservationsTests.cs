using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Restaurant.RestAPI.Controllers;
using Restaurant.RestAPI.Domain;
using Restaurant.RestAPI.Models;
using Xunit;

namespace Restaurant.RestAPI.Tests;

public class ReservationsTests
{
    [Fact]
    public async Task PostValidReservation()
    {
        var response = await PostReservation(new
        {
            date = "2023-03-10 19:00",
            email = "katinka@example.com",
            naem = "Katinka Ingabogovinanana",
            quanity = 2,
        });

        response.IsSuccessStatusCode.Should().BeTrue();
    }

    [SuppressMessage(
        "Usage",
        "CA2234:Pass system uri objects instead of strings",
        Justification = "URL isn't passed as a variable, but as literal.")]
    private static async Task<HttpResponseMessage> PostReservation(object reservation)
    {
        await using var factory = new WebApplicationFactory<Startup>();
        var client = factory.CreateClient();

        string json = JsonSerializer.Serialize(reservation);
        using var content = new StringContent(json);
        content.Headers.ContentType!.MediaType = "application/json";
        return await client.PostAsync("reservations", content);
    }

    [Fact]
    public async Task PostValidReservationWhenDatabaseIsEmpty()
    {
        var db = new FakeDatabase();
        var sut = new ReservationsController(db);

        var dto = new ReservationDto
        {
            At = "2023-11-24 19:00",
            Email = "juliad@example.net",
            Name = "Julia Domna",
            Quantity = 5,
        };
        await sut.Post(dto);

        var expected = new Reservation(
            new DateTime(2023, 11, 24, 19, 0, 0),
            dto.Email,
            dto.Name,
            dto.Quantity);
        db.Should().Contain(expected);
    }
}