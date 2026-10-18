using System.ComponentModel.DataAnnotations;

namespace wt_lab4_4mvc_gerasimchuk.Models
{
    public class Flight
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите номер рейса")]
        [Display(Name = "Номер рейса")]
        public string FlightNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Укажите город вылета")]
        [Display(Name = "Город вылета")]
        public string DepartureCity { get; set; } = string.Empty;

        [Required(ErrorMessage = "Укажите город прилёта")]
        [Display(Name = "Город прилёта")]
        public string ArrivalCity { get; set; } = string.Empty;

        [Required(ErrorMessage = "Укажите время вылета")]
        [Display(Name = "Время вылета")]
        [DataType(DataType.DateTime)]
        public DateTime DepartureTime { get; set; }

        [Required(ErrorMessage = "Укажите время прилёта")]
        [Display(Name = "Время прилёта")]
        [DataType(DataType.DateTime)]
        public DateTime ArrivalTime { get; set; }

        [Range(1, 1000000, ErrorMessage = "Цена должна быть положительной")]
        [Display(Name = "Цена билета, ₽")]
        public decimal Price { get; set; }

        [Display(Name = "Тип самолёта")]
        public string AircraftType { get; set; } = string.Empty;

        [Display(Name = "Доступен для продажи")]
        public bool IsAvailable { get; set; }
    }
}