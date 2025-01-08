Processor i7 = new Processor("Intel", "i7", "7700K", 4, 4.2);
RamMemory ram = new RamMemory("Corsair", "Vengeance", "DDR4", 16, 2400);
GraphicsCard gpu = new GraphicsCard("Nvidia", "RTX", "4060", 8, "GDDR6");
ARMProcessor arm = new ARMProcessor("Apple", "A14", "Bionic", 6, 3.1, 2, 4);
Hardware hardware = new Hardware(); //Nem példányosítható, mert ABSTRACT osztály
Console.WriteLine(i7);
Console.WriteLine(ram);
Console.WriteLine(gpu);
Console.WriteLine(arm);