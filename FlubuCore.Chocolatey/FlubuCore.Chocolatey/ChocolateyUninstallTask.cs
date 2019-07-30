using System;
using System.Collections.Generic;
using System.Text;
using FlubuCore.Context;
using FlubuCore.Tasks;
using FlubuCore.Tasks.Process;
using NuGet.Packaging;

namespace FlubuCore.Chocolatey
{
    public class ChocolateyUninstallTask : ChocolateyBaseTask<ChocolateyUninstallTask>
    {
        private string[] packages;

        public ChocolateyUninstallTask(params string[] package)
        {
            ExecutablePath = "choco";
            WithArguments("uninstall");
            packages = package;
        }

        protected override int DoExecute(ITaskContextInternal context)
        {
            foreach (var package in packages)
            {
                InsertArgument(2, package);
            }

            return 0;
        }

        /// <summary>
        ///  Source - The source to find the package(s) to install. Special sources include: ruby, webpi, cygwin, windowsfeatures, and python. To specify
        ///  more than one source, pass it with a semi-colon separating the values (-e.g. "'source1;source2'"). Defaults to default feeds.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public ChocolateyUninstallTask Source(string source)
        {
            WithArguments($"--source={source}");
            return this;
        }

        /// <summary>
        /// Version - A specific version to install. Defaults to unspecified.
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public ChocolateyUninstallTask Version(string version)
        {
            WithArguments($"--version={version}");
            return this;
        }

        /// <summary>
        ///  InstallArguments - Install Arguments to pass to the native installer in the package. Defaults to unspecified.
        /// </summary>
        /// <param name="argument"></param>
        /// <returns></returns>
        public ChocolateyUninstallTask UninstallArguments(string argument)
        {
            WithArguments($"--uninstall-argumentss={argument}");
            return this;
        }

        public ChocolateyUninstallTask OverrideArguments()
        {
            WithArguments("--override-arguments");
            return this;
        }

        public ChocolateyUninstallTask PackageParameters(string parameters)
        {
            WithArguments($"--package-parameters={parameters}");
            return this;
        }

        /// <summary>
        /// Apply Install Arguments To Dependencies  - Should install arguments be applied to dependent packages? Defaults to false.
        /// </summary>
        /// <returns></returns>
        public ChocolateyUninstallTask ApplyInstallArgumentsToDependencies()
        {
            WithArguments("--apply-args-to-dependencies");
            return this;
        }

        /// <summary>
        ///  Apply Package Parameters To Dependencies  - Should package parameters be applied to dependent packages? Defaults to false.
        /// </summary>
        /// <returns></returns>
        public ChocolateyUninstallTask ApplyPackageParametersToDependencies()
        {
            WithArguments("--apply-package-parameters-to-dependencies");
            return this;
        }

        /// <summary>
        ///  AllowMultipleVersions - Should multiple versions of a package be installed? Defaults to false.
        /// </summary>
        /// <returns></returns>
        public ChocolateyUninstallTask AllowMultipleVersions()
        {
            WithArguments("--allow-multiple-versions");
            return this;
        }

        /// <summary>
        /// RemoveDependencies - Uninstall dependencies when uninstalling package(s). Defaults to false.
        /// </summary>
        /// <returns></returns>
        public ChocolateyUninstallTask RemoveDependencies()
        {
            WithArguments("--remove-dependencies");
            return this;
        }

        /// <summary>
        /// Skip Powershell - Do not run chocolateyUninstall.ps1. Defaults to false.
        /// </summary>
        /// <returns></returns>
        public ChocolateyUninstallTask SkipAutomationScripts()
        {
            WithArguments("--skip-automation-scripts");
            return this;
        }

        /// <summary>
        ///  IgnorePackageExitCodes - Exit with a 0 for success and 1 for non-succes-s, no matter what package scripts provide for exit codes. Overrides the
        ///  default feature 'usePackageExitCodes' set to 'True'. Available in 0.9.10+.
        /// </summary>
        /// <returns></returns>
        public ChocolateyUninstallTask IgnorePackageExitCodes()
        {
            WithArguments("--ignore-package-exit-codes");
            return this;
        }

