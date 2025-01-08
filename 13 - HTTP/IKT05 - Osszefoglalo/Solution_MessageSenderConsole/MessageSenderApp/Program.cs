DateTime actualDate = DateTime.Now;

await SendFormattedMessageAsync();

async Task SendFormattedMessageAsync()
{

    List<StoredMessage> messages = FileService.ReadMessagesFromJson("messages.json");
    List<Message> sentMessages = new List<Message>();

    Message currentMessage = new Message();

    foreach (StoredMessage message in messages)
    {
        switch (message.System.ToLower())
        {
            case "ios":
                currentMessage = new Message(new OSBaseModel(message.System, message.FirstName, message.LastName, message.MobileNumber, message.Message).ToString(), 0);
                break;
            case "android":
                currentMessage = new Message(new OSBaseModel(message.System, message.FirstName, message.LastName, message.MobileNumber, message.Message).ToString(), 1);
                break;
            case "windows":
                currentMessage = new Message(new OSBaseModel(message.System, message.FirstName, message.LastName, message.MobileNumber, message.Message).ToString(), 2);
                break;
        }
        sentMessages.Add(currentMessage);
    }

    List<Response> responses = new List<Response>();
    Response response = new Response();

    foreach (Message sentMessage in sentMessages)
    {

        response = await SendMessageAsync(sentMessage.System,sentMessage);
        responses.Add(response);
    }

    List<Response> successes = new List<Response>();
    List<Response> errors = new List<Response>();

    foreach (Response item in responses)
    {
        if (item.IsSuccessful)
        {
            successes.Add(item);
        }
        else
        {
            errors.Add(item);
        }
    }

    await FileService.WriteToTxtAsync(successes, $"delivered_{actualDate.ToString("yyyy/MM/dd")}");
    await FileService.WriteToTxtAsync(errors, $"not-delivered_{actualDate.ToString("yyyy/MM/dd")}");

    await CreateReportAsync(successes, errors);
}

async Task CreateReportAsync(List<Response> successes, List<Response> errors)
{
    int number = 0;
    Report report = new Report();
    report.SuccessCount = successes.Count;
    report.Date = actualDate;

    errors.GroupBy(x => x.ErrorMessage).ToList().ForEach(x =>
    {
        Error error = new Error();
        error.Reason = x.Key;
        error.Count = x.Count();
        report.Errors.Add(error);
    });

    FileService.WriteReportToJson($"report_{actualDate.ToString("yyyy/MM/dd")}", [report]);
}

async Task<Response> SendMessageAsync(int systemNumber, Message message)
{
    string systemName = string.Empty;

    switch (systemNumber)
    {
        case 0:
            systemName = "ios";
            break;
        case 1:
            systemName = "android";
            break;
        case 2:
            systemName = "windows";
            break;
    }

    Response response = await HTTPService.SendPostRequestAsync<Response>($"api/send/{systemName.ToLower()}", message);
    return response;
}