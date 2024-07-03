using Xunit;

public class SoundexTests
{
    [Fact]
    public void GenerateSoundex_ReturnsCorrectSoundex_ForValidInput()
    {
        // Arrange
        string name = "Washington";

        // Act
        string soundex = Soundex.GenerateSoundex(name);

        // Assert
        Assert.Equal("W252", soundex);
    }

    [Fact]
    public void GenerateSoundex_ReturnsEmptyString_ForNullOrEmptyInput()
    {
        // Arrange
        string emptyName = string.Empty;
        string nullName = null;

        // Act
        string emptySoundex = Soundex.GenerateSoundex(emptyName);
        string nullSoundex = Soundex.GenerateSoundex(nullName);

        // Assert
        Assert.Equal(string.Empty, emptySoundex);
        Assert.Equal(string.Empty, nullSoundex);
    }

    [Fact]
    public void GenerateSoundex_TruncatesLongNames()
    {
        // Arrange
        string longName = "Roosevelt";

        // Act
        string soundex = Soundex.GenerateSoundex(longName);

        // Assert
        Assert.Equal("R234", soundex);
    }

    [Fact]
    public void GenerateSoundex_HandlesCaseInsensitiveInput()
    {
        // Arrange
        string mixedCaseName = "wAsHinGTon";

        // Act
        string soundex = Soundex.GenerateSoundex(mixedCaseName);

        // Assert
        Assert.Equal("W252", soundex);
    }

    [Fact]
    public void GenerateSoundex_HandlesEdgeCases()
    {
        // Arrange
        string edgeCase1 = "W";
        string edgeCase2 = "Rrr";

        // Act
        string soundex1 = Soundex.GenerateSoundex(edgeCase1);
        string soundex2 = Soundex.GenerateSoundex(edgeCase2);

        // Assert
        Assert.Equal("W000", soundex1);
        Assert.Equal("R600", soundex2);
    }
}
