namespace Importer.Configuration
{
    internal class UserConfigurationService
    {
        public IntegrationIntervalConfiguration AskForApiConfiguration()
        {
            DateTime startTime = FetchStartTimeFromUser();
            DateTime endTime = FetchEndTimeFromUser();

            return new IntegrationIntervalConfiguration(startTime, endTime);
        }

        DateTime FetchStartTimeFromUser()
        {
            Console.WriteLine($"Input start time for the integration data fetch");
            DisplayUserInputFormat();

            if (TimeUtil.IsApiTimestamp(Console.ReadLine(), out var input))
            {
                return input;
            }
            else
            {
                return FetchStartTimeFromUser();
            }
        }

        DateTime FetchEndTimeFromUser()
        {
            Console.WriteLine($"Input end time for the integration data fetch");
            DisplayUserInputFormat();

            if (TimeUtil.IsApiTimestamp(Console.ReadLine(), out var input))
            {
                return input;
            }
            else
            {
                return FetchEndTimeFromUser();
            }
        }

        void DisplayUserInputFormat()
        {
            Console.WriteLine("Provide in the following format: YYYY-MM-DDThh:mm ex: 2026-05-16T00:00");
        }
    }
}
