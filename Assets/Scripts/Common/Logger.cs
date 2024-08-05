using System.Diagnostics;

/// <summary>
/// 추가적인 정보 표현, 출시용 빌드를 위한 로그 제거
/// </summary>
public static class Logger
{
    [Conditional("DEV_VER")]
    public static void Log(string msg)
    {
        UnityEngine.Debug.LogFormat($"[{System.DateTime.Now:yyyy-mm-dd HH:mm:ss.fff}] {msg}");
    }
    [Conditional("DEV_VER")]
    public static void LogWarning(string msg)
    {
        UnityEngine.Debug.LogWarningFormat($"[{System.DateTime.Now:yyyy-mm-dd HH:mm:ss.fff}] {msg}");
    }
    public static void LogError(string msg)
    {
        UnityEngine.Debug.LogErrorFormat($"[{System.DateTime.Now:yyyy-mm-dd HH:mm:ss.fff}] {msg}");
    }
}
