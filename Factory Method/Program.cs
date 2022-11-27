namespace DesignPat;
using static System.Console;

public interface IButton
{
    public void Render();
    public void OnClick();
}

public class HtmlButton : IButton
{
    public void OnClick() => WriteLine("HTML button clicked");
    public void Render() => WriteLine("HTML render rendered");
}

public class WindowsButton : IButton
{
    public void OnClick() => WriteLine("Windows button clicked");
    public void Render() => WriteLine("Windows button rendered");
}



public abstract class Dialog
{
    public abstract IButton CreateButton();
    public void Render()
    {
        IButton okButton = CreateButton();
        okButton.OnClick();
        okButton.Render();
    }

}
public class HtmlDialog : Dialog
{
    public override IButton CreateButton() => new HtmlButton();
}

public class WindowsDialog : Dialog
{
    public override IButton CreateButton() => new WindowsButton();
}


class Program
{
    static void Main()
    {
        Dialog? dialog = null;
        IButton? button = null;
        while (true)
        {
            WriteLine(@"
                            1: Windows
                            2: Html
                            Any: Exit");

            Write("\n\tEnter choice: ");

            dialog = ReadLine() switch
            {
                "1" => new WindowsDialog(),
                "2" => new HtmlDialog(),
                _ => null
            };

            if (dialog == null)
                break;
            button = dialog.CreateButton();
            dialog.Render();
        }


    }
}