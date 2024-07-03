using Xunit;

public class SoundexTests
{
  [Fact]
  public void GenerateSoundex_EmptyString_ReturnsEmptyString()
  {
    string name = "";
    string expectedSoundex = "";

    string actualSoundex = Soundex.GenerateSoundex(name);

    Assert.Equal(expectedSoundex, actualSoundex);
  }

  [Fact]
  public void GenerateSoundex_NullInput_ReturnsEmptyString()
  {
    string name = null;
    string expectedSoundex = "";

    string actualSoundex = Soundex.GenerateSoundex(name);

    Assert.Equal(expectedSoundex, actualSoundex);
  }

  [Fact]
  public void GenerateSoundex_SingleLetter_ReturnsFirstLetter()
  {
    string name = "A";
    string expectedSoundex = "A000";

    string actualSoundex = Soundex.GenerateSoundex(name);

    Assert.Equal(expectedSoundex, actualSoundex);
  }

  [Fact]
  public void GenerateSoundex_Robert_ReturnsR163()
  {
    string name = "Robert";
    string expectedSoundex = "R163";

    string actualSoundex = Soundex.GenerateSoundex(name);

    Assert.Equal(expectedSoundex, actualSoundex);
  }

  [Fact]
  public void GenerateSoundex_Ashleigh_ReturnsA234()
  {
    string name = "Ashleigh";
    string expectedSoundex = "A234";

    string actualSoundex = Soundex.GenerateSoundex(name);

    Assert.Equal(expectedSoundex, actualSoundex);
  }

  [Fact]
  public void GenerateSoundex_LongName_TruncatesToFirstFourLetters()
  {
    string name = "ThisIsALongName";
    string expectedSoundex = "T223";

    string actualSoundex = Soundex.GenerateSoundex(name);

    Assert.Equal(expectedSoundex, actualSoundex);
  }

  [Fact]
  public void GenerateSoundex_HandlesVowelsAndH_ReturnsEmptyEncoding()
  {
    string name = "Hello";
    string expectedSoundex = "H000";

    string actualSoundex = Soundex.GenerateSoundex(name);

    Assert.Equal(expectedSoundex, actualSoundex);
  }
}
