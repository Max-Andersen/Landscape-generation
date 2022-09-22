// See https://aka.ms/new-console-template for more information

using Landscape_generation.Generator;

Console.WriteLine("Hello, World!");



Map myMap = new Map(20);

Console.WriteLine(myMap.cells.GetUpperBound(0) + 1);

MapOfHeigthGenerator gen = new MapOfHeigthGenerator(myMap);
myMap = gen.modify(myMap);

HumidityGenerator humidity = new HumidityGenerator(myMap);
myMap = humidity.modify(myMap);

