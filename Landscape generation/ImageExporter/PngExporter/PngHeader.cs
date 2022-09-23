using System.IO.Hashing;

class PngHeader
{
    private byte[] header = {   0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A, // PNG signature 
                                0, 0, 0, 13,                                    // chunk size
                                0x49, 0x48, 0x44, 0x52,                         // chunk type (IHDR) 
                                0, 0, 0, 0,                                     // width
                                0, 0, 0, 0,                                     // height
                                8,                                              // bit depth
                                2,                                              // color type (rgb)
                                0,                                              // compression method
                                0,                                              // filter method
                                0,                                              // interlace method
                                0, 0, 0, 0                                      // CRC of chunk
                            }; 


    public byte[] GetHeader(Int32 width, Int32 height)
    {
        byte[] widthBytes = BitConverter.GetBytes(width);
        byte[] heightBytes = BitConverter.GetBytes(width);
        Array.Reverse(widthBytes);
        Array.Reverse(heightBytes);
        widthBytes.CopyTo(header, 16);
        heightBytes.CopyTo(header, 20);

        byte[] hash = Crc32.Hash(header[12..29]);
        Array.Reverse(hash);
        hash.CopyTo(header, 29);
        return header;
    }
}
 
