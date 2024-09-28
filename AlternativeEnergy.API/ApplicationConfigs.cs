#nullable disable

namespace AlternativeEnergy.API
{
    public sealed class ApplicationConfigs
    {
        public LoggingConfiguration Logging { get; set; }
        public string AllowedHosts { get; set; }
        public JwtSettingsConfiguration JwtSettings { get; set; }
        public DbSettingsConfiguration DbSettings { get; set; }

        public class LoggingConfiguration
        {
            public LogLevelConfiguration LogLevel { get; set; }

            public class LogLevelConfiguration
            {
                public string Default { get; set; }
                public string MicrosoftAspNetCore { get; set; }
            }
        }

        public class JwtSettingsConfiguration
        {
            public string SecretKey { get; set; }
            public TimeSpan LifeTime { get; set; }
        }

        public class DbSettingsConfiguration
        {
            public bool UseEFCore { get; set; }
        }
    }
}
