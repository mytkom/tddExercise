namespace LabelGenerator;

using System.Text;

public class LabelBuilder
{
  StringBuilder ZplResultCodeBuilder;

  public LabelBuilder()
  {
    ZplResultCodeBuilder = new StringBuilder("^XA\n");
  }

  public void AddLabel(string labelText)
  {
    ZplResultCodeBuilder.Append($"^FD{labelText}\n");
  }

  public string GetResultCode() {
    return ZplResultCodeBuilder.ToString() + "^XZ\n";
  }
}
