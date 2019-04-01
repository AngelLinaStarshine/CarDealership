using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Web;

namespace CarDealership.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Manufacture { get; set; }
        [Column("year")]
        public DateTime YearDate { get; set; }
        public double Price { get; set; }
        public float Run { get; set; }
        public string AddInfo { get; set; }
        [Column("pic")]
        public byte[] PicBytes { get; set; }

        [NotMapped]
        public int Year
        {
            get => YearDate.Year;
            set => YearDate = DateTime.MinValue.AddYears(value - DateTime.MinValue.Year);
        }

        [NotMapped, DataType(DataType.Upload)]
        public HttpPostedFileBase Pic { get; set; }

        [NotMapped]
        public string Base64Image => PicBytes != null ? $"data:image/png;base64, {Convert.ToBase64String(PicBytes)}" : string.Empty;
    }
}