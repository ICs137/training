using System;

namespace DAL.classes
{
    public interface IFilters
    {
        int FilterManagerId { get; set; }
        int FilterCustomerId { get; set; }
        int FilterProductId { get; set; }
        int FiLterPriceMin { get; set; }
        int FilterPriceMax { get; set; }
        DateTime FilterDateMin { get; set; }
        DateTime FilterDateMax { get; set; }
    }

    public   class Filters : IFilters
    {
        public int FilterManagerId { get; set; }
        public int FilterCustomerId { get; set; }
        public int FilterProductId { get; set; }
        public int FiLterPriceMin { get; set; }
        public int FilterPriceMax { get; set; }
        public DateTime FilterDateMin { get; set; }
        public DateTime FilterDateMax { get; set; } 
    }
}
