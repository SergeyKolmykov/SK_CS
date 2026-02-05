using System.Runtime.InteropServices;

[DllImport("kernel32.dll")] static extern uint GetConsoleCP();
[DllImport("kernel32.dll")] static extern bool SetConsoleCP(uint pagenum);
[DllImport("kernel32.dll")] static extern uint GetConsoleOutputCP();
[DllImport("kernel32.dll")] static extern bool SetConsoleOutputCP(uint pagenum);


// Вызов функции из другого файла
string result = EnvironmentDetector.Detect().ToString();
//Console.WriteLine(result + " - Progam.cs");

if (result == "VisualStudio")
{
    //Console.WriteLine("Приложение запущено в Visual Studio");
    ENV_VS();
}
else if (result == "VSCode")
{
    //Console.WriteLine("Приложение запущено в VS Code");
    ENV_VScode();
}
else
{
    Console.WriteLine("Приложение запущено в неизвестной среде");
}

static void ENV_VScode()
    {
        Console.WriteLine("Приложение запущено в VS Code 99");
    }
static void ENV_VS()
    {
        SetConsoleCP(65001);        //установка кодовой страницы utf-8 (Unicode) для вводного потока
        SetConsoleOutputCP(65001);  //установка кодовой страницы utf-8 (Unicode)

        Console.WriteLine("Приложение запущено в VS 99");
    }