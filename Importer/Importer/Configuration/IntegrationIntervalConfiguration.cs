namespace Importer.Configuration
{
    internal class IntegrationIntervalConfiguration(DateTime StartTime, DateTime EndTime)
    {
        public DateTime StartTime { get; set; } = StartTime;
        public DateTime EndTime { get; set; } = EndTime;
    }
}
