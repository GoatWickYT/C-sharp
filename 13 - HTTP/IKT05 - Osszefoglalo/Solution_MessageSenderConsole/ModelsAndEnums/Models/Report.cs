public class Report
{
    public List<Error> Errors { get; set; } = new List<Error>();

    public int SuccessCount { get; set; }

    public DateTime Date { get; set; }

    public Report() { }

    public Report(List<Error> errors, int successCount, DateTime date)
    {
        Errors = errors;
        SuccessCount = successCount;
        Date = date;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var error in Errors)
        {
            sb.AppendLine(error.ToString());
        }
        sb.AppendLine($"Succesful sends number: {SuccessCount}");
        sb.AppendLine($"Date: {Date.ToString("yyyy/MM/dd Time:HH:mm:ss")}");

        return sb.ToString();
    }
}