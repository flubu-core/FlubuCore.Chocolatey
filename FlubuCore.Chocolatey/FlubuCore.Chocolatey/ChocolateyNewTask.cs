using System;
using System.Collections.Generic;
using System.Text;

namespace FlubuCore.Chocolatey
{
    public class ChocolateyNewTask : ChocolateyBaseTask<ChocolateyNewTask>
    {
        public ChocolateyNewTask(string name)
        {
            ExecutablePath = "choco";
            WithArguments("new", name);
        }

        public ChocolateyNewTask AutomaticPackage()
        {
            WithArguments("--automaticpackage");
            return this;
        }

        /// <summary>
        /// TemplateName - Use a named template in C:\ProgramData\chocolatey\templates\templatename instead of built-in
        ///  template. Available in 0.9.9.9+. Manage templates as packages in 0.9.10+.
        /// </summary>
        /// <returns></returns>
        public ChocolateyNewTask Template(string name)
        {
            WithArguments($"--template-name={name}");
            return this;
        }

        /// <summary>
        ///  Version - the version of the package. Can also be passed as the property;
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public ChocolateyNewTask Version(string version)
        {
            WithArguments($"--version={version}");
            return this;
        }

        /// <summary>
        /// Maintainer - the name of the maintainer. Can also be passed as the property MaintainerName=somevalue
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ChocolateyNewTask Maintainer(string name)
        {
            WithArguments($"--maintainer={name}");
            return this;
        }

        /// <summary>
        /// OutputDirectory - Specifies the directory for the created Chocolatey package file. If not specified, uses the current directory. Available in
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        public ChocolateyNewTask OutputDirectory(string directory)
        {
            WithArguments($"--outdir={directory}");
            return this;
        }

        /// <summary>
        ///  BuiltInTemplate - Use the original built-in template instead of any override. Available in 0.9.10+.
        /// </summary>
        /// <returns></returns>
        public ChocolateyNewTask UseBuiltInTemplate()
        {
            WithArguments("--use-built-in-template");
            return this;
        }

        /// <summary>
        /// detection (native installer, zip, patch/upgrade file, or remote url to download first) to completely create a package with proper silent
        /// arguments! Can be 32-bit or 64-bit architecture.  Available in licensed editions only (licensed version 1.4.0+, url/zip starting in 1.6.0). See https://chocolatey.org/docs/features-create-packages-from-installers
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ChocolateyNewTask FileOrUrl(string value)
        {
            WithArguments($"--url={value}");
            return this;
        }

        /// <summary>
        ///  Use Original Files Location - when using file or url, use the original location in packaging. Available in [licensed editions](https://chocolatey.org/compare) only (licensed version 1.6.0+).
        /// </summary>
        /// <returns></returns>
        public ChocolateyNewTask UseOriginalFilesLocation()
        {
            WithArguments("--use-original-files-location");
            return this;
        }

        /// <summary>
        ///   Download Checksum - checksum to verify File/Url with. Defaults to empty. Available in [licensed editions](https://chocolatey.org/compare) only (licensed version 1.7.0+).
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ChocolateyNewTask DownloadCheckSum(string value)
        {
            WithArguments($"--download-checksum={value}");
            return this;
        }

        /// <summary>
        /// Download Checksum Type - checksum type for File/Url (and optional separate 64-bit files when specifying both). Used in conjunction with
        /// Download Checksum and Download Checksum 64-bit. Available values are 'md5', 'sha1', 'sha256' or 'sha512'. Defaults to 'sha256'.  Available in Business editions only (licensed version 1.7.0+).
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ChocolateyNewTask DownloadChecksumType(string value)
        {
            WithArguments($"--download-checksum-type={value}");
            return this;
        }

        /// <summary>
        /// Pause on Error - Pause when there is an error with creating the package. Available in [licensed editions](https://chocolatey.org/compare) only (licensed version 1.7.0+).
        /// </summary>
        /// <returns></returns>
        public ChocolateyNewTask PauseOnError()
        {
            WithArguments("--pause-on-error");
            return this;
        }

        /// <summary>
        ///  Build Package - Attempt to compile the package after creating it.  Available in [licensed editions](https://chocolatey.org/compare) only (licensed version 1.7.0+).
        /// </summary>
        /// <returns></returns>
        public ChocolateyNewTask BuildPackages()
        {
            WithArguments("--build-packages");
            return this;
        }

        /// <summary>        /// Generate Packages From Installed Software - Generate packages from the installed software on a system (does not handle dependencies). Available in Business editions only (licensed version 1.8.0+).
        /// </summary>
        /// <returns></returns>
        public ChocolateyNewTask FromProgramsAndFeatures()
        {
            WithArguments("--from-programs-and-features");
            return this;
        }

        /// <summary>
        ///  Include Architecture in Package Name - Leave x86, x64, 64-bit, etc as part of the package id. Default setting is to remove architecture. Available in Business editions only (licensed version 1.8.0+).
        /// </summary>
        /// <returns></returns>
        public ChocolateyNewTask IncludeArchitectureInName()
        {
            WithArguments("--include-architecture-in-name");
            return this;
        }
    }
}
