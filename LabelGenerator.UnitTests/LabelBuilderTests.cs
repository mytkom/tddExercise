namespace LabelGenerator.UnitTests;

public class LabelBuilderTests
{
    [Theory]
    [InlineData("LabelText", $"^XA\n^FDLabelText\n^XZ\n")]
    [InlineData("LabelText Second", $"^XA\n^FDLabelText Second\n^XZ\n")]
    public void GeneratesCorrectZplWithProvidedLabel(string labelText, string expectedCode)
    {
      // Arrange
      LabelBuilder builder = new LabelBuilder(); 
      
      // Act
      builder.AddLabel(labelText);      
      string result = builder.GetResultCode();

      // Assert
      Assert.Equal(expectedCode, result);
    }

    [Fact]
    public void RaisesExceptionWhenLabelTextIsEmpty()
    {
      // Arrange
      LabelBuilder builder = new LabelBuilder(); 
      
      // Assert
      Assert.Throws<ArgumentNullException>(() => builder.AddLabel(""));
    }

    [Theory]
    [InlineData(10, 10, "^XA\n^FO10, 10\n^XZ\n")]
    [InlineData(200, 600, "^XA\n^FO200, 600\n^XZ\n")]
    public void GeneratesCorrectZplWithPositionChange(int x, int y, string expectedCode)
    {
      // Arrange
      LabelBuilder builder = new LabelBuilder(); 
      
      // Act
      builder.ChangePosition((x, y));      
      string result = builder.GetResultCode();

      // Assert
      Assert.Equal(expectedCode, result);
    }
}
