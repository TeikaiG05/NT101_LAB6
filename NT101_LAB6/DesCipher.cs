using System;
using System.Text;

namespace NT101_LAB6
{
    public static class DesCipher
    {
        // Cac bang hoan vi va S-box duoc su dung trong DES
        private static readonly int[] IP =
        {
            58,50,42,34,26,18,10,2,
            60,52,44,36,28,20,12,4,
            62,54,46,38,30,22,14,6,
            64,56,48,40,32,24,16,8,
            57,49,41,33,25,17,9,1,
            59,51,43,35,27,19,11,3,
            61,53,45,37,29,21,13,5,
            63,55,47,39,31,23,15,7
        };

        private static readonly int[] FP =
        {
            40,8,48,16,56,24,64,32,
            39,7,47,15,55,23,63,31,
            38,6,46,14,54,22,62,30,
            37,5,45,13,53,21,61,29,
            36,4,44,12,52,20,60,28,
            35,3,43,11,51,19,59,27,
            34,2,42,10,50,18,58,26,
            33,1,41,9,49,17,57,25
        };

        private static readonly int[] E =
        {
            32,1,2,3,4,5,
            4,5,6,7,8,9,
            8,9,10,11,12,13,
            12,13,14,15,16,17,
            16,17,18,19,20,21,
            20,21,22,23,24,25,
            24,25,26,27,28,29,
            28,29,30,31,32,1
        };

        private static readonly int[] P =
        {
            16,7,20,21,29,12,28,17,
            1,15,23,26,5,18,31,10,
            2,8,24,14,32,27,3,9,
            19,13,30,6,22,11,4,25
        };

        private static readonly int[,] S1 =
        {
            {14,4,13,1,2,15,11,8,3,10,6,12,5,9,0,7},
            {0,15,7,4,14,2,13,1,10,6,12,11,9,5,3,8},
            {4,1,14,8,13,6,2,11,15,12,9,7,3,10,5,0},
            {15,12,8,2,4,9,1,7,5,11,3,14,10,0,6,13}
        };

        private static readonly int[,] S2 =
        {
            {15,1,8,14,6,11,3,4,9,7,2,13,12,0,5,10},
            {3,13,4,7,15,2,8,14,12,0,1,10,6,9,11,5},
            {0,14,7,11,10,4,13,1,5,8,12,6,9,3,2,15},
            {13,8,10,1,3,15,4,2,11,6,7,12,0,5,14,9}
        };

        private static readonly int[,] S3 =
        {
            {10,0,9,14,6,3,15,5,1,13,12,7,11,4,2,8},
            {13,7,0,9,3,4,6,10,2,8,5,14,12,11,15,1},
            {13,6,4,9,8,15,3,0,11,1,2,12,5,10,14,7},
            {1,10,13,0,6,9,8,7,4,15,14,3,11,5,2,12}
        };

        private static readonly int[,] S4 =
        {
            {7,13,14,3,0,6,9,10,1,2,8,5,11,12,4,15},
            {13,8,11,5,6,15,0,3,4,7,2,12,1,10,14,9},
            {10,6,9,0,12,11,7,13,15,1,3,14,5,2,8,4},
            {3,15,0,6,10,1,13,8,9,4,5,11,12,7,2,14}
        };

        private static readonly int[,] S5 =
        {
            {2,12,4,1,7,10,11,6,8,5,3,15,13,0,14,9},
            {14,11,2,12,4,7,13,1,5,0,15,10,3,9,8,6},
            {4,2,1,11,10,13,7,8,15,9,12,5,6,3,0,14},
            {11,8,12,7,1,14,2,13,6,15,0,9,10,4,5,3}
        };

        private static readonly int[,] S6 =
        {
            {12,1,10,15,9,2,6,8,0,13,3,4,14,7,5,11},
            {10,15,4,2,7,12,9,5,6,1,13,14,0,11,3,8},
            {9,14,15,5,2,8,12,3,7,0,4,10,1,13,11,6},
            {4,3,2,12,9,5,15,10,11,14,1,7,6,0,8,13}
        };

        private static readonly int[,] S7 =
        {
            {4,11,2,14,15,0,8,13,3,12,9,7,5,10,6,1},
            {13,0,11,7,4,9,1,10,14,3,5,12,2,15,8,6},
            {1,4,11,13,12,3,7,14,10,15,6,8,0,5,9,2},
            {6,11,13,8,1,4,10,7,9,5,0,15,14,2,3,12}
        };

