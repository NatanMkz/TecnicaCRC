using System;

namespace TecnicaCRC
{
    class Program
    {
        static void Main(string[] args)
        {
            uint[] data = { 0x12345678, 0xAABBCCDD, 0xEEFF0011, 0x22334455 };
            Crc32 crc = new Crc32();
            crc.GenerateTable();
            uint checksum = crc.ComputeChecksum(data);
            Console.WriteLine("Checksum: 0x{0:X8}", checksum);
        }
    }
}
