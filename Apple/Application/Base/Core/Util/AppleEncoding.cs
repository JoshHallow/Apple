using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple.Application.Base.Core.Util
{
    class AppleEncoding
    {
        public int DecodeInt32(byte[] bzData)
        {
            int num = 0;
            int num2 = 0;
            for (int i = bzData.Length - 1; i >= 0; i--)
            {
                int num4 = bzData[i] - 0x40;
                if (num2 > 0)
                {
                    num4 *= (int)Math.Pow(64.0, (double)num2);
                }
                num += num4;
                num2++;
            }
            return num;
        }

        public uint DecodeUInt32(byte[] bzData)
        {
            return (uint)DecodeInt32(bzData);
        }

        public byte[] EncodeInt32(int i, int numBytes)
        {
            byte[] buffer = new byte[numBytes];
            for (int j = 1; j <= numBytes; j++)
            {
                int num2 = (numBytes - j) * 6;
                buffer[j - 1] = (byte)(0x40 + ((i >> num2) & 0x3f));
            }
            return buffer;
        }

        public byte[] EncodeUint32(uint i, int numBytes)
        {
            return EncodeInt32((int)i, numBytes);
        }
    }
}
