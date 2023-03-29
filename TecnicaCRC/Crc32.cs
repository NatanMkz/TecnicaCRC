using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnicaCRC
{
    public class Crc32
    {
        private const uint polinomio = 0x04C11DB7;

        private uint[] tabela = new uint[256];

        private uint Compute(byte[] bytes)
        {
            uint crc = 0xFFFFFFFF;

            foreach (byte b in bytes)
            {
                crc = (crc >> 8) ^ tabela[(crc & 0xFF) ^ b];
            }

            return crc ^ 0xFFFFFFFF;
        }

        public uint ComputeChecksum(uint[] data)
        {
            byte[] bytes = new byte[data.Length * 4];
            Buffer.BlockCopy(data, 0, bytes, 0, bytes.Length);
            return Compute(bytes);
        }

        public void GenerateTable()
        {
            for (uint i = 0; i < tabela.Length; i++)
            {
                uint crc = i;

                for (int j = 0; j < 8; j++)
                {
                    if ((crc & 1) == 1)
                    {
                        crc = (crc >> 1) ^ polinomio;
                    }
                    else
                    {
                        crc >>= 1;
                    }
                }

                tabela[i] = crc;
            }
        }
    }
}
