using System;
using System.Text;

public class Soundex
{
  private static readonly string[] SoundexMapping = {
    "01230120022455012623010202", // A-M
    "00000000000000000000000000"  // N-Z
  };

  public static string GenerateSoundex(string name)
  {
    if (string.IsNullOrEmpty(name))
    {
      return string.Empty;
    }

    string firstChar = char.ToUpper(name[0]).ToString();
    string remainingChars = name.Substring(1);

    string encodedChars = EncodeChars(remainingChars);

    return firstChar + encodedChars.PadRight(4, '0');
  }

  private static string EncodeChars(string chars)
  {
    StringBuilder encoded = new StringBuilder();
    char prevCode = ' '; // Use a non-matching character for initial comparison

    int consonantCount = 0; // Track consonant count for truncation

    foreach (char c in chars)
    {
      char code = GetSoundexCode(c);
      if (code != '0' && code != prevCode)
      {
        encoded.Append(code);
        prevCode = code;
        consonantCount++; // Increment only for consonants (not '0')
      }

      if (consonantCount >= 3) // Stop encoding after 3 consonants
      {
        break;
      }
    }

    return encoded.ToString();
  }

  private static char GetSoundexCode(char c)
  {
    c = char.ToUpper(c);
    int index = c - 'A';
    if (index < 0 || index >= SoundexMapping.Length * SoundexMapping[0].Length)
    {
      return '0';
    }

    return SoundexMapping[index / 13][index % 13];
  }
}
