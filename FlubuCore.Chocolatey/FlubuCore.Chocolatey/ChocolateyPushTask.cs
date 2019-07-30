using System;
using System.Collections.Generic;
using System.Text;

namespace FlubuCore.Chocolatey
{
    public class ChocolateyPushTask : ChocolateyBaseTask<ChocolateyPushTask>
    {
        public string _path;

        public ChocolateyPushTask()
        {
            ExecutablePath = "choco";
            WithArguments("push");
        }

        public ChocolateyPushTask PathToNupkg(string path)
        {
            _path = path;
            return this;
        }

        /// <summary>
        ///   Source - The source we are pushing the package to. Use https://push.chocolatey.org/ to push to [community feed](https://chocolatey.org/packages).
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public ChocolateyPushTask Source(string source)
        {
            WithArguments($"--source={source}");
            return this;
        }

        /// <summary>
        ///  ApiKey - The api key for the source. If not specified (and not local file source), does a lookup. If not specified and one is not found for an https source, push will fail.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public ChocolateyPushTask ApiKey(string key)
        {
            WithArguments($"--key={key}", true);
            return this;
        }

        /// <summary>
        /// Timeout (in seconds) - The time to allow a package push to occur before timing out. Defaults to execution timeout 2700.
        /// </summary>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public ChocolateyPushTask Timeout(int timeout)
        {
            WithArguments($"-t={timeout}");
            return this;
        }
    }
}
