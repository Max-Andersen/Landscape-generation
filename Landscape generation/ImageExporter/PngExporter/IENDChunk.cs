static class IENDChunk 
{
    public static byte[] getChunk()
    {
        byte[] chunk = {0x00, 0x00, 0x00, 0x00,
                        0x49, 0x45, 0x4E, 0x44,
                        0xAE, 0x42, 0x60, 0x82};

        return chunk;
    }
}