        private static readonly int[,] S8 =
        {
            {13,2,8,4,6,15,11,1,10,9,3,14,5,0,12,7},
            {1,15,13,8,10,3,7,4,12,5,6,11,0,14,9,2},
            {7,11,4,1,9,12,14,2,0,6,10,13,15,3,5,8},
            {2,1,14,7,4,10,8,13,15,12,9,0,3,5,6,11}
        };

        private static readonly int[] PC1 =
        {
            57,49,41,33,25,17,9,
            1,58,50,42,34,26,18,
            10,2,59,51,43,35,27,
            19,11,3,60,52,44,36,
            63,55,47,39,31,23,15,
            7,62,54,46,38,30,22,
            14,6,61,53,45,37,29,
            21,13,5,28,20,12,4
        };

        private static readonly int[] PC2 =
        {
            14,17,11,24,1,5,
            3,28,15,6,21,10,
            23,19,12,4,26,8,
            16,7,27,20,13,2,
            41,52,31,37,47,55,
            30,40,51,45,33,48,
            44,49,39,56,34,53,
            46,42,50,36,29,32
        };

        private static readonly int[] SHIFTS = { 1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1 };

        private static readonly int[][,] S_BOXES =
        {
            S1, S2, S3, S4, S5, S6, S7, S8
        };

        public static (byte[] Ciphertext, byte[] Iv) Encrypt(byte[] plaintext, byte[] key, string mode, byte[] iv = null)
        {
            if (key == null || key.Length != 8) throw new ArgumentException("Key must be 8 bytes for DES.");

            mode = mode.ToUpperInvariant();

            switch (mode)
            {
                case "ECB":
                    return (EncryptEcb(plaintext, key), null);

                case "CBC":
                    return EncryptCbc(plaintext, key, iv);

                default:
                    throw new ArgumentException("Unsupported mode. Use ECB or CBC.");
            }
        }

        public static byte[] Decrypt(byte[] ciphertext, byte[] key, string mode, byte[] iv)
        {
            if (key == null || key.Length != 8)
                throw new ArgumentException("Key must be 8 bytes for DES.");

            mode = mode.ToUpperInvariant();

            switch (mode)
            {
                case "ECB":
                    return DecryptEcb(ciphertext, key);

                case "CBC":
                    if (iv == null || iv.Length != 8)
                        throw new ArgumentException("IV must be 8 bytes for CBC mode.");
                    return DecryptCbc(ciphertext, key, iv);

                default:
                    throw new ArgumentException("Unsupported mode. Use ECB or CBC.");
            }
        }

        private static byte[] EncryptEcb(byte[] plaintext, byte[] key)
        {
            byte[] padded = Pkcs7Pad(plaintext); //block 8byte
            var keyBits = BytesToBits(key); //doi 8 byte sang 64 bit
            var subKeys = GenerateSubkeys(keyBits); //tao 16 subkey (48bit)

            byte[] output = new byte[padded.Length];

            //Xu ly moi block 8 byte
            for (int i = 0; i < padded.Length; i += 8)
            {
                byte[] block = new byte[8];
                Buffer.BlockCopy(padded, i, block, 0, 8);

                int[] bits = BytesToBits(block); //doi 8 byte sang 64 bit
                int[] encBits = DesBlockEncrypt(bits, subKeys); //ma hoa block 64 bit
                byte[] encBlock = BitsToBytes(encBits); //doi 64 bit sang 8 byte

                Buffer.BlockCopy(encBlock, 0, output, i, 8);
            }

            return output;
        }

        private static byte[] DecryptEcb(byte[] ciphertext, byte[] key)
        {
            if (ciphertext.Length % 8 != 0) //check cipher chia 8 byte
                throw new ArgumentException("Ciphertext length must be multiple of 8 bytes.");
            
            var keyBits = BytesToBits(key); 
            var subKeys = GenerateSubkeys(keyBits); //tao 16 subkey

            byte[] output = new byte[ciphertext.Length];

            for (int i = 0; i < ciphertext.Length; i += 8)
            {
                byte[] block = new byte[8]; //lay block 8 byte
                Buffer.BlockCopy(ciphertext, i, block, 0, 8);

                int[] bits = BytesToBits(block);
                int[] decBits = DesBlockDecrypt(bits, subKeys); //giai des 1 block
                byte[] decBlock = BitsToBytes(decBits);

                Buffer.BlockCopy(decBlock, 0, output, i, 8);
            }

            try
            {
                return Pkcs7Unpad(output); //bo pad tra plaintext goc 
            }
            catch
            {
                return output;
            }
        }


