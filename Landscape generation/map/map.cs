class Map
{
    public Map(uint size)
    {
        cells = new Cell[size, size];
    }
    
    public Cell[,] cells;
}