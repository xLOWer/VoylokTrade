using System;
using System.ComponentModel.DataAnnotations;

namespace VoylokTrade.Models
{
    public class Good : BaseEntity
    {
        public Good()
        {
            Id = Guid.NewGuid();
        }

        [Display(Name = "Наименование")]
        public string Name { get; set; }
        
        [Display(Name = "Производитель")]
        public string Manufacturer { get; set; }

        [Display(Name = "Вес, гр.")]
        public int? WeightInGramms { get; set; }

        [Display(Name = "Стоимость, руб.")]
        public double Cost { get; set; }

        [Display(Name = "Фасовка")]
        public int? BoxSize { get; set; }

        [Display(Name = "Минимальный заказ, шт.")]
        public int? MinOrger { get; set; }
    }
}
