﻿using System;
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

        /// <summary>
        /// Наименование товара
        /// </summary>
        [Display(Name = "Наименование")]
        public string Name { get; set; }

        /// <summary>
        /// Количество товара в одной таре
        /// </summary>
        [Display(Name = "Кол-во, шт/ящик")]
        public int? TareVolume { get; set; }

        /// <summary>
        /// Цена за еденицу товара
        /// </summary>
        [Display(Name = "Цена, руб/шт")]
        public double? PricePerGood { get; set; }

        /// <summary>
        /// Производство
        /// </summary>
        [Display(Name = "Производство")]
        public string Manufacturer { get; set; }

        /// <summary>
        /// Вес в неизвестных еденицах
        /// </summary>
        [Display(Name = "Вес", AutoGenerateField = false)]
        public double? Weight { get; set; }

        /// <summary>
        /// Тип веса для вычисления его в граммах
        /// </summary>
        [Display(Name = "Тип Веса", AutoGenerateField = false)]
        public WeightTypeEnum? WeightType { get; set; }

        /// <summary>
        /// Наценка в процентах
        /// </summary>
        [Display(Name = "Наценка, %.")]
        public int? PriceMarkupInPercent { get; set; }

        //computed fields

        /// <summary>
        /// Вычесленный вес еденицы товара в граммах
        /// </summary>
        [Display(Name = "Вес, г.")]
        public int? WeightInGramms => (int?)(WeightType == WeightTypeEnum.grams ? Weight : Weight * 1000);

        /// <summary>
        /// Цена одной еденицы товара
        /// </summary>
        [Display(Name = "Вес тары, кг.")]
        public double? TareWeightInKg => (WeightInGramms * TareVolume) / 1000;

        /// <summary>
        /// Цена одной коробки
        /// </summary>
        [Display(Name = "Цена, руб/коробка.")]
        public double? FullTarePrice => PricePerGood * TareVolume;

        /// <summary>
        /// Цена с наценкой за еденицу товара
        /// </summary>
        [Display(Name = "Цена, руб/шт.")]
        public double? PricePerGoodWithMarkup => PricePerGood * (1 + ((double?)PriceMarkupInPercent / 100)); //35% => N * (1 + (35/100)) => N * (1 + (0.35)) => N * 1.35

        /// <summary>
        /// Цена с наценкой за коробку
        /// </summary>
        [Display(Name = "Цена, руб/коробка.")]
        public double? FullTarePriceWithMarkup => PricePerGoodWithMarkup * TareVolume;

        /// <summary>
        /// Прибыль в рублях за еденицу товара
        /// </summary>
        [Display(Name = "Прибыль, руб/шт.")]
        public double? ProfitPerGood => PricePerGoodWithMarkup - PricePerGood;

        /// <summary>
        /// Прибыль в рублях с одной коробки
        /// </summary>
        [Display(Name = "Прибыль, руб/коробка.")]
        public double? ProfitPerTare => FullTarePriceWithMarkup - FullTarePrice;

    }
    public enum WeightTypeEnum
    {
        grams = 0,
        kilograms = 1
    };
}
