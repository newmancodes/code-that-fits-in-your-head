using Restaurant.RestAPI.Domain;

namespace Restaurant.RestAPI;

public interface IReservationRepository
{
    Task Create(Reservation reservation);
}