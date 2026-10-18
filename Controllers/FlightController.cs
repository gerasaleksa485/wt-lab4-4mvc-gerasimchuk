using Microsoft.AspNetCore.Mvc;
using wt_lab4_4mvc_gerasimchuk.Models;

namespace wt_lab4_4mvc_gerasimchuk.Controllers
{
    public class FlightController : Controller
    {
        private static readonly List<Flight> Flights = new()
        {
            new Flight { Id = 1, FlightNumber = "SL-101", DepartureCity = "Москва", ArrivalCity = "Санкт-Петербург", DepartureTime = new DateTime(2025, 6, 1, 8, 0, 0), ArrivalTime = new DateTime(2025, 6, 1, 9, 30, 0), Price = 4500, AircraftType = "Airbus A320", IsAvailable = true },
            new Flight { Id = 2, FlightNumber = "SL-202", DepartureCity = "Москва", ArrivalCity = "Казань", DepartureTime = new DateTime(2025, 6, 1, 10, 15, 0), ArrivalTime = new DateTime(2025, 6, 1, 11, 50, 0), Price = 5200, AircraftType = "Boeing 737", IsAvailable = true },
            new Flight { Id = 3, FlightNumber = "SL-303", DepartureCity = "Санкт-Петербург", ArrivalCity = "Сочи", DepartureTime = new DateTime(2025, 6, 1, 13, 0, 0), ArrivalTime = new DateTime(2025, 6, 1, 16, 30, 0), Price = 7800, AircraftType = "Airbus A321", IsAvailable = false },
            new Flight { Id = 4, FlightNumber = "SL-404", DepartureCity = "Екатеринбург", ArrivalCity = "Москва", DepartureTime = new DateTime(2025, 6, 2, 7, 15, 0), ArrivalTime = new DateTime(2025, 6, 2, 8, 45, 0), Price = 6100, AircraftType = "Sukhoi Superjet 100", IsAvailable = true },
            new Flight { Id = 5, FlightNumber = "SL-505", DepartureCity = "Новосибирск", ArrivalCity = "Владивосток", DepartureTime = new DateTime(2025, 6, 2, 18, 0, 0), ArrivalTime = new DateTime(2025, 6, 3, 2, 30, 0), Price = 12500, AircraftType = "Boeing 767", IsAvailable = true }
        };

        public IActionResult Index() => View(Flights);

        public IActionResult Details(int id)
        {
            var flight = Flights.FirstOrDefault(f => f.Id == id);
            if (flight == null) return NotFound();
            return View(flight);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Flight flight)
        {
            if (!ModelState.IsValid) return View(flight);
            flight.Id = Flights.Count == 0 ? 1 : Flights.Max(f => f.Id) + 1;
            Flights.Add(flight);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var flight = Flights.FirstOrDefault(f => f.Id == id);
            if (flight == null) return NotFound();
            return View(flight);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Flight flight)
        {
            if (!ModelState.IsValid) return View(flight);
            var existing = Flights.FirstOrDefault(f => f.Id == flight.Id);
            if (existing == null) return NotFound();

            existing.FlightNumber = flight.FlightNumber;
            existing.DepartureCity = flight.DepartureCity;
            existing.ArrivalCity = flight.ArrivalCity;
            existing.DepartureTime = flight.DepartureTime;
            existing.ArrivalTime = flight.ArrivalTime;
            existing.Price = flight.Price;
            existing.AircraftType = flight.AircraftType;
            existing.IsAvailable = flight.IsAvailable;

            return RedirectToAction(nameof(Index));
        }
    }
}