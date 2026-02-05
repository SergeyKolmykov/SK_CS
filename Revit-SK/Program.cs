// See https://aka.ms/new-console-template for more information


using System.Runtime.InteropServices;

[DllImport("kernel32.dll")] static extern uint GetConsoleCP();
[DllImport("kernel32.dll")] static extern bool SetConsoleCP(uint pagenum);
[DllImport("kernel32.dll")] static extern uint GetConsoleOutputCP();
[DllImport("kernel32.dll")] static extern bool SetConsoleOutputCP(uint pagenum);

SetConsoleCP(65001);        //установка кодовой страницы utf-8 (Unicode) для вводного потока
SetConsoleOutputCP(65001);  //установка кодовой страницы utf-8 (Unicode) 


Console.WriteLine("Привет Сергей Колмыков! GitHub репозитрий работает?\n Совместная работа VScode и VS 2026 02 05\n  обновление из VS");

