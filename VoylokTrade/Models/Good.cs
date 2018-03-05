using System;
using System.ComponentModel.DataAnnotations;

namespace VoylokTrade.Models
{
    public class Good : BaseEntity
    {
        public Good()
        {
            Id = Guid.NewGuid();
            TimeStamp = DateTime.Now;
        }

        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [Display(Name = "Кол-во, шт/ящик")]
        public int? TareVolume { get; set; }

        [Display(Name = "Цена, руб/шт")]
        public double? PricePerGood { get; set; }

        [Display(Name = "Производство")]
        public string Manufacturer { get; set; }

        [Display(AutoGenerateField = false)]
        public double? Weight { get; set; }

        [Display(AutoGenerateField = false)]
        public WeightTypeEnum? WeightType { get; set; }

        [Display(Name = "Наценка, %.")]
        public int? PriceMarkupInPercent { get; set; }

        //computed fields

        [Display(Name = "Вес, г.")]
        public int? WeightInGramms => (int?)(WeightType == WeightTypeEnum.grams ? Weight : Weight * 1000);

        [Display(Name = "Вес тары, кг.")]
        public double? TareWeightInKg => (WeightInGramms * TareVolume) / 1000;

        [Display(Name = "Цена, руб/коробка.")]
        public double? FullTarePrice => PricePerGood * TareVolume;

        [Display(Name = "Цена с наценкой, руб/шт.")]
        public double? PricePerGoodWithMarkup => PricePerGood * (1 + (PriceMarkupInPercent / 100)); //35% => N * (1 + (35/100)) => N * (1 + (0.35)) => N * 1.35

        [Display(Name = "Цена с наценкой, руб/коробка.")]
        public double? FullTarePriceWithMarkup => PricePerGoodWithMarkup * TareVolume;

        [Display(Name = "Прибыль, руб/шт.")]
        public double? ProfitPerGood => PricePerGoodWithMarkup - PricePerGood;

        [Display(Name = "Прибыль, руб/коробка.")]
        public double? ProfitPerTare => FullTarePriceWithMarkup - FullTarePrice;

    }
    public enum WeightTypeEnum
    {
        grams = 0,
        kilograms = 1
    };
}
