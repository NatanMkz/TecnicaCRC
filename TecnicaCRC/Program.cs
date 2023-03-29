using System;

namespace TecnicaCRC
{
    class Program
    {
        static void Main(string[] args)
        {
            // array de bits para proteger
            byte[] dados = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F, 0x10 };

            // Tamanho do polinômio CRC
            const ushort polinomio = 0x1021;

            // Valor inicial do registro CRC
            ushort register = 0xFFFF;

            // Cálculo do CRC
            foreach (byte b in dados)
            {
                register ^= (ushort)(b << 8);

                for (int i = 0; i < 8; i++)
                {
                    if ((register & 0x8000) != 0)
                    {
                        register = (ushort)((register << 1) ^ polinomio);
                    }
                    else
                    {
                        register <<= 1;
                    }
                }
            }

            // Resultado do CRC
            ushort crc = (ushort)(register ^ 0xFFFF);

            Console.WriteLine("CRC: 0x{0:X4}", crc);
        }
    }
}
