class BmpHeader
{

    private byte[] FileHeader = {
        0x42, 0x4D, //BM
        0, 0, 0, 0, //size of file
        0, 0,       //reserved
        0, 0,       //reserved
        26, 0, 0, 0 //offset to pixel array
    };

    private byte[] DIBHeader = {
        12, 0, 0, 0,    //header size
        0, 0,           //image width
        0, 0,           //image height
        1, 0,           //color planes (const)
        24, 0           //bits per pixel
    };
    
    private Int32 headersSize = 26;

    public byte[] getHeader(Int16 width, Int16 height)
    {
        Int32 padding = (width * 3) % 4;
        Int32 sizeOfFile = headersSize + (3 * width + padding) * height;
        BitConverter.GetBytes(sizeOfFile).CopyTo(FileHeader, 2);
        BitConverter.GetBytes(width).CopyTo(DIBHeader, 4);
        BitConverter.GetBytes(height).CopyTo(DIBHeader, 6);

        byte[] header =  new byte[headersSize];
        FileHeader.CopyTo(header, 0);
        DIBHeader.CopyTo(header, 14);

        return header;
    }
}