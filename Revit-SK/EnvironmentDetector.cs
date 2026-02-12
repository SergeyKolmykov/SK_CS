// Код проверки в какой среде запущено консольное приложение
public enum DevelopmentEnvironment
{
    Unknown,
    VisualStudio,
    VSCode,
    WindowsTerminal,
    CommandPrompt,
    PowerShell,
    Bash,
    ConEmu,
    Alacritty,
    JetBrainsIDE
}

public static class EnvironmentDetector
{
    public static DevelopmentEnvironment Detect()
    {
        // 1. Проверка Visual Studio
        if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("VSAPPIDNAME")) ||
            !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("VisualStudioVersion")) ||
            !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("VSINSTALLDIR")))
        {
            //Console.WriteLine("Visual Studio ENV");
            return DevelopmentEnvironment.VisualStudio;
            
            
        }
                // 2. Проверка VS Code

         string? textParametr = Environment.GetEnvironmentVariable("TERM_PROGRAM");
        if ( textParametr != null)
        {
                if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("VSCODE_PID")) ||
                (!string.IsNullOrEmpty(textParametr)) &&
                textParametr.Contains("vscode", StringComparison.OrdinalIgnoreCase))
            {
                //Console.WriteLine("VS Code ENV");
                
                return  DevelopmentEnvironment.VSCode;
            }
        }        
        
        
        // 3. Проверка Windows Terminal
        if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("WT_SESSION")) ||
            !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("WT_PROFILE_ID")))
        {
            return DevelopmentEnvironment.WindowsTerminal;
        }
        
        // 4. Проверка ConEmu
        if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("ConEmuPID")))
        {
            return DevelopmentEnvironment.ConEmu;
        }
        
        // 5. Проверка Alacritty
        if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("ALACRITTY_LOG")))
        {
            return DevelopmentEnvironment.Alacritty;
        }
        
        // 6. Проверка JetBrains IDE (Rider, IntelliJ)
        if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("JB_HOST")) ||
            !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("IDEA_INITIAL_DIRECTORY")))
        {
            return DevelopmentEnvironment.JetBrainsIDE;
        }
        
        // 7. Определение типа оболочки
        string? term = Environment.GetEnvironmentVariable("TERM");
        string? shell = Environment.GetEnvironmentVariable("SHELL");
        string? comSpec = Environment.GetEnvironmentVariable("ComSpec");
        
        if (!string.IsNullOrEmpty(term) && term.Contains("powershell", StringComparison.OrdinalIgnoreCase))
        {
            return DevelopmentEnvironment.PowerShell;
            //return "powershell";
        }
        else if (!string.IsNullOrEmpty(shell) && shell.Contains("bash"))
        {
            return DevelopmentEnvironment.Bash;
            //return "bash";
        }
        else if (!string.IsNullOrEmpty(comSpec) && comSpec.EndsWith("cmd.exe", StringComparison.OrdinalIgnoreCase))
        {
            return DevelopmentEnvironment.CommandPrompt;
            //return "cmd";
        }
        
        return DevelopmentEnvironment.Unknown;
        //return "unknown";   
    }
    
    public static bool IsRunningInIDE()
    {
        var env = Detect();
        return env == DevelopmentEnvironment.VisualStudio || 
               env == DevelopmentEnvironment.VSCode ||
               env == DevelopmentEnvironment.JetBrainsIDE;
    }
    
    public static bool IsRunningInDebugger()
    {
        return System.Diagnostics.Debugger.IsAttached;
    }
}