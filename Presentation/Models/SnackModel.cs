using Domain.SnackMachine;

namespace Presentation.Models
{
    public class SnackModel
    {
        public SnackMachine? Machine { get; set; }
        public string? Message { get; set; }
    }
}