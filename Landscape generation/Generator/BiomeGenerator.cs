using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landscape_generation.Generator
{
    public class BiomeGenerator : MapModifier
    {
        public Map modify(Map map)
        {
            byte elevation, humidity;
            for (int i = 0; i < map.size; i++)
            {
                for (int j = 0; j < map.size; j++)
                {
                    elevation = (byte)map.cells[i, j].height;
                    humidity = (byte)map.cells[i, j].humidity;
                    if (elevation < 0)
                    {
                        map.cells[i, j].color.blue = 255;//(byte)(127 + 127 * elevation)
                        map.cells[i, j].color.red = 0;//(byte)(48 + 48 * elevation)
                        map.cells[i, j].color.green = 0;//(byte)(64 + 64 * elevation)
                    }
                    else
                    {
                        byte r, g, b;
                        humidity = (byte)(humidity * (1 - elevation));
                        r = (byte)(210 - 100 * humidity);
                        g = (byte)(185 - 45 * humidity);
                        b = (byte)(139 - 45 * humidity);
                        map.cells[i, j].color.blue = (byte)(255 * elevation + b * (1 - elevation));
                        map.cells[i, j].color.red = (byte)(255 * elevation + r * (1 - elevation));
                        map.cells[i, j].color.green = (byte)(255 * elevation + g * (1 - elevation));
                    }
                    //else if (map.cells[i, j].humidity < 30)
                    //{
                    //    map.cells[i, j].color.blue = 0;
                    //    map.cells[i, j].color.red = 60;
                    //    map.cells[i, j].color.green = 0;
                    //}

                    // Console.WriteLine(map.cells[i,j].color + " ");
                }
            }
            return map;

        }

        public BiomeGenerator(Map map)
        {

        }


    }
}
