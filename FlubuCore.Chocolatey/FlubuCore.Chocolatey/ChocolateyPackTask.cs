using System;
using System.Collections.Generic;
using System.Text;

namespace FlubuCore.Chocolatey
{
    public class ChocolateyPackTask : ChocolateyBaseTask<ChocolateyPackTask>
    {
        public ChocolateyPackTask(string pathToNuspec)
        {
            ExecutablePath = "choco";
            WithArguments("pack");
            WithArguments(pathToNuspec);
        }

        public ChocolateyPackTask Version(string version)
        {
            WithArguments($"--version={version}");
            return this;
        }

        public ChocolateyPackTask OutputDirectory(string directory)
        {
            WithArguments($"--outdir={directory}");
            return this;
        }
    }
}
