using System;
using FlubuCore.Tasks;
using FlubuCore.Tasks.Process;

namespace FlubuCore.Chocolatey
{
    public class ChocolateyBaseTask<TTask> : ExternalProcessTaskBase<int, TTask>  where TTask : class, ITask
    {
        protected override string Description { get; set; }

        /// <summary>
        /// Debug - Show debug messaging.
        /// </summary>
        /// <returns></returns>
        public TTask Debug()
        {
            WithArguments("--debug");
            return this as TTask;
        }

        /// <summary>
        ///  Verbose - Show verbose messaging. Very verbose messaging, avoid using under normal circumstances.
        /// </summary>
        /// <returns></returns>
        public TTask Verbose()
        {
            WithArguments("--verbose");
            return this as TTask;
        }

        /// <summary>
        /// Show trace messaging. Very, very verbose trace messaging. Avoid except when needing super low-level .NET Framework debugging.
        /// </summary>
        /// <returns></returns>
        public TTask Trace()
        {
            WithArguments("--trace");
            return this as TTask;
        }

        /// <summary>
        ///  No Color - Do not show colorization in logging output. This overrides the feature 'logWithoutColor', set to 'False'
        /// </summary>
        /// <returns></returns>
        public TTask NoColor()
        {
            WithArguments("--no-color");
            return this as TTask;
        }

        /// <summary>
        ///  AcceptLicense - Accept license dialogs automatically. Reserved for future use.
        /// </summary>
        /// <returns></returns>
        public TTask AcceptLicence()
        {
            WithArguments("--accept-licence");
            return this as TTask;
        }

        /// <summary>
        /// Confirm all prompts - Chooses affirmative answer instead of prompting.
        /// </summary>
        /// <returns></returns>
        public TTask Confirm()
        {
            WithArguments("--confirm");
            return this as TTask;
        }

        /// <summary>
        /// Force - force the behavior. Do not use force during normal operation -it subverts some of the smart behavior for commands.
        /// </summary>
        /// <returns></returns>
        public TTask Force()
        {
            WithArguments("--force");
            return this as TTask;
        }

        /// <summary>
        ///  NoOp / WhatIf - Don't actually do anything.
        /// </summary>
        /// <returns></returns>
        public TTask NoOp()
        {
            WithArguments("--noop");
            return this as TTask;
        }

        /// <summary>
        ///  LimitOutput - Limit the output to essential information
        /// </summary>
        /// <returns></returns>
        public TTask LimitOutput()
        {
            WithArguments("--limit-output");
            return this as TTask;
        }

        /// <summary>
        ///  CommandExecutionTimeout (in seconds) - The time to allow a command to finish before timing out. Overrides the default execution timeout in the configuration of 2700 seconds.
        /// </summary>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public TTask Timeout(int timeout)
        {
            WithArguments("--timeout", timeout.ToString());
            return this as TTask;
        }

        /// <summary>
        ///  CacheLocation - Location for download cache, defaults to %TEMP% or value in chocolatey.config file.
        /// </summary>
        /// <param name="cacheLocation"></param>
        /// <returns></returns>
        public TTask CacheLocation(string cacheLocation)
        {
            WithArguments("--cache-location", cacheLocation);
            return this as TTask;
        }

        /// <summary>
        /// AllowUnofficialBuild - When not using the official build you must set this flag for choco to continue.
        /// </summary>
        /// <returns></returns>
        public TTask AllowUnofficial()
        {
            WithArguments("--allow-unofficial");
            return this as TTask;
        }

        /// <summary>
        ///  FailOnStandardError - Fail on standard error output (stderr), typically received when running external commands during install providers. This
        /// overrides the feature failOnStandardError.
        /// </summary>
        /// <returns></returns>
        public TTask FailOnStandardError()
        {
            WithArguments("--fail-on-stderr");
            return this as TTask;
        }

        /// <summary>
        /// Proxy Location - Explicit proxy location. Overrides the default proxy location of ''.
        /// </summary>
        /// <param name="proxy"></param>
        /// <returns></returns>
        public TTask Proxy(string proxy)
        {
            WithArguments($"--proxy={proxy}");
            return this as TTask;
        }

        /// <summary>
        /// Proxy User Name - Explicit proxy user (optional). Requires explicity proxy (`--proxy` or config setting). Overrides the default proxy user of '123'.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public TTask ProxyUser(string user)
        {
            WithArguments($"--proxy-user={user}");
            return this as TTask;
        }

        /// <summary>
        /// proxy Password - Explicit proxy password (optional) to be used with username. Requires explicity proxy (`--proxy` or config setting) and user name. 
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public TTask ProxyPassword(string password)
        {
            WithArguments($"--proxy-password={password}", true);
            return this as TTask;
        }

        /// <summary>
        /// ProxyBypassList - Comma separated list of regex locations to bypass on proxy. Requires explicity proxy (`--proxy` or config setting). Overrides the default proxy bypass list of ''.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public TTask ProxyBypassList(string list)
        {
            WithArguments($"--proxy-bypass-list={list}");
            return this as TTask;
        }

        /// <summary>
        ///    Proxy Bypass On Local - Bypass proxy for local connections. Requires explicity proxy (`--proxy` or config setting). Overrides the default proxy bypass on local setting of 'True'.
        /// </summary>
        /// <returns></returns>
        public TTask ProxyBypassOnLocal()
        {
            WithArguments("--proxy-bypass-on-local");
            return this as TTask;
        }

        /// <summary>
        ///  Log File to output to in addition to regular loggers. 
        /// </summary>
        /// <param name="logFile"></param>
        /// <returns></returns>
        public TTask LogFile(string logFile)
        {
            WithArguments($"--log-file={logFile}");
            return this as TTask;
        }
    }
}
