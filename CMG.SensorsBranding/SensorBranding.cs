using Newtonsoft.Json;
using CMG.SensorsBranding.Helpers;

namespace CMG.SensorsBranding
{
    public class SensorBranding
    {
        public static string EvaluateLogFile(string[] logContentsStr)
        {
            var sensors = ContentParser.ParseLogContent(logContentsStr);

            var sensorInfo = BrandingHelper.GetBrandedSensors(sensors);

            return JsonConvert.SerializeObject(sensorInfo);
        }
    }
}
