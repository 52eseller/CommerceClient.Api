﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CommerceClient.Api.Model
{
    public class UnitOfMeasureResponse
    {
        public int UnitOfMeasureId { get; set; }
        public string ExtUnitOfMeasureId { get; set; }

        /// <summary>
        /// Short notation of the unit. Try using abbreviations familiar to your clients.
        /// </summary>
        public string Abbreviation { get; set; }

        /// <summary>
        /// Indicates if the unit is a standardized unit (f.inst kilo) or non-standardized unit (f.inst box or pallet)
        /// aka SiUnit
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public SiUnit SiUnit { get; set; }

        /// <summary>
        /// Indicates how this unit mathematical relates to its base unit.
        /// Base units will have conversion factor 1.
        /// </summary>
        public decimal ConversionFactor { get; set; }

        /// <summary>
        /// If this unit relates to another unit. All units with the same base can be converted between each other.
        /// </summary>
        public int? BaseUnitOfMeasureId { get; set; }

        /// <summary>
        /// A more elaborate description of this unit. Try using terms familiar to your clients.
        /// </summary>
        public string Description { get; set; }
    }

    /// <summary>
    /// Lists the 7 fundamental unit of measures based on the International System of Units (SI). See https://en.wikipedia.org/wiki/SI_base_unit .
    /// An additional 8th unit ia added to describe abstract business specific units, like "each" or "box",
    /// that does not translate to an SI unit.
    /// </summary>
    public enum SiUnit
    {
        /// <summary>
        /// Indicates the measure is not defined by SI. This is used for describing other measures, f.inst production units like "each".
        /// </summary>
        NonSiUnit = 0,

        /// <summary>
        /// The measure focuses on length (m), i.e. distance in a particular direction.
        /// </summary>
        Length = 1,

        /// <summary>
        /// The measure focuses on mass (kg), i.e. weight. The base must be kg.
        /// </summary>
        Mass = 2,

        /// <summary>
        /// The measure focuses on time (s), i.e. seconds, minutes, hours etc.
        /// </summary>
        Time = 3,

        /// <summary>
        /// The measure focuses on current (A), i.e. ampere.
        /// </summary>
        ElectricCurrent = 4,

        /// <summary>
        /// The measure focuses on temperature (K), i.e. Kelvin, Celcious etc.
        /// </summary>
        ThermoDynamicTemperature = 5,

        /// <summary>
        /// The measure focuses on substance (mol)
        /// </summary>
        AmountOfSubstance = 6,

        /// <summary>
        /// The measure focuses on light (cd), i.e. candelas.
        /// </summary>
        LuminousIntensity = 7
    }
}