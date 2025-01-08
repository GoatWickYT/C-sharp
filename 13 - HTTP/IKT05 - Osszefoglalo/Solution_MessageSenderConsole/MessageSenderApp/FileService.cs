using System.Text;

static class FileService
{
    private static JsonSerializerOptions options = new JsonSerializerOptions()
    {
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
        WriteIndented = true
    };

    public static List<StoredMessage> ReadMessagesFromJson(string fileName)
    {
        string fileFullPath = Path.Combine(Directory.GetCurrentDirectory(),"source\\" + fileName);
        string json = File.ReadAllText(fileFullPath);
        return JsonSerializer.Deserialize<List<StoredMessage>>(json, options);
    }

    public static void WriteReportToJson(string fileName, List<Report> messages)
    {
        string fileFullPath = Path.Combine(Directory.GetCurrentDirectory(), "reports\\" + fileName);
        string json = JsonSerializer.Serialize(messages, options);
        File.WriteAllText(fileFullPath.Replace("\\bin\\Debug\\net8.0", ""), json);
    }

    public static async Task WriteToTxtAsync<T>(ICollection<T> collection, string fileName)
    {
        string fileFullPath = Path.Combine(Directory.GetCurrentDirectory(), "log\\" + fileName);

        using FileStream fs = new FileStream(fileFullPath.Replace("\\bin\\Debug\\net8.0", ""), FileMode.Create, FileAccess.Write, FileShare.None);
        using StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
        foreach (var item in collection)
        {
            await sw.WriteLineAsync($"{item}");
        }
    }
}