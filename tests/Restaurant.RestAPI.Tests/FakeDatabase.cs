using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Restaurant.RestAPI.Domain;

namespace Restaurant.RestAPI.Tests;

public class FakeDatabase : Collection<Reservation>, IReservationRepository
{
    public Task Create(Reservation reservation)
    {
        Add(reservation);
        return Task.CompletedTask;
    }
}