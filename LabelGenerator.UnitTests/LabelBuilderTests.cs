namespace LabelGenerator.UnitTests;

public class LabelBuilderTests
{
    [Theory]
    [InlineData("")]
    [InlineData("LabelText")]
    [InlineData("LabelText Second")]
    public void GenerateZplWithProvidedLabel(string labelText)
    {
      // Arrange
      LabelBuilder builder = new LabelBuilder(); 
      string expectedResult = $"^XA\n^FD{labelText}\n^XZ\n";
      
      // Act
      builder.AddLabel(labelText);      
      string result = builder.GetResultCode();

      // Assert
      Assert.Equal(expectedResult, result);
    }
}
