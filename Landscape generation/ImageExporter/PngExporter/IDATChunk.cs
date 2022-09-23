using System.IO.Hashing;
using System.IO.Compression;

static class IDATChunk
{
    static private byte[] IDAT = {0x49, 0x44, 0x41, 0x54}; 

    public static byte[] getChunk(Map map)
    {
        MemoryStream chunkContent = applyFilters(map);
        chunkContent = compress(chunkContent);
        byte[] chunkContentArray = chunkContent.ToArray();
        int contentLen = chunkContentArray.Length;
        chunkContent.Close();
        
        byte[] chunk = new byte[contentLen + 12];
        
        byte[] chunkLenBytes = BitConverter.GetBytes(contentLen);
        Array.Reverse(chunkLenBytes);
        chunkLenBytes.CopyTo(chunk, 0);

        IDAT.CopyTo(chunk, 4);
        chunkContentArray.CopyTo(chunk, 8);
        byte[] hash = Crc32.Hash(chunk[4..^4]);
        Array.Reverse(hash);
        hash.CopyTo(chunk, contentLen + 8);

        return chunk;
    }

    private static MemoryStream compress(MemoryStream input)
    {
        MemoryStream output = new MemoryStream();
        using var compressor = new ZLibStream(output, CompressionMode.Compress, true);
        input.Seek(0, SeekOrigin.Begin);
        input.CopyTo(compressor);
        input.Close();
        
        return output;
    }

    private static MemoryStream applyFilters(Map map) 
    {        
        int width = map.cells.GetLength(0);
        int height = map.cells.GetLength(1);

        MemoryStream filteredImage = new MemoryStream();

        for (int y = 0; y < height; y++) {
            filteredImage.WriteByte(0x00);
            for (int x = 0; x < width; x++) {
                Color color = map.cells[x, y].color;
                filteredImage.WriteByte(color.red);
                filteredImage.WriteByte(color.green);
                filteredImage.WriteByte(color.blue);
            }
        }

        return filteredImage;
    }
    
}