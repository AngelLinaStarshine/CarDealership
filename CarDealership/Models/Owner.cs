using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace CarDealership.Models
{
    public class Owner
    {
        public Owner()
        {
            Cars = new HashSet<Car>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Car> Cars { get; set; }

        [NotMapped]
        public SelectList AvailableCars { get; set; }

        [NotMapped]
        public int SelectedCar { get; set; }
    }
}