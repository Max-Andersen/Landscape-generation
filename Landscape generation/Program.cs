// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



Map myMap = new Map(100);

Console.WriteLine(myMap.cells.GetUpperBound(0) + 1);

MapOfHeigthGenerator gen = new MapOfHeigthGenerator(myMap);
myMap = gen.modify(myMap);

