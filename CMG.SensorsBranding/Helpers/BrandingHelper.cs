using System;
using System.Linq;
using System.Collections.Generic;
using CMG.SensorsBranding.Enums;
using CMG.SensorsBranding.Models;
using CMG.SensorsBranding.Constants;

namespace CMG.SensorsBranding.Helpers
{
    public class BrandingHelper
    {
        public static Dictionary<string, string> GetBrandedSensors(IList<Sensor> sensors)
        {
            var sensorInfo = new Dictionary<string, string>();
            foreach (var itemSensor in sensors)
            {
                CreateClassification(itemSensor);

                if (!sensorInfo.ContainsKey(itemSensor.Name))
                    sensorInfo.Add(itemSensor.Name, itemSensor.Classification);
            }

            return sensorInfo;
        }

        private static void CreateClassification(Sensor sensor)
        {
            var deviationValues = sensor.Measurements.Values.Select(x => Math.Abs(x - ReferenceValue.Temperature));

            var maxDeviation = deviationValues.Max();
            var averageDeviation = deviationValues.Average();

            switch (sensor.SensorType)
            {
                case SensorType.Thermometer:
                    {
                        if (maxDeviation <= 3 && averageDeviation < 5)
                        {
                            sensor.Classification = "ultra precise";
                        }
                        else if (3 < maxDeviation && maxDeviation <= 5 && averageDeviation < 5)
                        {
                            sensor.Classification = "very precise";
                        }
                        else
                        {
                            sensor.Classification = "precise";
                        }
                    }
                    break;
                case SensorType.Humidity:
                    {
                        if (maxDeviation <= 1)
                        {
                            sensor.Classification = "keep";
                        }
                        else
                        {
                            sensor.Classification = "discard";
                        }
                    }
                    break;
                case SensorType.Monoxide:
                    {
                        if (maxDeviation <= 3)
                        {
                            sensor.Classification = "keep";
                        }
                        else
                        {
                            sensor.Classification = "discard";
                        }
                    }
                    break;
            }
        }
    }
}
