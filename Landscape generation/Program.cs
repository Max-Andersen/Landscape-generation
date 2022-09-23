﻿// See https://aka.ms/new-console-template for more information

using Landscape_generation.Generator;

Console.WriteLine("Hello, World!");

Map myMap = new Map(1000);

MapOfHeightGenerator gen = new MapOfHeightGenerator(myMap);
myMap = gen.modify(myMap);

HumidityGenerator humidity = new HumidityGenerator(myMap);
myMap = humidity.modify(myMap);

