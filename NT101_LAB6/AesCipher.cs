using System;
using System.Text;

namespace NT101_LAB6
{
    public static class AesCipher
    {
        //Cac bang hang cua AES-128
        private static readonly byte[] SBox =
        {
            0x63,0x7c,0x77,0x7b,0xf2,0x6b,0x6f,0xc5,0x30,0x01,0x67,0x2b,0xfe,0xd7,0xab,0x76,
            0xca,0x82,0xc9,0x7d,0xfa,0x59,0x47,0xf0,0xad,0xd4,0xa2,0xaf,0x9c,0xa4,0x72,0xc0,
            0xb7,0xfd,0x93,0x26,0x36,0x3f,0xf7,0xcc,0x34,0xa5,0xe5,0xf1,0x71,0xd8,0x31,0x15,
            0x04,0xc7,0x23,0xc3,0x18,0x96,0x05,0x9a,0x07,0x12,0x80,0xe2,0xeb,0x27,0xb2,0x75,
            0x09,0x83,0x2c,0x1a,0x1b,0x6e,0x5a,0xa0,0x52,0x3b,0xd6,0xb3,0x29,0xe3,0x2f,0x84,
            0x53,0xd1,0x00,0xed,0x20,0xfc,0xb1,0x5b,0x6a,0xcb,0xbe,0x39,0x4a,0x4c,0x58,0xcf,
            0xd0,0xef,0xaa,0xfb,0x43,0x4d,0x33,0x85,0x45,0xf9,0x02,0x7f,0x50,0x3c,0x9f,0xa8,
            0x51,0xa3,0x40,0x8f,0x92,0x9d,0x38,0xf5,0xbc,0xb6,0xda,0x21,0x10,0xff,0xf3,0xd2,
            0xcd,0x0c,0x13,0xec,0x5f,0x97,0x44,0x17,0xc4,0xa7,0x7e,0x3d,0x64,0x5d,0x19,0x73,
            0x60,0x81,0x4f,0xdc,0x22,0x2a,0x90,0x88,0x46,0xee,0xb8,0x14,0xde,0x5e,0x0b,0xdb,
            0xe0,0x32,0x3a,0x0a,0x49,0x06,0x24,0x5c,0xc2,0xd3,0xac,0x62,0x91,0x95,0xe4,0x79,
            0xe7,0xc8,0x37,0x6d,0x8d,0xd5,0x4e,0xa9,0x6c,0x56,0xf4,0xea,0x65,0x7a,0xae,0x08,
            0xba,0x78,0x25,0x2e,0x1c,0xa6,0xb4,0xc6,0xe8,0xdd,0x74,0x1f,0x4b,0xbd,0x8b,0x8a,
            0x70,0x3e,0xb5,0x66,0x48,0x03,0xf6,0x0e,0x61,0x35,0x57,0xb9,0x86,0xc1,0x1d,0x9e,
            0xe1,0xf8,0x98,0x11,0x69,0xd9,0x8e,0x94,0x9b,0x1e,0x87,0xe9,0xce,0x55,0x28,0xdf,
            0x8c,0xa1,0x89,0x0d,0xbf,0xe6,0x42,0x68,0x41,0x99,0x2d,0x0f,0xb0,0x54,0xbb,0x16
        };

