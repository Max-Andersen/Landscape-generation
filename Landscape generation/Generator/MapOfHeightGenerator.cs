using SimplexNoise;

namespace Landscape_generation.Generator;
public class MapOfHeightGenerator: MapModifier
{
    private int _seed;
    private uint _height;
    private uint _width;
    private float _scale;

    private float[,] _noise;

    private Random _random = new Random();

    private void generateSeed()
    {
        _seed = _random.Next(0, 1000000);
    }

    private void getSimplexNoise()
    {
        _noise = Noise.Calc2D((int)_width, (int)_height, _scale);
    }

    private float translateNoiseToSmallerValue(float noise)    // to [0, 1]
    {
        return ((noise - 128f) / 128f + 1f) / 2f;
    }

    private void getMapValues(Map map)
    {
        _width = map.size;
        _height = map.size;
        _scale = 0.008f;
    }

    public MapOfHeightGenerator(Map map)
    {
        generateSeed();
        Noise.Seed = _seed;
        getMapValues(map);
        getSimplexNoise();
    }

    private void printHumanityReadForm(Map map)
    {
        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _width; j++)
            {
                if (map.cells[i, j].height <= 0f) map.cells[i, j].height = 0f;
                else map.cells[i, j].height = 1f;
            }
        }

        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _width; j++) Console.Write(map.cells[i, j].height);
            Console.Write("\n");
        }
    }

    public Map modify(Map map)
    {
        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _width; j++)
            {
                float nx = 2f * i / _width - 1f;
                float ny = 2f * j / _height - 1f;
                float d = 2 * Math.Max(Math.Abs(nx), Math.Abs(ny));
                map.cells[i, j].height = (translateNoiseToSmallerValue(_noise[i, j]) + 1f - d) / 2f;
            }
        }

        printHumanityReadForm(map);
        return map;
    }
}