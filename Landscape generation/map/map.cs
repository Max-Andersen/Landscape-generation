public class Map
{

    public Map(uint size)
    {
        cells = new Cell[size, size];

        for (int i = 0; i < size; ++i)
        {
            for (int j = 0; j < size; ++j)
            {
                cells[i, j] = new Cell();
            }
        }
    }
    
    public Cell[,] cells;
}