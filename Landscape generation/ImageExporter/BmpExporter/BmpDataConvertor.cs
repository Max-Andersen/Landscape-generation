static class BmpDataConvertor
{
    public static byte[] getPixelArray(Map map)
    {
        int height = map.cells.GetLength(0);
        int width = map.cells.GetLength(1);
        int padding = (width * 3) % 4;
        List<byte> pixelArray = new List<byte>();// new byte[(3 * width + padding) * height];

        for (int y = height - 1; y >= 0; y--) {
            for (int x = 0; x < width;  x++) {
                Color color = map.cells[x, y].color;
                pixelArray.Add(color.blue);
                pixelArray.Add(color.green);
                pixelArray.Add(color.red);
            }
            for (int i = 0; i < padding; i++) {
                pixelArray.Add(0x00);
            }
        }

        return pixelArray.ToArray();
    }
}