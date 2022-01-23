using System.Collections.Generic;

namespace ConsoleApp.Problema06.Fakes
{
    public class Telemetry
    {
        public static List<Data> GetTelemetryRoutesLimited()
        {
            return new List<Data>();
        }

        public static Body GetFullTelemetryFromRoute(int routeId)
        {
            return new Body();
        }

        public static void MarkAsProcessed(int routeId)
        {

        }

        public static void SendProfileData(Response response)
        {

        }

        public static void SendRouteToAnalytics(int routeId)
        {

        }

        public static void MarkAsProcessedWithErrors(int routeId, string response)
        {

        }
    }
}