        private static (byte[] Ciphertext, byte[] Iv) EncryptCbc(byte[] plaintext, byte[] key, byte[] iv)
        {
            byte[] padded = Pkcs7Pad(plaintext); //nhu ECB

            if (iv == null) //neu null -> tao IV cho blox dau
            {
                iv = new byte[8];
                var rnd = new Random();
                rnd.NextBytes(iv); 
            }

            var keyBits = BytesToBits(key);
            var subKeys = GenerateSubkeys(keyBits); 

            byte[] output = new byte[padded.Length];
            byte[] prev = (byte[])iv.Clone();

            for (int i = 0; i < padded.Length; i += 8)
            {
                byte[] block = new byte[8];
                Buffer.BlockCopy(padded, i, block, 0, 8);

                // Moi block Xor voi block truoc do (hoac IV neu la block dau tien)
                for (int j = 0; j < 8; j++)
                    block[j] ^= prev[j];

                int[] bits = BytesToBits(block);
                int[] encBits = DesBlockEncrypt(bits, subKeys);
                byte[] encBlock = BitsToBytes(encBits);

                Buffer.BlockCopy(encBlock, 0, output, i, 8);
                prev = encBlock;
            }

            return (output, iv);
        }

        private static byte[] DecryptCbc(byte[] ciphertext, byte[] key, byte[] iv)
        {
            if (ciphertext.Length % 8 != 0) //check cipher chia 8 byte
                throw new ArgumentException("Ciphertext length must be multiple of 8 bytes.");

            var keyBits = BytesToBits(key);
            var subKeys = GenerateSubkeys(keyBits);

            byte[] output = new byte[ciphertext.Length];
            byte[] prev = (byte[])iv.Clone();

            for (int i = 0; i < ciphertext.Length; i += 8)
            {
                byte[] block = new byte[8];
                Buffer.BlockCopy(ciphertext, i, block, 0, 8);

                int[] bits = BytesToBits(block);
                int[] decBits = DesBlockDecrypt(bits, subKeys); //giai des ra plaintext da xor
                byte[] decBlock = BitsToBytes(decBits);

                for (int j = 0; j < 8; j++)
                    decBlock[j] ^= prev[j];

                Buffer.BlockCopy(decBlock, 0, output, i, 8);
                prev = block;
            }

            try
            {
                return Pkcs7Unpad(output);
            }
            catch
            {
                return output;
            }
        }

        // Ma hoa 1 block 64 bit, tra ve block 64 bit da ma hoa
        private static int[] DesBlockEncrypt(int[] block64, int[][] subKeys)
        {
            int[] permuted = Permute(block64, IP);
            int[] L = new int[32];
            int[] R = new int[32];
            Array.Copy(permuted, 0, L, 0, 32);
            Array.Copy(permuted, 32, R, 0, 32);

            for (int round = 0; round < 16; round++)
            {
                int[] newL = R;
                int[] fOut = F(R, subKeys[round]);
                int[] newR = Xor(L, fOut);
                L = newL;
                R = newR;
            }

            int[] combined = new int[64];
            Array.Copy(R, 0, combined, 0, 32);
            Array.Copy(L, 0, combined, 32, 32);

            return Permute(combined, FP);
        }

        // Giai ma 1 block 64 bit, tra ve block 64 bit da giai ma
        private static int[] DesBlockDecrypt(int[] block64, int[][] subKeys)
        {
            int[] permuted = Permute(block64, IP);
            int[] L = new int[32];
            int[] R = new int[32];
            Array.Copy(permuted, 0, L, 0, 32);
            Array.Copy(permuted, 32, R, 0, 32);

            for (int round = 15; round >= 0; round--)
            {
                int[] newL = R;
                int[] fOut = F(R, subKeys[round]);
                int[] newR = Xor(L, fOut);
                L = newL;
                R = newR;
            }

            int[] combined = new int[64];
            Array.Copy(R, 0, combined, 0, 32);
            Array.Copy(L, 0, combined, 32, 32);

            return Permute(combined, FP);
        }

        // Ham F trong DES
        private static int[] F(int[] R, int[] subKey)
        {
            int[] expanded = Permute(R, E);
            int[] xored = Xor(expanded, subKey);
            int[] sboxOutput = SBoxSubstitution(xored);
            int[] permuted = Permute(sboxOutput, P);
            return permuted;
        }