        //Nghich dao cua SBox (dung trong giai ma)
        private static readonly byte[] InvSBox =
        {
            0x52,0x09,0x6a,0xd5,0x30,0x36,0xa5,0x38,0xbf,0x40,0xa3,0x9e,0x81,0xf3,0xd7,0xfb,
            0x7c,0xe3,0x39,0x82,0x9b,0x2f,0xff,0x87,0x34,0x8e,0x43,0x44,0xc4,0xde,0xe9,0xcb,
            0x54,0x7b,0x94,0x32,0xa6,0xc2,0x23,0x3d,0xee,0x4c,0x95,0x0b,0x42,0xfa,0xc3,0x4e,
            0x08,0x2e,0xa1,0x66,0x28,0xd9,0x24,0xb2,0x76,0x5b,0xa2,0x49,0x6d,0x8b,0xd1,0x25,
            0x72,0xf8,0xf6,0x64,0x86,0x68,0x98,0x16,0xd4,0xa4,0x5c,0xcc,0x5d,0x65,0xb6,0x92,
            0x6c,0x70,0x48,0x50,0xfd,0xed,0xb9,0xda,0x5e,0x15,0x46,0x57,0xa7,0x8d,0x9d,0x84,
            0x90,0xd8,0xab,0x00,0x8c,0xbc,0xd3,0x0a,0xf7,0xe4,0x58,0x05,0xb8,0xb3,0x45,0x06,
            0xd0,0x2c,0x1e,0x8f,0xca,0x3f,0x0f,0x02,0xc1,0xaf,0xbd,0x03,0x01,0x13,0x8a,0x6b,
            0x3a,0x91,0x11,0x41,0x4f,0x67,0xdc,0xea,0x97,0xf2,0xcf,0xce,0xf0,0xb4,0xe6,0x73,
            0x96,0xac,0x74,0x22,0xe7,0xad,0x35,0x85,0xe2,0xf9,0x37,0xe8,0x1c,0x75,0xdf,0x6e,
            0x47,0xf1,0x1a,0x71,0x1d,0x29,0xc5,0x89,0x6f,0xb7,0x62,0x0e,0xaa,0x18,0xbe,0x1b,
            0xfc,0x56,0x3e,0x4b,0xc6,0xd2,0x79,0x20,0x9a,0xdb,0xc0,0xfe,0x78,0xcd,0x5a,0xf4,
            0x1f,0xdd,0xa8,0x33,0x88,0x07,0xc7,0x31,0xb1,0x12,0x10,0x59,0x27,0x80,0xec,0x5f,
            0x60,0x51,0x7f,0xa9,0x19,0xb5,0x4a,0x0d,0x2d,0xe5,0x7a,0x9f,0x93,0xc9,0x9c,0xef,
            0xa0,0xe0,0x3b,0x4d,0xae,0x2a,0xf5,0xb0,0xc8,0xeb,0xbb,0x3c,0x83,0x53,0x99,0x61,
            0x17,0x2b,0x04,0x7e,0xba,0x77,0xd6,0x26,0xe1,0x69,0x14,0x63,0x55,0x21,0x0c,0x7d
        };

        //Hang so round dung trong Key Expansion
        private static readonly byte[] Rcon =
        {
            0x00,
            0x01,0x02,0x04,0x08,0x10,0x20,0x40,0x80,0x1B,0x36
        };

        private const int Nb = 4;
        private const int Nk = 4;
        private const int Nr = 10;
        private const int BlockSize = 16;

        public static (byte[] Ciphertext, byte[] Iv) Encrypt(byte[] plaintext, byte[] key, string mode, byte[] iv = null)
        {
            if (key == null || key.Length != 16)
                throw new ArgumentException("AES-128 key must be exactly 16 bytes.");

            mode = mode.ToUpperInvariant();
            byte[] expandedKey = KeyExpansion(key);

            switch (mode)
            {
                case "ECB":
                    return (EncryptEcb(plaintext, expandedKey), null);

                case "CBC":
                    return EncryptCbc(plaintext, expandedKey, iv);

                default:
                    throw new ArgumentException("Unsupported mode. Use ECB or CBC.");
            }
        }

        public static byte[] Decrypt(byte[] ciphertext, byte[] key, string mode, byte[] iv)
        {
            if (key == null || key.Length != 16)
                throw new ArgumentException("AES-128 key must be exactly 16 bytes.");

            mode = mode.ToUpperInvariant();
            byte[] expandedKey = KeyExpansion(key);

            switch (mode)
            {
                case "ECB":
                    return DecryptEcb(ciphertext, expandedKey);

                case "CBC":
                    if (iv == null || iv.Length != 16)
                        throw new ArgumentException("IV must be 16 bytes for CBC.");
                    return DecryptCbc(ciphertext, expandedKey, iv);

                default:
                    throw new ArgumentException("Unsupported mode. Use ECB or CBC.");
            }
        }
        //Ma hoa tung block 16 byte doc lap
        private static byte[] EncryptEcb(byte[] plaintext, byte[] expandedKey)
        {
            byte[] padded = Pkcs7Pad(plaintext, BlockSize); //pad de do dai la boi so cua 16
            byte[] output = new byte[padded.Length];

            // Moi block 16 byte duoc ma hoa doc lap
            for (int i = 0; i < padded.Length; i += BlockSize)
            {
                byte[] block = new byte[BlockSize];
                Buffer.BlockCopy(padded, i, block, 0, BlockSize);

                byte[] enc = CipherBlock(block, expandedKey); //Ma hoa 1 block AES
                Buffer.BlockCopy(enc, 0, output, i, BlockSize);
            }

            return output;
        }

