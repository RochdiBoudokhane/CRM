using System;

using System.ComponentModel.DataAnnotations;


namespace Solution.Presentation.Models
{
    public class PackVM
    {
        public int PackId { get; set; }
        public String TypePack { get; set; }
        public String PackName { get; set; }
        public String Description { get; set; }
        public int Quantity { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}