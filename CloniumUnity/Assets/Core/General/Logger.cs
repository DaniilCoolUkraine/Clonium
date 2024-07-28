using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Clonium.Core.General
{
    public class Logger
    {
        private const string COLOR = "#B3B3B3";
        
        [Conditional("UNITY_EDITOR"), Conditional("UNITY_STANDALONE"), Conditional("DEVELOPMENT_BUILD")]
        public static void Log(string site, string message, params object[] args)
        {
            ColorUtility.TryParseHtmlString(COLOR, out var color);
            string formattedMessage = FormatMessage(site, message, color, args);
            Debug.Log(formattedMessage);
        }
        
        [Conditional("UNITY_EDITOR"), Conditional("UNITY_STANDALONE"), Conditional("DEVELOPMENT_BUILD")]
        public static void LogWarning(string site, string message, params object[] args)
        {
            ColorUtility.TryParseHtmlString(COLOR, out var color);
            string formattedMessage = FormatMessage(site, message, color, args);
            Debug.LogWarningFormat(formattedMessage);
        }
        
        [Conditional("UNITY_EDITOR"), Conditional("UNITY_STANDALONE"), Conditional("DEVELOPMENT_BUILD")]
        public static void LogError(string site, string message, params object[] args)
        {
            ColorUtility.TryParseHtmlString(COLOR, out var color);
            string formattedMessage = FormatMessage(site, message, color, args);
            Debug.LogErrorFormat(formattedMessage);
        }
        
        [Conditional("UNITY_EDITOR"), Conditional("UNITY_STANDALONE"), Conditional("DEVELOPMENT_BUILD")]
        public static void Log(string site, string message, Color color, params object[] args)
        {
            string formattedMessage = FormatMessage(site, message, color, args);
            Debug.Log(formattedMessage);
        }
        
        [Conditional("UNITY_EDITOR"), Conditional("UNITY_STANDALONE"), Conditional("DEVELOPMENT_BUILD")]
        public static void LogWarning(string site, string message, Color color, params object[] args)
        {
            string formattedMessage = FormatMessage(site, message, color, args);
            Debug.LogWarning(formattedMessage);
        }

        [Conditional("UNITY_EDITOR"), Conditional("UNITY_STANDALONE"), Conditional("DEVELOPMENT_BUILD")]
        public static void LogError(string site, string message, Color color, params object[] args)
        {
            string formattedMessage = FormatMessage(site, message, color, args);
            Debug.LogError(formattedMessage);
        }
        
        private static string FormatMessage(string site, string message, Color color, params object[] args)
        {
            var now = System.DateTime.Now;
            string timestamp = string.Format("[{0}/{1}/{2} {3}:{4:00}:{5:00}.{6:000}]", now.Day, now.Month,
                (now.Year - 2000), now.Hour, now.Minute, now.Second, now.Millisecond);

            if (string.IsNullOrEmpty(site))
                site = "(unknown)";

            return
                $"[{site} - {timestamp} ({Time.frameCount})] - <color=#{ColorUtility.ToHtmlStringRGB(color)}>{string.Format(message, args)}</color>";
        }
    }
}