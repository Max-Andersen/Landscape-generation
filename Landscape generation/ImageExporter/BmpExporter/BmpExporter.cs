class BmpExporter : ImageExporter
{
    void ImageExporter.Export(Map map, string filename)
    {
        Int16 height = (Int16)map.cells.GetLength(0);
        Int16 width = (Int16)map.cells.GetLength(1);
        FileStream file = new FileStream(filename, FileMode.Create, FileAccess.Write);
        
        BmpHeader header = new BmpHeader();
        file.Write(header.getHeader(width, height));
        file.Write(BmpDataConvertor.getPixelArray(map));
        file.Close();
    }
}