        // Ham thay the S-box
        private static int[] SBoxSubstitution(int[] input48)
        {
            int[] output = new int[32];

            for (int s = 0; s < 8; s++)
            {
                int offset = s * 6;
                int b0 = input48[offset];
                int b1 = input48[offset + 1];
                int b2 = input48[offset + 2];
                int b3 = input48[offset + 3];
                int b4 = input48[offset + 4];
                int b5 = input48[offset + 5];

                int row = (b0 << 1) | b5;
                int col = (b1 << 3) | (b2 << 2) | (b3 << 1) | b4;

                int val = S_BOXES[s][row, col];

                int outOffset = s * 4;
                output[outOffset] = (val >> 3) & 1;
                output[outOffset + 1] = (val >> 2) & 1;
                output[outOffset + 2] = (val >> 1) & 1;
                output[outOffset + 3] = val & 1;
            }

            return output;
        }

        // Tao 16 subkey 48 bit tu key 64 bit
        private static int[][] GenerateSubkeys(int[] key64) //bien key 64 bit thanh 16 subkey 48 bit
        {
            int[] key56 = Permute(key64, PC1); //chon 56 bit tu 64 bit

            //tach 56 bit thanh 2 phan C va D moi phan 28 bit
            int[] C = new int[28];
            int[] D = new int[28];
            Array.Copy(key56, 0, C, 0, 28);
            Array.Copy(key56, 28, D, 0, 28);

            int[][] subKeys = new int[16][];

            for (int round = 0; round < 16; round++)
            {
                //dich trai C va D theo so luong quy dinh
                C = LeftRotate(C, SHIFTS[round]);
                D = LeftRotate(D, SHIFTS[round]);

                //ket hop C va D lai thanh 56 bit
                int[] CD = new int[56];
                Array.Copy(C, 0, CD, 0, 28);
                Array.Copy(D, 0, CD, 28, 28);

                subKeys[round] = Permute(CD, PC2); //chuyen 56 bit thanh 48 bit
            }

            return subKeys;
        }

        private static int[] BytesToBits(byte[] data)
        {
            int[] bits = new int[data.Length * 8];
            for (int i = 0; i < data.Length; i++)
            {
                byte b = data[i];
                for (int j = 0; j < 8; j++)
                {
                    bits[i * 8 + j] = (b >> (7 - j)) & 1;
                }
            }
            return bits;
        }

        private static byte[] BitsToBytes(int[] bits)
        {
            int len = bits.Length / 8;
            byte[] data = new byte[len];

            for (int i = 0; i < len; i++)
            {
                byte b = 0;
                for (int j = 0; j < 8; j++)
                {
                    b = (byte)((b << 1) | (bits[i * 8 + j] & 1));
                }
                data[i] = b;
            }

            return data;
        }

        // Ham hoan vi
        private static int[] Permute(int[] input, int[] table)
        {
            int[] output = new int[table.Length];
            for (int i = 0; i < table.Length; i++)
            {
                output[i] = input[table[i] - 1];
            }
            return output;
        }

        // Ham XOR hai mang bit
        private static int[] Xor(int[] a, int[] b)
        {
            int[] r = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
                r[i] = a[i] ^ b[i];
            return r;
        }

        // Ham dich trai mang bit
        private static int[] LeftRotate(int[] bits, int shift)
        {
            int[] result = new int[bits.Length];
            int len = bits.Length;
            for (int i = 0; i < len; i++)
            {
                result[i] = bits[(i + shift) % len];
            }
            return result;
        }

        private static byte[] Pkcs7Pad(byte[] data)
        {
            int blockSize = 8;
            int padLen = blockSize - (data.Length % blockSize);
            if (padLen == 0) padLen = blockSize;

            byte[] result = new byte[data.Length + padLen];
            Buffer.BlockCopy(data, 0, result, 0, data.Length);
            for (int i = data.Length; i < result.Length; i++)
                result[i] = (byte)padLen;
            return result;
        }

        private static byte[] Pkcs7Unpad(byte[] data)
        {
            if (data.Length == 0)
                throw new ArgumentException("Invalid padded data.");

            int padLen = data[data.Length - 1];
            if (padLen <= 0 || padLen > 8 || padLen > data.Length)
                throw new ArgumentException("Invalid PKCS7 padding.");

            int newLen = data.Length - padLen;
            byte[] result = new byte[newLen];
            Buffer.BlockCopy(data, 0, result, 0, newLen);
            return result;
        }

        public static string ToHex(byte[] data)
        {
            var sb = new StringBuilder(data.Length * 2);
            foreach (byte b in data)
                sb.AppendFormat("{0:x2}", b);
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
