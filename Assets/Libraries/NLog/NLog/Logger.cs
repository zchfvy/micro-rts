using System;

namespace NLog {
    public class Logger {
        public event LogDelegate OnLog;

        public delegate void LogDelegate(Logger logger, LogLevel logLevel, string message);

        public LogLevel logLevel { get; set; }

        public string name { get; private set; }

        public Logger(string name) {
            this.name = name;
        }

        public void Trace(string message) {
            log(LogLevel.Trace, message);
        }

        public void Trace(string message, params object[] format) {
            log(LogLevel.Trace, string.Format(message, format));
        }

        public void Debug(string message) {
            log(LogLevel.Debug, message);
        }

        public void Debug(string message, params object[] format) {
            log(LogLevel.Debug, string.Format(message, format));
        }

        public void Info(string message) {
            log(LogLevel.Info, message);
        }

        public void Info(string message, params object[] format) {
            log(LogLevel.Info, string.Format(message, format));
        }

        public void Warn(string message) {
            log(LogLevel.Warn, message);
        }

        public void Warn(string message, params object[] format) {
            log(LogLevel.Warn, string.Format(message, format));
        }

        public void Error(string message) {
            log(LogLevel.Error, message);
        }

        public void Error(string message, params object[] format) {
            log(LogLevel.Error, string.Format(message, format));
        }

        public void Fatal(string message) {
            log(LogLevel.Fatal, message);
        }

        public void Fatal(string message, params object[] format) {
            log(LogLevel.Fatal, string.Format(message, format));
        }

        public void Assert(bool condition, string message) {
            if (!condition) {
                throw new NLogAssertException(message);
            }
        }

        void log(LogLevel logLvl, string message) {
            if (OnLog != null && logLevel <= logLvl) {
                OnLog(this, logLvl, message);
            }
        }
    }

    public class NLogAssertException : Exception {
        public NLogAssertException(string message) : base(message) {
        }
    }
}