        /// <summary>
        /// UsePackageExitCodes - Package scripts can provide exit codes. Use those for choco's exit code when non-zero (this value can come from a dependency package). Chocolatey defines valid exit codes as 0, 1605,
        /// 1614, 1641, 3010. Overrides the default feature 'usePackageExitCodes' set to 'True'. Available in 0.9.10+.
        /// </summary>
        /// <returns></returns>
        public ChocolateyUninstallTask UsePackageExitCodes()
        {
            WithArguments("--use-package-exit-codes");
            return this;
        }

        /// <summary>
        /// UseAutoUninstaller - Use auto uninstaller service when uninstalling. Overrides the default feature 'autoUninstaller' set to 'True'. Available in 0.9.10+.
        /// </summary>
        /// <returns></returns>
        public ChocolateyUninstallTask UseAutoUninstaller()
        {
            WithArguments("--use-autouninstaller");
            return this;
        }

        /// <summary>
        ///  SkipAutoUninstaller - Skip auto uninstaller service when uninstalling. Overrides the default feature 'autoUninstaller' set to 'True'. Available in 0.9.10+.
        /// </summary>
        /// <returns></returns>
        public ChocolateyUninstallTask SkipAutoInstaller()
        {
            WithArguments("--skip-autouninstaller");
            return this;
        }

        /// <summary>
        /// FailOnAutoUninstaller - Fail the package uninstall if the auto uninstaller reports and error. Overrides the default feature 'failOnAutoUninstaller' set to 'False'. Available in 0.9.10+.
        /// </summary>
        /// <returns></returns>
        public ChocolateyUninstallTask FailOnAutoUninstaller()
        {
            WithArguments("--fail-on-autouninstaller");
            return this;
        }

        /// <summary>
        ///  --ignoreautouninstallerfailure, --ignore-autouninstaller-failure Ignore Auto Uninstaller Failure - Do not fail the package if auto uninstaller reports an error. Overrides the default feature 'failOnAutoUninstaller' set to 'False'. Available in 0.9.10+.
        /// </summary>
        /// <returns></returns>
        public ChocolateyUninstallTask IgnoreAutoUninstallerFailure()
        {
            WithArguments("--ignore-autouninstaller-failure");
            return this;
        }

        /// <summary>
        ///  Stop On First Package Failure - stop running install, upgrade or uninstall on first package failure instead of continuing with others.
        ///  Overrides the default feature 'stopOnFirstPackageFailure' set to 'False'. Available in 0.10.4+.
        /// </summary>
        /// <returns></returns>
        public ChocolateyUninstallTask StopOnFirstPackageFailure()
        {
            WithArguments("--stop-on-first-package-failure");
            return this;
        }

        /// <summary>
        /// Exit When Reboot Detected - Stop running install, upgrade, or uninstall when a reboot request is detected. Requires 'usePackageExitCodes'
        /// feature to be turned on. Will exit with either 350 or 1604.  Overrides the default feature 'exitOnRebootDetected' set to 'False'.  Available in 0.10.12+.
        /// </summary>
        /// <returns></returns>
        public ChocolateyUninstallTask ExitWhenRebootDetected()
        {
            WithArguments("--exit-when-reboot-detected");
            return this;
        }

        /// <summary>
        ///  Ignore Detected Reboot - Ignore any detected reboots if found. Overrides the default feature 'exitOnRebootDetected' set to 'False'.  Available in 0.10.12+.
        /// </summary>
        /// <returns></returns>
        public ChocolateyUninstallTask IgnoreDetectedReboot()
        {
            WithArguments("--ignore-detected-reboot");
            return this;
        }

        /// <summary>
        ///  From Programs and Features - Uninstalls a program from programs and features. Name used for id must be a match or a wildcard (*) to Display
        /// Name in Programs and Features. Available in [licensed editions](https://chocolatey.org/compare) only (licensed version 1.8.0+) and requires v0.10.4+.
        /// </summary>
        /// <returns></returns>
        public ChocolateyUninstallTask FromProgramsAndFeatures()
        {
            WithArguments("--from-programs-and-features");
            return this;
        }

        protected override string Description { get; set; }
    }
}
