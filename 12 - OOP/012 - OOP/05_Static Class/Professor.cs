public static class Professor
{
    public static string Name { get; set; }
    public static string School { get; set; }
    public static int Age { get; set; }

    static Professor()
    {
        School = "Szegedi SZC Vasvári Pál Gazdasági és Informatikai Technikum";
    }
}
