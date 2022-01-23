namespace ConsoleApp.Problema06.Fakes
{
    public class MyDrive
    {
        public static Response PostTripFromBody(Body body)
        {
            return new Response();
        }

        public static Profile GetLatestProfile(int? subscriptionId)
        {
            return new Profile();
        }
    }
}
