using System;
using System.Text;

namespace NT101_LAB6
{
    public static class VigenereCracker
    {
        private static readonly double[] EnglishFreq =
        {
            8.167, 1.492, 2.782, 4.253, 12.702, 2.228,
            2.015, 6.094, 6.966, 0.153, 0.772, 4.025,
            2.406, 6.749, 7.507, 1.929, 0.095, 5.987,
            6.327, 9.056, 2.758, 0.978, 2.360, 0.150,
            1.974, 0.074
        };

        private const int MaxKeyLength = 20; 

        public static (string key, string plaintext) Crack(string cipher)
        {
            string upper = ToLettersUpper(cipher, out int[] letterIndexMap);

            if (upper.Length == 0)
                return ("", cipher);

            int keyLen = EstimateKeyLength(upper);

            string key = FindKeyByFrequency(upper, keyLen);

            {
                int n = key.Length;
                for (int len = 1; len <= n; len++)
                {
                    if (n % len != 0) continue;

                    bool ok = true;
                    for (int i = 0; i < n; i++)
                    {
                        if (key[i] != key[i % len])
                        {
                            ok = false;
                            break;
                        }
                    }

                    if (ok)
                    {
                        key = key.Substring(0, len);
                        break;
                    }
                }
            }

            string plaintext = Decrypt(cipher, key);

            return (key, plaintext);
        }

        public static string Decrypt(string cipher, string key)
        {
            if (string.IsNullOrEmpty(key))
                return cipher;
            key = key.ToUpper();
            int keyLen = key.Length;
            int keyPos = 0;
            var sb = new StringBuilder(cipher.Length);
            foreach (char ch in cipher)
            {
                if (char.IsLetter(ch))
                {
                    bool isUpper = char.IsUpper(ch);
                    char baseChar = isUpper ? 'A' : 'a';
                    int cVal = ch - baseChar;
                    int kVal = key[keyPos % keyLen] - 'A';
                    int pVal = (cVal - kVal + 26) % 26;
                    char p = (char)(baseChar + pVal);
                    sb.Append(p);
                    keyPos++;
                }
                else
                {
                    sb.Append(ch);
                }
            }
            return sb.ToString();
        }

        private static string ToLettersUpper(string text, out int[] letterIndexMap)
        {
            var sb = new StringBuilder(text.Length);
            var idxList = new System.Collections.Generic.List<int>();

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (char.IsLetter(c))
                {
                    sb.Append(char.ToUpperInvariant(c));
                    idxList.Add(i);
                }
            }

            letterIndexMap = idxList.ToArray();
            return sb.ToString();
        }

        private static double ComputeIC(string s)
        {
            int[] freq = new int[26];
            int n = 0;
            foreach (char c in s)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    freq[c - 'A']++;
                    n++;
                }
            }
            if (n < 2) return 0.0;
            double sum = 0;
            for (int i = 0; i < 26; i++)
            {
                sum += freq[i] * (freq[i] - 1);
            }
            return sum / (double)(n * (n - 1));
        }

        private static int EstimateKeyLength(string upper)
        {
            int bestLen = 1;
            double bestDiff = double.MaxValue;
            double englishIC = 0.0667;
            for (int len = 1; len <= MaxKeyLength; len++)
            {
                double icSum = 0.0;
                int segments = 0;

                for (int offset = 0; offset < len; offset++)
                {
                    var sb = new StringBuilder();
                    for (int i = offset; i < upper.Length; i += len)
                    {
                        char c = upper[i];
                        if (c >= 'A' && c <= 'Z')
                            sb.Append(c);
                    }

                    if (sb.Length > 0)
                    {
                        double ic = ComputeIC(sb.ToString());
                        icSum += ic;
                        segments++;
                    }
                }
                if (segments == 0) continue;
                double avgIC = icSum / segments;
                double diff = Math.Abs(avgIC - englishIC);
                if (diff < bestDiff)
                {
                    bestDiff = diff;
                    bestLen = len;
                }
            }
            return bestLen;
        }

        private static string FindKeyByFrequency(string upper, int keyLen)
        {
            var key = new char[keyLen];
            for (int pos = 0; pos < keyLen; pos++)
            {
                var sb = new StringBuilder();
                for (int i = pos; i < upper.Length; i += keyLen)
                {
                    char c = upper[i];
                    if (c >= 'A' && c <= 'Z')
                        sb.Append(c);
                }
                key[pos] = FindBestShift(sb.ToString());
            }
            return new string(key);
        }

        private static char FindBestShift(string subset)
        {
            if (subset.Length == 0) return 'A';

            double bestChi = double.MaxValue;
            int bestShift = 0;

            for (int shift = 0; shift < 26; shift++)
            {
                int[] freq = new int[26];
                int n = 0;
                foreach (char c in subset)
                {
                    if (c < 'A' || c > 'Z') continue;
                    int cVal = c - 'A';
                    int pVal = (cVal - shift + 26) % 26;
                    freq[pVal]++;
                    n++;
                }
                if (n == 0) continue;
                double chi2 = 0.0;
                for (int i = 0; i < 26; i++)
                {
                    double expected = EnglishFreq[i] * n / 100.0;
                    double diff = freq[i] - expected;
                    chi2 += diff * diff / (expected + 1e-9);
                }
                if (chi2 < bestChi)
                {
                    bestChi = chi2;
                    bestShift = shift;
                }
            }
            return (char)('A' + bestShift);
        }

    }
}
