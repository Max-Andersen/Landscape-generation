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
        _scale = 0.1f;
    }

    public MapOfHeigthGenerator(Map map)// input: Map
    {
        generateSeed();
        Noise.Seed = _seed;
        getMapValues(map);
        getSimplexNoise();
    }


    public Map modify(Map map)
    {
        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _width; j++)
            {
                map.cells[i, j].height = translateNoiseToSmallerValue(_noise[i, j]);

                float d = (1 - i * i) * (1 - j * j);
                //float d = 2 * Math.Max(Math.Abs(nx), Math.Abs(ny));
                //map.cells[i, j].height = (map.cells[i, j].height + (1 - d)) / 2;
            }
        }


        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _width; j++)
            {
                if (map.cells[i, j].height <= 0.4f)
                {
                    map.cells[i, j].height = 0f;
                }
                else
                {
                    map.cells[i, j].height = 1f;
                }
            }
        }


        for (int i = 0; i < _width; i++)
        {
            //Console.Write("-----");
            for (int j = 0; j < _width; j++)
            {
                Console.Write(map.cells[i, j].height);
                //Console.Write("-----");
            }
            Console.Write("\n");
        }
        return map;
    }

}