namespace LabelGenerator;

using System.Text;

enum ZplCodes {
  AddLabel,
  ChangePosition,

};

public class LabelBuilder
{
  private StringBuilder _zplResultCodeBuilder;
  private (int x, int y) _positionLimits = (3200, 3200);
  private Dictionary<ZplCodes, Func<string, string>> _operations = new Dictionary<ZplCodes, Func<string, string>>() {
    {ZplCodes.AddLabel, a => $"^FD{a}"},
    {ZplCodes.ChangePosition, a => $"^FO{a}"}
  };

  public string GetResultCode() {
    return _zplResultCodeBuilder.ToString() + "^XZ\n";
  }
  public LabelBuilder()
  {
    _zplResultCodeBuilder = new StringBuilder("^XA\n");
  }

  public void AddLabel(string labelText)
  {
    if(labelText.Length == 0)
    {
      throw new ArgumentNullException();
    }

    AddLine(ZplCodes.AddLabel, labelText);
  }

  public void ChangePosition((int x, int y) position)
  {

    AddLine(ZplCodes.ChangePosition, $"{position.x}, {position.y}");
  }

  private void AddLine(ZplCodes code, string argument)
  {
    _zplResultCodeBuilder.Append($"{_operations[code](argument)}\n");
  }
}
