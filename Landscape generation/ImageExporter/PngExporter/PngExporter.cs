class PngExporter : ImageExporter
{
    void ImageExporter.Export(Map map, string filename)
    {
        FileStream file = new FileStream(filename, FileMode.Create, FileAccess.Write);
        
        int height = map.cells.GetLength(0);
        int width = map.cells.GetLength(1);
        
        PngHeader header = new PngHeader();
        file.Write(header.GetHeader(width, height));
        file.Write(IDATChunk.getChunk(map));
        file.Write(IENDChunk.getChunk());
        file.Close();
    }
}