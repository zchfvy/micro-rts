namespace NLog {
    public static class Log {
        static readonly Logger _log = LoggerFactory.GetLogger("Log");

        public static void Trace(string message) {
            _log.Trace(message);
        }

        public static void Trace(string message, params object[] format) {
            _log.Trace(string.Format(message, format));
        }

        public static void Debug(string message) {
            _log.Debug(message);
        }

        public static void Debug(string message, params object[] format) {
            _log.Debug(string.Format(message, format));
        }

        public static void Info(string message) {
            _log.Info(message);
        }

        public static void Info(string message, params object[] format) {
            _log.Info(string.Format(message, format));
        }

        public static void Warn(string message) {
            _log.Warn(message);
        }

        public static void Warn(string message, params object[] format) {
            _log.Warn(string.Format(message, format));
        }

        public static void Error(string message) {
            _log.Error(message);
        }

        public static void Error(string message, params object[] format) {
            _log.Error(string.Format(message, format));
        }

        public static void Fatal(string message) {
            _log.Fatal(message);
        }

        public static void Fatal(string message, params object[] format) {
            _log.Fatal(string.Format(message, format));
        }

        public static void Assert(bool condition, string message) {
            _log.Assert(condition, message);
        }

        public static void Assert(bool condition, string message, params object[] format) {
            _log.Assert(condition, string.Format(message, format));
        }
    }
}

