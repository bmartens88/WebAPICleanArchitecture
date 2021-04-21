using BasMa.Api.Template.Core.Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace BasMa.Api.Template.Infrastructure.Shared.Logging
{
    public class LoggerAdapter<T> : IAppLogger<T>
    {
        // Logger which actually logs the messages
        private readonly ILogger<T> _logger;

        /// <summary>
        /// Constructor of the LoggerAdapter class
        /// </summary>
        /// <param name="loggerFactory">ILoggerFactory instance</param>
        public LoggerAdapter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }

        ///<inheritdoc/>
        public void LogInformation(string message, params object[] args) =>
            _logger.LogInformation(message, args);

        ///<inheritdoc/>
        public void LogWarning(string message, params object[] args) =>
            _logger.LogWarning(message, args);
    }
}
