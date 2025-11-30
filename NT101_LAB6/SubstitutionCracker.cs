using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace NT101_LAB6
{
    public class SubstitutionResult
    {
        public double Score { get; set; }
        public Dictionary<char, char> Mapping { get; set; } = new Dictionary<char, char>();
        public string Plaintext { get; set; } = "";
    }

    public static class SubstitutionCracker
    {
        private static readonly double[] EnglishFreq =
        {
            8.167, // a
            1.492, // b
            2.782, // c
            4.253, // d
            12.702,// e
            2.228, // f
            2.015, // g
            6.094, // h
            6.966, // i
            0.153, // j
            0.772, // k
            4.025, // l
            2.406, // m
            6.749, // n
            7.507, // o
            1.929, // p
            0.095, // q
            5.987, // r
            6.327, // s
            9.056, // t
            2.758, // u
            0.978, // v
            2.360, // w
            0.150, // x
            1.974, // y
            0.074  // z
        };

        private static readonly HashSet<string> Dict = new HashSet<string>
        (
            new[]
            {
                "the","and","that","with","this","from","have","not",
                "for","you","are","but","his","her","was","were",
                "their","about","which","into","said","had","there","been",
                "will","would","when","they","them","oil","ship","ships",
                "sea","black","fleet","russia","russian","ukraine","ukrainian",
                "tankers","tanker","crew","fire","attack","attacks","again",
                "ministry","turkish","foreign","coast","damage","sanctioned"
            },
            StringComparer.Ordinal
        );

        private static void CountFrequencies(string text, int[] freq, out int total)
        {
            Array.Clear(freq, 0, freq.Length);
            total = 0;
            foreach (char ch in text)
            {
                if (ch >= 'a' && ch <= 'z')
                {
                    freq[ch - 'a']++;
                    total++;
                }
            }
        }

        private static double ChiSquareScore(string plainLower)
        {
            int[] freq = new int[26];
            CountFrequencies(plainLower, freq, out int total);
            if (total == 0) return double.NegativeInfinity;

            double chi2 = 0.0;
            for (int i = 0; i < 26; i++)
            {
                double expected = EnglishFreq[i] * total / 100.0;
                double diff = freq[i] - expected;
                chi2 += diff * diff / (expected + 1e-9);
            }

            return -chi2;
        }

        private static double ScorePlaintext(string plainLower)
        {
            double chi = ChiSquareScore(plainLower);

            double dictScore = 0.0;

            var tokens = Regex.Split(plainLower, "[^a-z]+");
            foreach (var w in tokens)
            {
                if (w.Length < 2) continue;

                if (Dict.Contains(w))
                {
                    dictScore += 25.0; 
                }
            }

            return chi + dictScore;
        }

        private static Dictionary<char, char> BuildInitialMapping(string cipherLower)
        {
            int[] freq = new int[26];
            CountFrequencies(cipherLower, freq, out _);
            var cipherOrder = Enumerable.Range(0, 26).OrderByDescending(i => freq[i]).Select(i => (char)('a' + i)).ToList();
            const string englishOrder = "etaoinshrdlcumwfgypbvkjxqz";
            var map = new Dictionary<char, char>();
            for (int i = 0; i < 26; i++)
            {
                char c = cipherOrder[i];
                char p = englishOrder[i];
                map[c] = p;
            }
            foreach (char c in "abcdefghijklmnopqrstuvwxyz")
            {
                if (!map.ContainsKey(c))
                {
                    foreach (char p in "abcdefghijklmnopqrstuvwxyz")
                    {
                        if (!map.Values.Contains(p))
                        {
                            map[c] = p;
                            break;
                        }
                    }
                }
            }
            return map;
        }

        private static string ApplyMapping(string cipher, Dictionary<char, char> map, out string lowerPlain)
        {
            var sb = new StringBuilder(cipher.Length);
            var sbLower = new StringBuilder(cipher.Length);
            foreach (char ch in cipher)
            {
                if (ch >= 'a' && ch <= 'z')
                {
                    char p = map[ch];
                    sb.Append(p);
                    sbLower.Append(p);
                }
                else if (ch >= 'A' && ch <= 'Z')
                {
                    char lower = char.ToLower(ch);
                    char p = map.ContainsKey(lower) ? map[lower] : lower;
                    sb.Append(char.ToUpper(p));
                    sbLower.Append(p);
                }
                else
                {
                    sb.Append(ch);
                    sbLower.Append(ch);
                }
            }

            lowerPlain = sbLower.ToString().ToLower();
            return sb.ToString();
        }

        private static Dictionary<char, char> CloneMap(Dictionary<char, char> src)
        {
            return src.ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        private static void RandomSwap(Dictionary<char, char> map, Random rnd)
        {
            int i = rnd.Next(26);
            int j = rnd.Next(26);
            if (i == j) return;

            char p1 = (char)('a' + i);
            char p2 = (char)('a' + j);

            char c1 = '\0', c2 = '\0';
            foreach (var kv in map)
            {
                if (kv.Value == p1) c1 = kv.Key;
                else if (kv.Value == p2) c2 = kv.Key;
            }
            if (c1 == '\0' || c2 == '\0') return;

            char tmp = map[c1];
            map[c1] = map[c2];
            map[c2] = tmp;
        }

        private static SubstitutionResult HillClimb(string cipher, Dictionary<char, char> startMap, int iterations, Random rnd)
        {
            var currentMap = CloneMap(startMap);
            string curLower;
            string currentPlain = ApplyMapping(cipher, currentMap, out curLower);
            double currentScore = ScorePlaintext(curLower);

            var best = new SubstitutionResult
            {
                Mapping = CloneMap(currentMap),
                Plaintext = currentPlain,
                Score = currentScore
            };

            double temperature = 10.0;
            double cooling = Math.Pow(0.001, 1.0 / Math.Max(1, iterations));

            for (int it = 0; it < iterations; it++)
            {
                var newMap = CloneMap(currentMap);
                RandomSwap(newMap, rnd);
                string newLower;
                string newPlain = ApplyMapping(cipher, newMap, out newLower);
                double newScore = ScorePlaintext(newLower);
                double delta = newScore - currentScore;
                if (delta > 0 || rnd.NextDouble() < Math.Exp(delta / temperature))
                {
                    currentMap = newMap;
                    currentPlain = newPlain;
                    currentScore = newScore;

                    if (currentScore > best.Score)
                    {
                        best.Mapping = CloneMap(currentMap);
                        best.Plaintext = currentPlain;
                        best.Score = currentScore;
                    }
                }
                temperature *= cooling;
            }
            return best;
        }

        public static SubstitutionResult Crack(string cipher, int iterationsPerRestart = 50000, int restarts = 5)
        {
            string cipherLower = cipher.ToLower();
            SubstitutionResult best = null;
            var rnd = new Random();

            for (int r = 0; r < restarts; r++)
            {
                var seed = BuildInitialMapping(cipherLower);

                for (int i = 0; i < 50; i++)
                    RandomSwap(seed, rnd);

                var result = HillClimb(cipher, seed, iterationsPerRestart, rnd);

                if (best == null || result.Score > best.Score)
                    best = result;
            }

            return best;
        }

        public static string MappingToString(Dictionary<char, char> map)
        {
            var cipherLine = new StringBuilder();
            var plainLine = new StringBuilder();

            cipherLine.Append("cipher: ");
            plainLine.Append("plain : ");

            foreach (char c in "abcdefghijklmnopqrstuvwxyz")
            {
                cipherLine.Append(c);
                plainLine.Append(map[c]);
            }

            return cipherLine.ToString() + Environment.NewLine + plainLine.ToString();
        }
    }
}
