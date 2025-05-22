using System;
using System.IO;

namespace dataLoggingLibrary {
    public class logger {
        public static Action<string> UTLogCallback;
        public static readonly string logFilePath = "app.log", fildSaveLog = "error.log";

        public static void Log(string message, string level = "INFO") {
            string timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string userName = Environment.UserName;
            string formated = $"{timeStamp}\t[{level}]\t\t{userName}\t\t{message}";

            try {
                File.AppendAllText(logFilePath, formated + Environment.NewLine);
            } catch (Exception ex) {
                message = DateTime.Now.ToString() + "\t" + ex.Message + "\t" + ex.TargetSite + "\t" + ex.StackTrace;
                File.AppendAllText(fildSaveLog, message + Environment.NewLine);
            }
        }

        public static void Info(string message) => Log(message, "INFO");
        public static void Error(string message) => Log(message, "ERROR");
        public static void Warn(string message) => Log(message, "WARN");
    }
}