        //Giai tung block 16 byte doc lap
        private static byte[] DecryptEcb(byte[] ciphertext, byte[] expandedKey)
        {
            if (ciphertext.Length % BlockSize != 0) //kiem tra do dai hop le
                throw new ArgumentException("Ciphertext length must be multiple of 16 bytes.");

            byte[] output = new byte[ciphertext.Length];

            for (int i = 0; i < ciphertext.Length; i += BlockSize)
            {
                byte[] block = new byte[BlockSize];
                Buffer.BlockCopy(ciphertext, i, block, 0, BlockSize);

                byte[] dec = InvCipherBlock(block, expandedKey); //Giai ma 1 block AES
                Buffer.BlockCopy(dec, 0, output, i, BlockSize);
            }

            return Pkcs7Unpad(output, BlockSize); //Bo pad sau khi giai ma de tra ve ban ro
        }

        private static (byte[] Ciphertext, byte[] Iv) EncryptCbc(byte[] plaintext, byte[] expandedKey, byte[] iv)
        {
            byte[] padded = Pkcs7Pad(plaintext, BlockSize);

            // random 16 byte IV neu iv truyen vao la null
            if (iv == null) 
            {
                iv = new byte[BlockSize];
                var rnd = new Random();
                rnd.NextBytes(iv);
            }

            byte[] output = new byte[padded.Length];
            byte[] prev = (byte[])iv.Clone();

            // Moi block Xor voi block truoc do (hoac IV neu la block dau tien) truoc khi ma hoa
            for (int i = 0; i < padded.Length; i += BlockSize)
            {
                byte[] block = new byte[BlockSize];
                Buffer.BlockCopy(padded, i, block, 0, BlockSize);

                for (int j = 0; j < BlockSize; j++)
                    block[j] ^= prev[j];

                byte[] enc = CipherBlock(block, expandedKey);
                Buffer.BlockCopy(enc, 0, output, i, BlockSize);
                prev = enc;
            }

            return (output, iv);
        }

        private static byte[] DecryptCbc(byte[] ciphertext, byte[] expandedKey, byte[] iv)
        {
            if (ciphertext.Length % BlockSize != 0)
                throw new ArgumentException("Ciphertext length must be multiple of 16 bytes.");

            byte[] output = new byte[ciphertext.Length];
            byte[] prev = (byte[])iv.Clone();

            //Voi moi block ciphertext
            for (int i = 0; i < ciphertext.Length; i += BlockSize)
            {
                byte[] block = new byte[BlockSize];
                Buffer.BlockCopy(ciphertext, i, block, 0, BlockSize);

                byte[] dec = InvCipherBlock(block, expandedKey); //Plaintext da Xor

                for (int j = 0; j < BlockSize; j++)
                    dec[j] ^= prev[j];

                Buffer.BlockCopy(dec, 0, output, i, BlockSize);
                prev = block; //cipher block hien tai tro thanh prev cho lan lap tiep theo
            }

            return Pkcs7Unpad(output, BlockSize);
        }


        //Xor round key 0 vao state, sau do thuc hien Nr vong lap
        private static byte[] CipherBlock(byte[] input, byte[] expandedKey)
        {
            byte[,] state = new byte[4, Nb];

            for (int i = 0; i < 16; i++)
                state[i % 4, i / 4] = input[i];

            AddRoundKey(state, expandedKey, 0);

            for (int round = 1; round < Nr; round++)
            {
                SubBytes(state); //thay byte qua SBox
                ShiftRows(state); //Xoay hang
                MixColumns(state); //Tron cot
                AddRoundKey(state, expandedKey, round); //XOR round key 
            }

            //round cuoi khong co MixColumns, tra ve encblock
            SubBytes(state);
            ShiftRows(state);
            AddRoundKey(state, expandedKey, Nr);

            byte[] output = new byte[16];
            for (int i = 0; i < 16; i++)
                output[i] = state[i % 4, i / 4];

            return output;
        }

