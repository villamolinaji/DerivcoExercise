namespace Question1.Utilities
{
    public class Transcode
    {
        private const int TRANSCODE_LENGTH = 64;
        private static char[] transcode = new char[TRANSCODE_LENGTH];

        public static void Init()
        {
            for (int i = 0; i < 64; i++)
            {
                transcode[i] = (char)((int)'A' + i);
                if (i > 51)
                {
                    transcode[i] = (char)((int)transcode[i] - 69);
                }
                else if (i > 25)
                {
                    transcode[i] = (char)((int)transcode[i] + 6);
                }
                
            }
            transcode[62] = '+';
            transcode[63] = '/';
            //transcode[64] = '=';
        }

        public static string Encode(string input)
        {
            int inputLength = input.Length;
            int outputLength = CalculateOutputLengthEncode(inputLength);

            char[] output = Enumerable.Repeat('=', outputLength).ToArray();

            int outputPosition = 0;
            int reflex = 0;
            const int transcodeLength = TRANSCODE_LENGTH - 1;

            for (int j = 0; j < inputLength; j++)
            {
                reflex <<= 8;
                reflex &= 0x00ffff00;
                reflex += input[j];

                int x = ((j % 3) + 1) * 2;
                int mask = transcodeLength << x;
                while (mask >= transcodeLength)
                {
                    int pivot = (reflex & mask) >> x;
                    output[outputPosition++] = transcode[pivot];                    
                    reflex &= ~mask;
                    mask >>= 6;
                    x -= 6;
                }
            }

            switch (inputLength % 3)
            {
                case 1:
                    reflex <<= 4;
                    output[outputPosition++] = transcode[reflex];
                    break;

                case 2:
                    reflex <<= 2;
                    output[outputPosition++] = transcode[reflex];
                    break;

            }

            string result = new string(output);
            Console.WriteLine("{0} --> {1}\n", input, result);
            return result;
        }

        public static string Decode(string input)
        {
            int inputLength = input.Length;
            int outputLength = CalculateOutputLengthDecode(inputLength);
            char[] output = new char[outputLength];
            int c = 0;
            int bits = 0;
            int reflex = 0;
            for (int j = 0; j < inputLength; j++)
            {
                reflex <<= 6;
                bits += 6;
                bool fTerminate = ('=' == input[j]);
                if (!fTerminate)
                {
                    reflex += IndexOf(input[j]);
                }

                while (bits >= 8)
                {
                    int mod8 = (bits % 8);
                    int mask = 0x000000ff << (bits % 8);
                    output[c++] = transcode[(reflex & mask) >> mod8];                    
                    reflex &= ~mask;
                    bits -= 8;
                }

                if (fTerminate)
                {
                    break;
                }
            }

            string result = new string(output);
            Console.WriteLine("{0} --> {1}\n", input, result);
            return result;
        }


        private static int CalculateOutputLengthEncode(int length)
        {
            return (length / 3 + (Convert.ToBoolean(length % 3) ? 1 : 0)) * 4;
        }

        private static int CalculateOutputLengthDecode(int length)
        {
            return (length / 4 + ((Convert.ToBoolean(length % 4)) ? 1 : 0)) * 3 + 1;
        }

        private static int IndexOf(char ch)
        {
            int index;
            for (index = 0; index < transcode.Length; index++)
            {
                if (ch == transcode[index])
                {
                    break;
                }
            }
            return index;
        }
    }
}
