using Microsoft.AspNetCore.Mvc;
using Restaurant.RestAPI.Domain;
using Restaurant.RestAPI.Models;

namespace Restaurant.RestAPI.Controllers;

[ApiController, Route("[controller]")]
public class ReservationsController
{
    public IReservationRepository Repository { get; }
    
    public ReservationsController(IReservationRepository repository)
    {
        Repository = repository;
    }

    public async Task Post(ReservationDto dto)
    {
        if (dto is null)
            throw new ArgumentNullException(nameof(dto));

        await Repository
            .Create(new Reservation(
                new DateTime(2023, 11, 24, 19, 0, 0),
                "juliad@example.net",
                "Julia Domna",
                5))
            .ConfigureAwait(false);
    }
}