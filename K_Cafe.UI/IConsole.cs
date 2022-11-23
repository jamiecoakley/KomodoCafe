
public interface IConsole
{
    string ReadLine();
    ConsoleKeyInfo ReadKey();
    void Clear();
    void Write(string s);
    void WriteLine(string s);
    void ChangeBackgroundColor (ConsoleColor color);
    void ResetColor();
}
