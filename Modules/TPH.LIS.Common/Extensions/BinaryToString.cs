namespace TPH.LIS.Common.Extensions
{
    public class BinaryToString
    {
        /// <summary>
        /// Convert a Binary to String
        /// </summary>
        /// <param name="data">byte</param>
        /// <returns>String</returns>
        public static string ToBase64(byte[] data)
        {
            var length = data == null ? 0 : data.Length;
            if (length == 0)
                return string.Empty;

            var padding = length % 3;
            if (padding > 0)
                padding = 3 - padding;
            var blocks = (length - 1) / 3 + 1;

            var s = new char[blocks * 4];

            for (var i = 0; i < blocks; i++)
            {
                var finalBlock = i == blocks - 1;
                var pad2 = false;
                var pad1 = false;
                if (finalBlock)
                {
                    pad2 = padding == 2;
                    pad1 = padding > 0;
                }

                var index = i * 3;
                var b1 = data[index];
                var b2 = pad2 ? (byte)0 : data[index + 1];
                var b3 = pad1 ? (byte)0 : data[index + 2];

                var temp1 = (byte)((b1 & 0xFC) >> 2);

                var temp = (byte)((b1 & 0x03) << 4);
                var temp2 = (byte)((b2 & 0xF0) >> 4);
                temp2 += temp;

                temp = (byte)((b2 & 0x0F) << 2);
                byte temp3 = (byte)((b3 & 0xC0) >> 6);
                temp3 += temp;

                byte temp4 = (byte)(b3 & 0x3F);

                index = i * 4;
                s[index] = SixBitToChar(temp1);
                s[index + 1] = SixBitToChar(temp2);
                s[index + 2] = pad2 ? '=' : SixBitToChar(temp3);
                s[index + 3] = pad1 ? '=' : SixBitToChar(temp4);
            }

            var str = new string(s);

            return str;
        }

        private static char SixBitToChar(byte b)
        {
            char c;
            if (b < 26)
            {
                c = (char)((int)b + (int)'A');
            }
            else if (b < 52)
            {
                c = (char)((int)b - 26 + (int)'a');
            }
            else if (b < 62)
            {
                c = (char)((int)b - 52 + (int)'0');
            }
            else if (b == 62)
            {
                c = _sCharPlusSign;
            }
            else
            {
                c = _sCharSlash;
            }
            return c;
        }
        /// <summary>
        /// Convert a String to Binary
        /// </summary>
        /// <param name="s">String</param>
        /// <returns>Byte</returns>
        public static byte[] FromBase64(string s)
        {
            int length = s == null ? 0 : s.Length;
            if (length == 0)
                return new byte[0];

            int padding = 0;
            if (length > 2 && s[length - 2] == '=')
                padding = 2;
            else if (length > 1 && s[length - 1] == '=')
                padding = 1;

            int blocks = (length - 1) / 4 + 1;
            int bytes = blocks * 3;

            byte[] data = new byte[bytes - padding];

            for (int i = 0; i < blocks; i++)
            {
                bool finalBlock = i == blocks - 1;
                bool pad2 = false;
                bool pad1 = false;
                if (finalBlock)
                {
                    pad2 = padding == 2;
                    pad1 = padding > 0;
                }
                
                int index = i * 4;
                byte temp1 = CharToSixBit(s[index]);
                byte temp2 = CharToSixBit(s[index + 1]);
                byte temp3 = CharToSixBit(s[index + 2]);
                byte temp4 = CharToSixBit(s[index + 3]);

                byte b = (byte)(temp1 << 2);
                byte b1 = (byte)((temp2 & 0x30) >> 4);
                b1 += b;

                b = (byte)((temp2 & 0x0F) << 4);
                byte b2 = (byte)((temp3 & 0x3C) >> 2);
                b2 += b;

                b = (byte)((temp3 & 0x03) << 6);
                byte b3 = temp4;
                b3 += b;

                index = i * 3;
                data[index] = b1;
                if (!pad2)
                    data[index + 1] = b2;
                if (!pad1)
                    data[index + 2] = b3;
            }

            return data;
        }
        private static byte CharToSixBit(char c)
        {
            byte b;
            if (c >= 'A' && c <= 'Z')
            {
                b = (byte)((int)c - (int)'A');
            }
            else if (c >= 'a' && c <= 'z')
            {
                b = (byte)((int)c - (int)'a' + 26);
            }
            else if (c >= '0' && c <= '9')
            {
                b = (byte)((int)c - (int)'0' + 52);
            }
            else if (c == _sCharPlusSign)
            {
                b = (byte)62;
            }
            else
            {
                b = (byte)63;
            }
            return b;
        }

        private static char _sCharPlusSign = '+';
        /// <summary>
        /// Gets or sets the plus sign character.
        /// Default is '+'.
        /// </summary>
        static public char CharPlusSign
        {
            get
            {
                return _sCharPlusSign;
            }
            set
            {
                _sCharPlusSign = value;
            }
        }

        private static char _sCharSlash = '/';
        /// <summary>
        /// Gets or sets the slash character.
        /// Default is '/'.
        /// </summary>
        static public char CharSlash
        {
            get
            {
                return _sCharSlash;
            }
            set
            {
                _sCharSlash = value;
            }
        }
    }
}
