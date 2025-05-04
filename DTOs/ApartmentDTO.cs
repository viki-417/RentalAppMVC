using System.ComponentModel.DataAnnotations;

namespace RentalAppMVC.DTOs
{
    public class ApartmentDTO : PropertyDTO
    {
        public int FloorNumber { get; set; }
        public bool HasElevator { get; set; }

    }
}