        //Xor round key cuoi truoc
        private static byte[] InvCipherBlock(byte[] input, byte[] expandedKey)
        {
            byte[,] state = new byte[4, Nb];

            for (int i = 0; i < 16; i++)
                state[i % 4, i / 4] = input[i];

            AddRoundKey(state, expandedKey, Nr);

            for (int round = Nr - 1; round >= 1; round--)
            {
                InvShiftRows(state); //Dao nguoc buoc ShiftRows
                InvSubBytes(state); //Thay byte bang bang InvSBox
                AddRoundKey(state, expandedKey, round); 
                InvMixColumns(state); //Tron cot nguoc
            }

            InvShiftRows(state);
            InvSubBytes(state);
            AddRoundKey(state, expandedKey, 0);

            byte[] output = new byte[16];
            for (int i = 0; i < 16; i++)
                output[i] = state[i % 4, i / 4];

            return output;
        }

        //Thay moi byte trong state bang bang SBox
        private static void SubBytes(byte[,] state)
        {
            for (int r = 0; r < 4; r++)
                for (int c = 0; c < Nb; c++)
                    state[r, c] = SBox[state[r, c]];
        }

        //Dao nguoc buoc SubBytes
        private static void InvSubBytes(byte[,] state)
        {
            for (int r = 0; r < 4; r++)
                for (int c = 0; c < Nb; c++)
                    state[r, c] = InvSBox[state[r, c]];
        }

        //Xoay hang cua state
        private static void ShiftRows(byte[,] state)
        {
            byte tmp;

            tmp = state[1, 0];
            state[1, 0] = state[1, 1];
            state[1, 1] = state[1, 2];
            state[1, 2] = state[1, 3];
            state[1, 3] = tmp;

            tmp = state[2, 0];
            state[2, 0] = state[2, 2];
            state[2, 2] = tmp;
            tmp = state[2, 1];
            state[2, 1] = state[2, 3];
            state[2, 3] = tmp;

            tmp = state[3, 3];
            state[3, 3] = state[3, 2];
            state[3, 2] = state[3, 1];
            state[3, 1] = state[3, 0];
            state[3, 0] = tmp;
        }

        //Dao nguoc buoc ShiftRows
        private static void InvShiftRows(byte[,] state)
        {
            byte tmp;

            tmp = state[1, 3];
            state[1, 3] = state[1, 2];
            state[1, 2] = state[1, 1];
            state[1, 1] = state[1, 0];
            state[1, 0] = tmp;

            tmp = state[2, 0];
            state[2, 0] = state[2, 2];
            state[2, 2] = tmp;
            tmp = state[2, 1];
            state[2, 1] = state[2, 3];
            state[2, 3] = tmp;

            tmp = state[3, 0];
            state[3, 0] = state[3, 1];
            state[3, 1] = state[3, 2];
            state[3, 2] = state[3, 3];
            state[3, 3] = tmp;
        }

        //Nhan hai byte trong field GF(2^8)
        private static byte Multiply(byte x, byte y)
        {
            byte result = 0;
            byte temp = x;

            for (int i = 0; i < 8; i++)
            {
                if ((y & 1) != 0)
                    result ^= temp;
                bool hiBitSet = (temp & 0x80) != 0;
                temp <<= 1;
                if (hiBitSet)
                    temp ^= 0x1b;
                y >>= 1;
            }

            return result;
        }

        //Tron cot cua state
        private static void MixColumns(byte[,] state)
        {
            for (int c = 0; c < 4; c++)
            {
                byte a0 = state[0, c];
                byte a1 = state[1, c];
                byte a2 = state[2, c];
                byte a3 = state[3, c];

                state[0, c] = (byte)(Multiply(0x02, a0) ^ Multiply(0x03, a1) ^ a2 ^ a3);
                state[1, c] = (byte)(a0 ^ Multiply(0x02, a1) ^ Multiply(0x03, a2) ^ a3);
                state[2, c] = (byte)(a0 ^ a1 ^ Multiply(0x02, a2) ^ Multiply(0x03, a3));
                state[3, c] = (byte)(Multiply(0x03, a0) ^ a1 ^ a2 ^ Multiply(0x02, a3));
            }
        }

        //Tron cot nguoc cua state
        private static void InvMixColumns(byte[,] state)
        {
            for (int c = 0; c < 4; c++)
            {
                byte a0 = state[0, c];
                byte a1 = state[1, c];
                byte a2 = state[2, c];
                byte a3 = state[3, c];

                state[0, c] = (byte)(Multiply(0x0e, a0) ^ Multiply(0x0b, a1) ^ Multiply(0x0d, a2) ^ Multiply(0x09, a3));
                state[1, c] = (byte)(Multiply(0x09, a0) ^ Multiply(0x0e, a1) ^ Multiply(0x0b, a2) ^ Multiply(0x0d, a3));
                state[2, c] = (byte)(Multiply(0x0d, a0) ^ Multiply(0x09, a1) ^ Multiply(0x0e, a2) ^ Multiply(0x0b, a3));
                state[3, c] = (byte)(Multiply(0x0b, a0) ^ Multiply(0x0d, a1) ^ Multiply(0x09, a2) ^ Multiply(0x0e, a3));
            }
        }

