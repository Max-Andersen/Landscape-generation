using System;
using Landscape_generation.Generator;

public class Contoller
{
	public static void Main()
    {
		Map myMap = new Map(1000);

		MapOfHeightGenerator gen = new MapOfHeightGenerator(myMap);
		myMap = gen.modify(myMap);

		HumidityGenerator humidity = new HumidityGenerator(myMap);
		myMap = humidity.modify(myMap);

		BiomeGenerator biome = new BiomeGenerator(myMap);
		myMap = biome.modify(myMap);

		ImageExporter exporter = new PngExporter();
		exporter.Export(myMap, @"C:\Users\ZubanovaAlina\Documents\GitHub\aplication\Landscape-generation\test.png");
	}

}
