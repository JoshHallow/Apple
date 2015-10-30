using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple.Application.Base.Core.Util
{
    class AppleEncoding
    {
        public int DecodeInt32(byte[] v)
        {
            if ((v[0] | v[1] | v[2] | v[3]) < 0)
                return -1;
            return ((v[0] << 24) + (v[1] << 16) + (v[2] << 8) + (v[3]));
        }

        public Int16 DecodeInt16(byte[] v)
        {
            if ((v[0] | v[1]) < 0)
                return -1;
            var result = ((v[0] << 8) + (v[1]));
            return (Int16)result;
        }

        public uint DecodeUInt32(byte[] bzData)
        {
            return (uint)DecodeInt32(bzData);
        }
    }
}
