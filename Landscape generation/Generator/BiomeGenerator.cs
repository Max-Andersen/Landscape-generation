using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landscape_generation.Generator
{
    public class BiomeGenerator : MapModifier
    {
        private void printHumanityReadForm(Map map)
        {
            for (int i = 0; i < map.size; i++)
            {
                for (int j = 0; j < map.size; j++)
                {
                    if (map.cells[i, j].height <= 0f) map.cells[i, j].height = 0f;
                    else map.cells[i, j].height = 1f;
                }
            }

            for (int i = 0; i < map.size; i++)
            {
                for (int j = 0; j < map.size; j++) Console.Write(map.cells[i, j].height);
                Console.Write("\n");
            }
        }

        public byte convertToByte(int a)
        {
            return (byte)(a & 0xFF);
        }

        public Map modify(Map map)
        {
            //printHumanityReadForm(map);

            //for (int i = 0; i < map.size; ++i)
            //{
            //    for (int j = 0; j < map.size; ++j)
            //    {
            //        if (map.cells[i, j].height > 0f) Console.WriteLine(map.cells[i, j].height);
            //    }
            //}

            //Console.WriteLine();



            float elevation, humidity;
            for (int i = 0; i < map.size; i++)
            {
                for (int j = 0; j < map.size; j++)
                {
                    elevation = map.cells[i, j].height;
                    humidity = map.cells[i, j].humidity;
                    if (elevation < 0f)
                    {
                        map.cells[i, j].color.blue = convertToByte((int)(127 + 127 * elevation));//(byte)()
                        map.cells[i, j].color.red = convertToByte((int)(48 + 48 * elevation));//(byte)(48 + 48 * elevation)
                        map.cells[i, j].color.green = convertToByte((int)(64 + 64 * elevation));//(byte)(64 + 64 * elevation)
                    }
                    else
                    {
                        byte r, g, b;
                        //humidity = (humidity * (1 - elevation));
                        
                        r = convertToByte((int)(210 - 100 * elevation));
                        g = convertToByte((int)(195 - 45 * elevation));//185
                        b = convertToByte((int)(159 - 45 * elevation));//139

                        map.cells[i, j].color.red = r;
                        map.cells[i, j].color.green = g;
                        map.cells[i, j].color.blue = b;


                        //g = (byte)(185 - 45 * humidity);
                        //b = (byte)(139 - 45 * humidity);

                        //map.cells[i, j].color.blue = convertToByte((int)(255 * elevation + b * (1 - elevation)));
                        //map.cells[i, j].color.red = convertToByte((int)(255 * elevation + r * (1 - elevation)));
                        //map.cells[i, j].color.green = convertToByte((int)(255 * elevation + g * (1 - elevation)));

                        //map.cells[i, j].color.blue = (byte)(255 * elevation + b * (1 - elevation));
                        //map.cells[i, j].color.red = (byte)(255 * elevation + r * (1 - elevation));
                        //map.cells[i, j].color.green = (byte)(255 * elevation + g * (1 - elevation));
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
