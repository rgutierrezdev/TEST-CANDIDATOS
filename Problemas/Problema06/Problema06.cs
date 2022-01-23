using ConsoleApp.Problema06.Fakes;

namespace ConsoleApp.Problema06
{
    public class Problema06
    {
        public bool BeingUsed { get; private set; } = false;

        public void RunTelemetry()
        {
            if (!BeingUsed)
            {
                BeingUsed = true;

                var data = Telemetry.GetTelemetryRoutesLimited();

                foreach (var element in data)
                {
                    var routeId = element.route_id;
                    var body = Telemetry.GetFullTelemetryFromRoute(routeId);
                    if (body != null && !body.Processed)
                    {
                        var response = MyDrive.PostTripFromBody(body);
                        if (response.Status == 201 || response.Status == 200)
                        {
                            Telemetry.MarkAsProcessed(routeId);
                            if (body.SubscriptionId != null)
                            {
                                var latestProfile = MyDrive.GetLatestProfile(body.SubscriptionId);
                                if (latestProfile?.Response != null)
                                {
                                    if (latestProfile.Response.Profile != null && latestProfile.Response.Profile.Distance > 0)
                                    {
                                        if (latestProfile.Response.Profile.Distance >= 400)
                                        {
                                            Telemetry.SendProfileData(latestProfile.Response);
                                        }
                                    }
                                }
                            }
                            Telemetry.SendRouteToAnalytics(routeId);
                        }
                        else
                        {
                            Telemetry.MarkAsProcessedWithErrors(routeId, response.response);
                        }
                    }
                }

                BeingUsed = false;
            }
        }
    }
}
