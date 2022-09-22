using SimplexNoise;


public class MapOfHeigthGenerator
{
    private int _seed;
    private int _height;
    private int _width;
    private float _scale;

    private float[,] _noise;

    private Random _random = new Random();

    private void generateSeed()
    {
        _seed = _random.Next(0, 1000000);
    }

    private void getSimplexNoise()
    {
        _noise = Noise.Calc2D(_width, _height, _scale);
    }

    private float translateNoiseToSmallerValue(float noise)    // to [0, 1]
    {
        return ((noise - 128f) / 128f + 1f) / 2f;
    }

    private void getMapValues(Map map)
    {
        _width = map.cells.GetUpperBound(0) + 1;
        _height = map.cells.GetUpperBound(0) + 1;
        _scale = 0.008f;
    }

    public MapOfHeigthGenerator(Map map)
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
                if (map.cells[i, j].height <= 1f) map.cells[i, j].height = 0f;
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
                float d = (1f - nx * nx) * (1f - ny * ny); // https://www.wolframalpha.com/input/?i=plot+%281-x%5E2%29%281-y%5E2%29+from+-1+to+1
                                                           // need to make islands
                map.cells[i, j].height = (translateNoiseToSmallerValue(_noise[i, j]) + (1f + d)) / 2f;
            }
        }

        printHumanityReadForm(map);
        return map;
    }
}