using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WpfApp1
{
    class Logger : ILog
    {
        private List<Exception> ErrorList = new List<Exception>();
        private List<string> WarningList = new List<string>();
        public void Debug(string message)
        {
            string methNAme = "Debug";
            Logging(message, methNAme);
        }
        public void Debug(string message, Exception e)
        {
            string methName = "Debug";
            Logging(message, e, methName);

        }
        public void DebugFormat(string message, params object[] args)
        {
            string methName = "DebugFormat";
            Logging(message, methName, args);
        }
        public void Error(Exception ex)
        {
            string methName = "Error";
            Logging(ex, methName);
            if (!ErrorList.Contains(ex))
            {
                ErrorList.Add(ex);
            }

        }
        public void Error(string message)
        {
            string methName = "Error";
            Logging(message, methName);
        }
        public void Error(string message, Exception e)
        {
            string methName = "Error";
            Logging(message, e, methName);
            if (!ErrorList.Contains(e))
            {
                ErrorList.Add(e);
            }

        }
        public void ErrorUnique(string message, Exception e)
        {
            string methName = "ERROR UNIQUE";
            if (!ErrorList.Contains(e))
            {
                Logging(message, e, methName);
            }
        }
        public void Fatal(string message)
        {
            string methName = "Fatal";
            Logging(message, methName);
        }
        public void Fatal(string message, Exception e)
        {
            string methName = "Fatal";
            Logging(message, e, methName);
            if (!ErrorList.Contains(e))
            {
                ErrorList.Add(e);
            }
        }
        public void Info(string message)
        {
            DateTime dt = DateTime.Now;
            string date = dt.ToString("yyyy-MM-dd");
            string time = dt.ToLongTimeString();
            string directory = @"C:\Users\Impervm\Desktop\Logs";
            string subDirPath = @"C:\Users\Impervm\Desktop\Logs\" + date;
            string subDirName = date;
            string logPath = $@"C:\Users\Impervm\Desktop\Logs\{date}\Info.log";
            DirectoryInfo directoryInfo = new DirectoryInfo(directory);
            DirectoryInfo subDir = new DirectoryInfo(subDirPath);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
                directoryInfo.CreateSubdirectory(subDirName);
            }
            else if (!subDir.Exists)
            {
                subDir.Create();
            }
            using (StreamWriter streamWriter = new StreamWriter(logPath, true, System.Text.Encoding.Default))
            {
                streamWriter.Write(date + "  :  " + time + "  ----  " + message + "\n");
            }

        }
        public void Info(string message, Exception e)
        {
            DateTime dt = DateTime.Now;
            string date = dt.ToString("yyyy-MM-dd");
            string time = dt.ToLongTimeString();
            string directory = @"C:\Users\Impervm\Desktop\Logs";
            string subDirPath = @"C:\Users\Impervm\Desktop\Logs\" + date;
            string subDirName = date;
            string logPath = $@"C:\Users\Impervm\Desktop\Logs\{date}\Info.log";
            DirectoryInfo directoryInfo = new DirectoryInfo(directory);
            DirectoryInfo subDir = new DirectoryInfo(subDirPath);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
                directoryInfo.CreateSubdirectory(subDirName);
            }
            else if (!subDir.Exists)
            {
                subDir.Create();
            }
            using (StreamWriter streamWriter = new StreamWriter(logPath, true, System.Text.Encoding.Default))
            {
                streamWriter.Write(date + "  :  " + time + "  ----  " + message + " --- " + $"EXCEPTION -- {e}\n");
            }

        }
        public void Info(string message, params object[] args)
        {
            DateTime dt = DateTime.Now;
            string date = dt.ToString("yyyy-MM-dd");
            string time = dt.ToLongTimeString();
            string directory = @"C:\Users\Impervm\Desktop\Logs";
            string subDirPath = @"C:\Users\Impervm\Desktop\Logs\" + date;
            string subDirName = date;
            string logPath = $@"C:\Users\Impervm\Desktop\Logs\{date}\Info.log";
            DirectoryInfo directoryInfo = new DirectoryInfo(directory);
            DirectoryInfo subDir = new DirectoryInfo(subDirPath);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
                directoryInfo.CreateSubdirectory(subDirName);
            }
            else if (!subDir.Exists)
            {
                subDir.Create();
            }
            using (StreamWriter streamWriter = new StreamWriter(logPath, true, System.Text.Encoding.Default))
            {
                streamWriter.Write(date + "  :  " + time + "  ----  " + message + " --- "+ $"ARGS{args}\n");
            }
        }
        public void SystemInfo(string message, Dictionary<object, object> properties)
        {
            string methName = "SystemInfo";
            InfoLogging(message, properties, methName);
        }
        public void Warning(string message)
        {
            string methName = "Warning";
            if (!WarningList.Contains(message))
            {
                WarningList.Add(message);
            }
            Logging(message, methName);
        }
        public void Warning(string message, Exception e)
        {
            string methName = "Warning";
            Logging(message, e, methName);
            if (!WarningList.Contains(message))
            {
                WarningList.Add(message);
            }
        }
        public void WarningUnique(string message)
        {
            string methName = "WARNING UNIQUE";
            if (!WarningList.Contains(message))
            {
                Logging(message, methName);
            }
        }
        private void Logging(string message, string methodName)
        {
            DateTime dt = DateTime.Now;
            string date = dt.ToString("yyyy-MM-dd");
            string time = dt.ToLongTimeString();
            string directory = @"C:\Users\Impervm\Desktop\Logs";
            string subDirPath = @"C:\Users\Impervm\Desktop\Logs\" + date;
            string subDirName = date;
            string logPath = $@"C:\Users\Impervm\Desktop\Logs\{date}\error.log";
            DirectoryInfo directoryInfo = new DirectoryInfo(directory);
            DirectoryInfo subDir = new DirectoryInfo(subDirPath);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
                directoryInfo.CreateSubdirectory(subDirName);
            }
            else if (!subDir.Exists)
            {
                subDir.Create();
            }
            using (StreamWriter streamWriter = new StreamWriter(logPath, true, System.Text.Encoding.Default))
            {
                streamWriter.Write(date + "  :  " + time + "  ----  (" + methodName + ") --- " + message + "\n");
            }
        }
        private void Logging(string message, Exception exception, string methodName)
        {
            DateTime dt = DateTime.Now;
            string date = dt.ToString("yyyy-MM-dd");
            string time = dt.ToLongTimeString();
            string directory = @"C:\Users\Impervm\Desktop\Logs";
            string subDirPath = @"C:\Users\Impervm\Desktop\Logs\" + date;
            string subDirName = date;
            string logPath = $@"C:\Users\Impervm\Desktop\Logs\{date}\error.log";
            DirectoryInfo directoryInfo = new DirectoryInfo(directory);
            DirectoryInfo subDir = new DirectoryInfo(subDirPath);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
                directoryInfo.CreateSubdirectory(subDirName);
            }
            else if (!subDir.Exists)
            {
                subDir.Create();
            }
            using (StreamWriter streamWriter = new StreamWriter(logPath, true, System.Text.Encoding.Default))
            {
                streamWriter.Write(date + "  :  " + time + "  ----  (" + methodName + ") --- " + message + $"EXCEPTION -- {exception}\n");
            }
        }
        private void InfoLogging(string message, Dictionary<object, object> properties, string methodName)
        {
            DateTime dt = DateTime.Now;
            string date = dt.ToString("yyyy-MM-dd");
            string time = dt.ToLongTimeString();
            string directory = @"C:\Users\Impervm\Desktop\Logs";
            string subDirPath = @"C:\Users\Impervm\Desktop\Logs\" + date;
            string subDirName = date;
            string logPath = $@"C:\Users\Impervm\Desktop\Logs\{date}\Info.log";
            DirectoryInfo directoryInfo = new DirectoryInfo(directory);
            DirectoryInfo subDir = new DirectoryInfo(subDirPath);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
                directoryInfo.CreateSubdirectory(subDirName);
            }
            else if (!subDir.Exists)
            {
                subDir.Create();
            }
            using (StreamWriter streamWriter = new StreamWriter(logPath, true, System.Text.Encoding.Default))
            {
                streamWriter.Write(date + "  :  " + time + "  ----  (" + methodName + ") --- " + message + $"PROPERTY {properties}\n");
            }
        }
        private void Logging(string message, string methodName, params object[] args)
        {
            DateTime dt = DateTime.Now;
            string date = dt.ToString("yyyy-MM-dd");
            string time = dt.ToLongTimeString();
            string directory = @"C:\Users\Impervm\Desktop\Logs";
            string subDirPath = @"C:\Users\Impervm\Desktop\Logs\" + date;
            string subDirName = date;
            string logPath = $@"C:\Users\Impervm\Desktop\Logs\{date}\error.log";
            DirectoryInfo directoryInfo = new DirectoryInfo(directory);
            DirectoryInfo subDir = new DirectoryInfo(subDirPath);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
                directoryInfo.CreateSubdirectory(subDirName);
            }
            else if (!subDir.Exists)
            {
                subDir.Create();
            }
            using (StreamWriter streamWriter = new StreamWriter(logPath, true, System.Text.Encoding.Default))
            {
                streamWriter.Write(date + "  :  " + time + "  ----  (" + methodName + ") --- " + message + $"ARGS{args}\n");
            }
        }
        private void Logging(Exception exception, string methodName)
        {
            DateTime dt = DateTime.Now;
            string date = dt.ToString("yyyy-MM-dd");
            string time = dt.ToLongTimeString();
            string directory = @"C:\Users\Impervm\Desktop\Logs";
            string subDirPath = @"C:\Users\Impervm\Desktop\Logs\" + date;
            string subDirName = date;
            string logPath = $@"C:\Users\Impervm\Desktop\Logs\{date}\error.log";
            DirectoryInfo directoryInfo = new DirectoryInfo(directory);
            DirectoryInfo subDir = new DirectoryInfo(subDirPath);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
                directoryInfo.CreateSubdirectory(subDirName);
            }
            else if (!subDir.Exists)
            {
                subDir.Create();
            }
            using (StreamWriter streamWriter = new StreamWriter(logPath, true, System.Text.Encoding.Default))
            {
                streamWriter.Write(date + "  :  " + time + "  ----  (" + methodName + ") --- " + $"EXCEPTION -- {exception}\n");
            }
        }
       
    }
    public interface ILog
    {
        /// <summary>
        /// Критичная ошибка:приложение не может далее функционировать
        /// </summary>
        /// <param name="message">сообщение</param>
        void Fatal(string message);

        /// <summary>
        /// Критичная ошибка:приложение не может далее функционировать
        /// </summary>
        /// <param name="message">сообщение</param>
        /// <param name="e">Exception</param>
        void Fatal(string message, Exception e);

        /// <summary>
        /// Ошибка в работе приложения: операция расчета завершается, но приложение продолжает работу
        /// </summary>
        /// <param name="message">сообщение</param>
        void Error(string message);

        /// <summary>
        /// Ошибка в работе приложения: операция расчета завершается, но приложение продолжает работу
        /// </summary>
        /// <param name="message">сообщение</param>
        /// <param name="e">Exception</param>
        void Error(string message, Exception e);

        /// <summary>
        /// Ошибка в работе приложения: операция расчета завершается, но приложение продолжает работу
        /// </summary>
        /// <param name="ex"></param>
        void Error(Exception ex);

        /// <summary>
        /// Запись уникальных ошибок
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        void ErrorUnique(string message, Exception e);

        /// <summary>
        /// Предупреждение: на работу приложения не влияет, 
        /// но может сообщать о потенциальных проблемах в расчете
        /// </summary>
        /// <param name="message">сообщение</param>
        void Warning(string message);

        /// <summary>
        /// Предупреждение: на работу приложения не влияет, 
        /// но может сообщать о потенциальных проблемах в расчете
        /// </summary>
        /// <param name="message">сообщение</param>
        /// <param name="e">Exception</param>
        void Warning(string message, Exception e);


        /// <summary>
        /// Пишет в лог уникальные в течении дня ошибки 
        /// </summary>
        /// <param name="message">сообщение</param>
        /// <remarks>
        /// Если в течении дня поступают сообщения с одинаковым содержанием,
        ///  то в лог попадут только первые вхождения. 
        /// По прошествию дня уникальность возобновляется.
        /// </remarks>>
        void WarningUnique(string message);

        /// <summary>
        /// Информирование: не влияет на работу приложения,
        /// является инструментом информирования
        /// </summary>
        /// <param name="message">сообщение</param>
        void Info(string message);

        /// <summary>
        /// Информирование: не влияет на работу приложения,
        /// является инструментом информирования
        /// </summary>
        /// <param name="message">сообщение</param>
        ///  /// <param name="e">Exception</param>
        void Info(string message, Exception e);

        /// <summary>
        /// Информирование: не влияет на работу приложения,
        /// является инструментом информирования
        /// </summary>
        /// <param name="message">сообщение</param>
        /// <param name="args">аргументы</param>
        void Info(string message, params object[] args);

        /// <summary>
        /// Дебагирование: инструмент для трассировки и отладки
        /// </summary>
        /// <param name="message">сообщение</param>
        void Debug(string message);

        /// <summary>
        /// Дебагирование: инструмент для трассировки и отладки
        /// </summary>
        /// <param name="message">сообщение</param>
        /// <param name="e">Exception</param>
        void Debug(string message, Exception e);

        /// <summary>
        /// Дебагирование: инструмент для трассировки и отладки
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args">аргументы</param>
        void DebugFormat(string message, params object[] args);
        /// <summary>
        /// Запись системных логов информационного характера
        /// </summary>
        /// <param name="message"></param>
        /// <param name="properties"></param>
        void SystemInfo(string message, Dictionary<object, object> properties = null);
    }
}
