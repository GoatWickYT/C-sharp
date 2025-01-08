public class ARMProcessor : Processor
{
    public int NumberOfPowerCores { get; set; }

    public int NumberOfEfficientCores { get; set; }

    public ARMProcessor() : base()
    {
    }

    public ARMProcessor(string manufacturer, string model, string type, int numberOfCores, double frequency, int numberOfPowerCores, int numberOfEfficientCores)
        : base(manufacturer, model, type, numberOfCores, frequency)
    {
        NumberOfPowerCores = numberOfPowerCores;
        NumberOfEfficientCores = numberOfEfficientCores;
    }
}
