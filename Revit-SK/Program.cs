using System;
using System.Runtime.InteropServices;

class Program
    {   
        // Пока каким-то необъяснимым способом получилось убрать предупреждения в VScode "The local function 'GetConsoleCP' is declared but never use" 
        // и "The local function 'GetConsoleOutputCP' is declared but never used" то есть, что функции задекларированы но в VScode не используются.  
        // Это сделано добавлением флагов условной компиляции #if !VSCODE_ENV
        // Логика написания была следующей:
        // 1. Флаг VSCODE_ENV декларировался в json-запросе "c_cpp_properties.json". Запрос должен был выполняться перед командой "dotnet run" в VScode
        // и не выполнятся при запуске в Visual Studio. То есть при запуске в VScode флаг VSCODE_ENV объвлялся, а при запуске в Visual Studio его бы не было.
        // 2. Дальше все понятно по коду "#if !VSCODE_ENV" - значит, что если флаг VSCODE_ENV не заявлен, то выполняй компиляцию от флага до #endif
        // В основном информация получена из запросов в Deep Seek

        #if !VSCODE_ENV

        [DllImport("kernel32.dll")] static extern uint GetConsoleCP();
        [DllImport("kernel32.dll")] static extern bool SetConsoleCP(uint pagenum);
        [DllImport("kernel32.dll")] static extern uint GetConsoleOutputCP();
        [DllImport("kernel32.dll")] static extern bool SetConsoleOutputCP(uint pagenum);

        #endif

        static void Main(string[] args)
        {
            string result = EnvironmentDetector.Detect().ToString();
            //Console.WriteLine("Начало тестирования. " + result + " - Progam.cs");

            if (result == "VisualStudio")
            {
                //Console.WriteLine("Приложение запущено в VisualStudio. " + result + " - Progam.cs");
                ENV_VS();
            }
                        
                else if (result == "VSCode")
            {
                //Console.WriteLine("Приложение запущено в VScode. " + result + " - Progam.cs");
                ENV_VScode();
            }

                else if (result == "WindowsTerminal")
            {
                Console.WriteLine("Приложение запущено в WindowsTerminal. " + result + " - Progam.cs");
            }

                else if (result == "CommandPrompt")
            {
                Console.WriteLine("Приложение запущено в CommandPrompt. " + result + " - Progam.cs");
            }

                else if (result == "PowerShell")
            {
                Console.WriteLine("Приложение запущено в PowerShell. " + result + " - Progam.cs");
            }
            
                else if (result == "Bash")
            {
                Console.WriteLine("Приложение запущено в Bash. " + result + " - Progam.cs");
            }
                    
                else if (result == "ConEmu")
            {
                Console.WriteLine("Приложение запущено в ConEmu. " + result + " - Progam.cs");
            }
                
                else if (result == "Alacritty")
            {
                Console.WriteLine("Приложение запущено в Alacritty. " + result + " - Progam.cs");
            }
                        
                else if (result == "JetBrainsIDE")
            {
                Console.WriteLine("Приложение запущено в JetBrainsIDE. " + result + " - Progam.cs");
            }
                else 
            {
                Console.WriteLine("Приложение запущено в неизвестной среде.");
            }
            
        }

        static void ENV_VScode()
        {
            Console.WriteLine("Приложение запущено в VS Code");
        }
        static void ENV_VS()
        {
            #if !VSCODE_ENV
                SetConsoleCP(65001);        //установка кодовой страницы utf-8 (Unicode) для вводного потока
                SetConsoleOutputCP(65001);  //установка кодовой страницы utf-8 (Unicode)
            #endif 

            //RusKodirovkaForVS.RusTest();

            Console.WriteLine("Приложение запущено в VS");
    }
    }