        //Xor round key vao state
        private static void AddRoundKey(byte[,] state, byte[] expandedKey, int round)
        {
            int start = round * 16;
            for (int c = 0; c < 4; c++)
            {
                for (int r = 0; r < 4; r++)
                {
                    state[r, c] ^= expandedKey[start + c * 4 + r];
                }
            }
        }

        // Tu key 16 byte tao ra expanded key cho cac round
        private static byte[] KeyExpansion(byte[] key)
        {
            byte[] w = new byte[Nb * (Nr + 1) * 4];
            Buffer.BlockCopy(key, 0, w, 0, 16);

            int bytesGenerated = 16;
            int rconIter = 1;
            byte[] temp = new byte[4];

            while (bytesGenerated < w.Length)
            {
                for (int i = 0; i < 4; i++)
                    temp[i] = w[bytesGenerated - 4 + i];

                if (bytesGenerated % 16 == 0)
                {
                    byte t = temp[0];
                    temp[0] = temp[1];
                    temp[1] = temp[2];
                    temp[2] = temp[3];
                    temp[3] = t;

                    for (int i = 0; i < 4; i++)
                        temp[i] = SBox[temp[i]];

                    temp[0] ^= Rcon[rconIter++];
                }

                for (int i = 0; i < 4; i++)
                {
                    w[bytesGenerated] = (byte)(w[bytesGenerated - 16] ^ temp[i]);
                    bytesGenerated++;
                }
            }

            return w;
        }

        //PKCS7 Padding va Unpadding de dam bao du lieu co do dai boi so cua 16
        private static byte[] Pkcs7Pad(byte[] data, int blockSize)
        {
            int padLen = blockSize - (data.Length % blockSize);
            if (padLen == 0) padLen = blockSize;

            byte[] result = new byte[data.Length + padLen];
            Buffer.BlockCopy(data, 0, result, 0, data.Length);
            for (int i = data.Length; i < result.Length; i++)
                result[i] = (byte)padLen;
            return result;
        }

        private static byte[] Pkcs7Unpad(byte[] data, int blockSize)
        {
            if (data.Length == 0)
                throw new ArgumentException("Invalid padded data.");

            int padLen = data[data.Length - 1];
            if (padLen <= 0 || padLen > blockSize || padLen > data.Length)
                throw new ArgumentException("Invalid PKCS7 padding.");

            for (int i = data.Length - padLen; i < data.Length; i++)
            {
                if (data[i] != padLen)
                    throw new ArgumentException("Invalid PKCS7 padding.");
            }

            int newLen = data.Length - padLen;
            byte[] result = new byte[newLen];
            Buffer.BlockCopy(data, 0, result, 0, newLen);
            return result;
        }

        public static string ToHex(byte[] data)
        {
            var sb = new StringBuilder(data.Length * 2);
            foreach (byte b in data)
                sb.AppendFormat("{0:X2}", b);
            return sb.ToString();
        }

        public static string ToPrettyHex(byte[] data, int bytesPerLine = 16)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sb.AppendFormat("{0:X2}", data[i]);
                if (i < data.Length - 1)
                    sb.Append(" ");

                if ((i + 1) % bytesPerLine == 0)
                    sb.AppendLine();
            }
            return sb.ToString();
        }

        public static byte[] FromHex(string hex)
        {
            if (hex == null)
                throw new ArgumentNullException(nameof(hex));

            var sb = new StringBuilder();
            foreach (char c in hex)
            {
                if (!char.IsWhiteSpace(c))
                    sb.Append(c);
            }

            string cleanHex = sb.ToString();
            if (cleanHex.Length % 2 != 0)
                throw new ArgumentException("Invalid hex string length.");

            byte[] result = new byte[cleanHex.Length / 2];
            for (int i = 0; i < result.Length; i++)
            {
                string byteStr = cleanHex.Substring(i * 2, 2);
                result[i] = Convert.ToByte(byteStr, 16);
            }
            return result;
        }
    }
}
