using System;
using System.Text;

public class Soundex
{
    private static readonly string[] SoundexMapping = {
        // A, B, C, D, E, F, G, H, I, J, K, L, M
        "01230120022455012623010202", // N, O, P, Q, R, S, T, U, V, W, X, Y, Z
        "00000000000000000000000000"
    };

    public static string GenerateSoundex(string name)
    {
        if (string.IsNullOrEmpty(name))
            return string.Empty;

        StringBuilder soundex = new StringBuilder();
        soundex.Append(char.ToUpper(name[0]));
        char prevCode = GetSoundexCode(name[0]);

        for (int i = 1; i < name.Length && soundex.Length < 4; i++)
        {
            char code = GetSoundexCode(name[i]);
            if (code != '0' && code != prevCode)
            {
                soundex.Append(code);
                prevCode = code;
            }
        }

        while (soundex.Length < 4)
        {
            soundex.Append('0');
        }

        return soundex.ToString();
    }

    private static char GetSoundexCode(char c)
    {
        c = char.ToUpper(c);
        if (c < 'A' || c > 'Z')
            return '0';

        int index = c - 'A';
        return SoundexMapping[0][index];
    }
}
