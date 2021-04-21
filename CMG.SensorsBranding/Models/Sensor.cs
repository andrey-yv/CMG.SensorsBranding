using System;
using System.Collections.Generic;
using CMG.SensorsBranding.Enums;

namespace CMG.SensorsBranding.Models
{
    public class Sensor
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public SensorType SensorType { get; set; }
        public string Classification { get; set; }
        public IDictionary<DateTime, double> Measurements { get; set; }
    }
}
