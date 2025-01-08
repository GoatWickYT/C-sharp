[ApiController]
[Route("[controller]")]
public partial class MessageSenderController : ControllerBase
{
    private readonly Random random = new Random();

    private readonly string[] errorMessages = [
        "Sikertelen uzenet kuldes",
        "Nem a mefelelo a megadott rendszer",
        "Az uzenet nem megfelelo formatumu",
        string.Empty,
    ];

    [HttpPost]
    [Route("/api/send/ios")]
    [SwaggerOperation(OperationId = "sendIOS")]
    [Produces("application/json")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(MessageSendingResultResponse))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> SendIosAsync([FromBody][Required] MessageRequest requestParam)
    {
        return await ProcessRequest(requestParam, MobileOperatingSystem.iOS, '|');
    }

    [HttpPost]
    [Route("/api/send/android")]
    [SwaggerOperation(OperationId = "sendAndroid")]
    [Produces("application/json")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(MessageSendingResultResponse))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> SendAndroidAsync([FromBody][Required] MessageRequest requestParam)
    {
        return await ProcessRequest(requestParam, MobileOperatingSystem.Android, '#');
    }

    [HttpPost]
    [Route("/api/send/windows")]
    [SwaggerOperation(OperationId = "sendWindows")]
    [Produces("application/json")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(MessageSendingResultResponse))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> SendWindowsAsync([FromBody][Required] MessageRequest requestParam)
    {
        return await ProcessRequest(requestParam, MobileOperatingSystem.Windows, '*');
    }

    private async Task<IActionResult> ProcessRequest(MessageRequest requestParam, MobileOperatingSystem operatingSystem, char key)
    {
        var isFailed = random.Next(1, 10) % 7 == 0;
        var isOpSysMessage = requestParam.System == operatingSystem;
        var isValidFormat = requestParam.Content.Count(x => x == key) == 4;

        var index = isFailed ?
                    0 :
                    !isValidFormat ?
                        2 :
                        !isOpSysMessage ?
                            1 :
                            3;


        var response = new MessageSendingResultResponse
        {
            ErrorMessage = errorMessages[index],
            Success = !isFailed && isOpSysMessage && isValidFormat
        };

        await Task.Delay(50);

        return Ok(response);
    }
}
