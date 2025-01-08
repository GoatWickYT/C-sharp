public class OSBaseModel
{
    public string System { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string MobileNumber { get; private set; }
    public string Message { get; private set; }

    private int systemNumber;
    private char systemSeparator;

    public OSBaseModel()
    { }

    public OSBaseModel(string system, string firstName, string lastName, string mobileNumber, string message)
    {
        System = system;
        FirstName = firstName;
        LastName = lastName;
        MobileNumber = mobileNumber;
        Message = message;

        systemNumber = Convert.ToInt32(Enum.Parse<OSEnum>(System.ToLower()));
        systemSeparator = ' ';
        switch (systemNumber)
        {
            case 0: //  IOS
                systemSeparator = '|';
                break;
            case 1: // Android
                systemSeparator = '#';
                break;
            case 2: // Windows
                systemSeparator = '*';
                break;
        }
    }

    public override string ToString()
    {
        return $"{System}{systemSeparator}{FirstName}{systemSeparator}{LastName}{systemSeparator}{MobileNumber}{systemSeparator}{Message}";
    }
}