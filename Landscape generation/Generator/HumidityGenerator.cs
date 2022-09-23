namespace Landscape_generation.Generator;

public class HumidityGenerator : MapModifier
{
    private Random _random = new Random();
    private const int sizeSquare = 2;

    public HumidityGenerator(Map map)
    {
        
    }
    
    public Map modify(Map map)
    {
        map = humidityDefault(map);
        int x = 0, y = 0;
        while (x < map.size | y <= map.size)
        {
            if (y == map.size)
            {
                x++;
                y = 0;
            }
            
            if (x == map.size) break;

            map.cells[x, y].humidity = averageAroundSquare(map, x, y);
            y++;
        }
        
        for (int i = 0; i < map.size; i++)
        {
            for (int j = 0; j < map.size; j++)
            {
                Console.Write(map.cells[i, j].humidity + " ");
            }
            Console.Write("\n");
        }

        return map;
    }

    public Map humidityDefault(Map map, int x = 0, int y = 0)
    {
        while (x < map.size | y <= map.size)
        {
            if (y == map.size)
            {
                x++;
                y = 0;
            }

            if (x == map.size) break;
            
            if (map.cells[x, y].height < 0)
            {
                map.cells[x, y].humidity = _random.Next(60, 101);
            }
            /*else if (map.cells[x,y].height >= 0 & map.cells[x,y].height < 50)
            {
                map.cells[x, y].humidity = _random.Next(40, 70);
            }*/
            else
            {
                map.cells[x, y].humidity = _random.Next(10, 30);
            }

            y++;
        }

        return map;
    }

    public int averageAroundSquare(Map map, int x, int y)
    {
        int sum = 0, k = 0;
        for (int i = -sizeSquare; i <= sizeSquare; i++)
        {
            for (int j = -sizeSquare; j <= sizeSquare; j++)
            {
                if (map.isInMapBounds(x + i, y + j))
                {
                    sum += map.cells[x + i, y + j].humidity;
                    k++;
                }
            }
        }
        
        return sum / k;
    }
}