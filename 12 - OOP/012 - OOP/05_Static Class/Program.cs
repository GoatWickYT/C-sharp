Student geza = new Student();
{
    geza.Name = "Geza";
    // geza.Age = 23; static property cannot be accessed from an instance
}

Student bela = new Student();
{
    bela.Name = "Bela";
    // bela.Age = 24; static property cannot be accessed from an instance
}

Console.WriteLine($"{geza.Name} a(z) {Student.School}-ba jár");

Professor.Name = "Kiss Béla";

Console.WriteLine(Professor.Name);