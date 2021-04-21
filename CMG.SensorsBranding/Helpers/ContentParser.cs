using System;
using System.Linq;
using System.Collections.Generic;
using CMG.SensorsBranding.Enums;
using CMG.SensorsBranding.Models;

namespace CMG.SensorsBranding
{
    public class ContentParser
    {
        public static IList<Sensor> ParseLogContent(string[] logContentsStr)
        {
            var sensor = new Sensor();
            var sensors = new List<Sensor>();
            var sensorsNames = Enum.GetNames(typeof(SensorType)).Select(s => s.ToLowerInvariant()).ToList();
            for (int i = 0; i < logContentsStr.Length; i++)
            {
                var data = logContentsStr[i].Split(" ");

                if (sensorsNames.Contains(data[0]))
                {
                    var type = data[0];
                    var name = data[1];
                    sensor = new Sensor() { Type = type, Name = name, Measurements = new Dictionary<DateTime, double>() };
                    Enum.TryParse<SensorType>(type, true, out var sensorType);
                    sensor.SensorType = sensorType;
                    sensors.Add(sensor);
                }
                else
                {
                    DateTime.TryParse(data[0], out var dateTime);
                    Double.TryParse(data[1], out var measurement);
                    sensor.Measurements.Add(dateTime, measurement);
                }
            }

            return sensors;
        }
    }
}