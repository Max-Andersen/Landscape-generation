public class Map
{
    public uint size;
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

        this.size = size;
    }

    public bool isInMapBounds(int x, int y)
    {
        bool flag = false || x >= 0 & x < size & 0 <= y & y < size;
        return flag;
    }
    
    public Cell[,] cells;
}