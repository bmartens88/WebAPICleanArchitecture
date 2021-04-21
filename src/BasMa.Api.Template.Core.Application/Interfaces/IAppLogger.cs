namespace BasMa.Api.Template.Core.Application.Interfaces
{
    /// <summary>
    /// This type eliminates the need to depend directly on the ASP.NET Core logging types
    /// </summary>
    /// <typeparam name="T">Type for which to log messages</typeparam>
    public interface IAppLogger<T>
    {
        /// <summary>
        /// Formats and writes an informational log message
        /// </summary>
        /// <param name="message">Format string of the log message</param>
        /// <param name="args">An object array containing zero or more objects to format</param>
        void LogInformation(string message, params object[] args);

        /// <summary>
        /// Formats and writes a warning log message
        /// </summary>
        /// <param name="message">Format string of the log message</param>
        /// <param name="args">An object array containing zero or more objects to format</param>
        void LogWarning(string message, params object[] args);
    }
}
