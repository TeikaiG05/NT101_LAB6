using System;
using System.IO;
using System.Text;

public static class CaesarCracker
{

    private static readonly string[] commonWords = {" the ", " and ", " of ", " to ", " in ", " that ", " is ", " it ", " for ", " on "};

    private static char ShiftChar(char c, int shift)
    {
        if (c >= 'a' && c <= 'z')
        {
            int baseChar = 'a';
            int pos = c - baseChar;
            int newPos = (pos - shift + 26) % 26;
            return (char)(baseChar + newPos);
        }
        if (c >= 'A' && c <= 'Z')
        {
            int baseChar = 'A';
            int pos = c - baseChar;
            int newPos = (pos - shift + 26) % 26;
            return (char)(baseChar + newPos);
        }
        return c;
    }

    private static string DecodeCaesar(string cipher, int k)
    {
        var sb = new StringBuilder(cipher.Length);
        foreach (char c in cipher)
            sb.Append(ShiftChar(c, k));
        return sb.ToString();
    }

    private static double ScoreEnglish(string text)
    {
        string lower = text.ToLower();
        double score = 0;

        foreach (var w in commonWords)
        {
            int idx = 0;
            while (true)
            {
                idx = lower.IndexOf(w, idx, StringComparison.Ordinal);
                if (idx == -1) break;
                score += 1.0;
                idx += w.Length;
            }
        }

        int spaceCount = 0;
        foreach (char c in lower)
            if (c == ' ') spaceCount++;

        score += spaceCount * 0.01;

        return score;
    }

    public static (int bestKey, string bestPlain) Crack(string cipher)
    {
        int bestKey = 0;
        double bestScore = double.NegativeInfinity;
        string bestPlain = cipher;

        for (int k = 0; k < 26; k++)
        {
            string plain = DecodeCaesar(cipher, k);
            double score = ScoreEnglish(plain);

            if (score > bestScore)
            {
                bestScore = score;
                bestPlain = plain;
                bestKey = k;
            }
        }

        return (bestKey, bestPlain);
    }
}
