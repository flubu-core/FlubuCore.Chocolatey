﻿using System;
using System.Collections.Generic;
using System.Text;
using FlubuCore.Context;
using FlubuCore.Tasks;
using FlubuCore.Tasks.Process;
using NuGet.Packaging;

namespace FlubuCore.Chocolatey
{
    public class ChocolateyInstallTask : ChocolateyBaseTask<ChocolateyInstallTask>
    {
        private string[] packages;

        public ChocolateyInstallTask(params string[] package)
        {
            ExecutablePath = "choco";
            WithArguments("install");
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
        public ChocolateyInstallTask Source(string source)
        {
            WithArguments($"--source={source}");
            return this;
        }

        /// <summary>
        /// Version - A specific version to install. Defaults to unspecified.
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public ChocolateyInstallTask Version(string version)
        {
            WithArguments($"--version={version}");
            return this;
        }

        /// <summary>
        /// Prerelease - Include Prereleases? Defaults to false.
        /// </summary>
        /// <returns></returns>
        public ChocolateyInstallTask IncludePrerelease()
        {
            WithArguments("--prerelease");
            return this;
        }

        /// <summary>
        /// ForceX86 - Force x86 (32bit) installation on 64 bit systems. Defaults to false.
        /// </summary>
        /// <returns></returns>
        public ChocolateyInstallTask ForceX86()
        {
            WithArguments("--forceX86");
            return this;
        }

        /// <summary>
        ///  InstallArguments - Install Arguments to pass to the native installer in the package. Defaults to unspecified.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public ChocolateyInstallTask InstallArguments(string parameter)
        {
            WithArguments($"--package-parameters={parameter}");
            return this;
        }

        public ChocolateyInstallTask OverrideArguments()
        {
            WithArguments("--override-arguments");
            return this;
        }

        public ChocolateyInstallTask PackageParameters(string parameters)
        {
            WithArguments($"--package-parameters={parameters}");
            return this;
        }

        /// <summary>
        /// Apply Install Arguments To Dependencies  - Should install arguments be applied to dependent packages? Defaults to false.
        /// </summary>
        /// <returns></returns>
        public ChocolateyInstallTask ApplyInstallArgumentsToDependencies()
        {
            WithArguments("--apply-args-to-dependencies");
            return this;
        }

        /// <summary>
        ///  Apply Package Parameters To Dependencies  - Should package parameters be applied to dependent packages? Defaults to false.
        /// </summary>
        /// <returns></returns>
        public ChocolateyInstallTask ApplyPackageParametersToDependencies()
        {
            WithArguments("--apply-package-parameters-to-dependencies");
            return this;
        }

        /// <summary>
        ///    AllowMultipleVersions - Should multiple versions of a package be installed? Defaults to false.
        /// </summary>
        /// <returns></returns>
        public ChocolateyInstallTask AllowMultipleVersions()
        {
            WithArguments("--allow-multiple-versions");
            return this;
        }

        /// <summary>
        /// AllowDowngrade - Should an attempt at downgrading be allowed? Defaults to false.
        /// </summary>
        /// <returns></returns>
        public ChocolateyInstallTask AllowDowngrade()
        {
            WithArguments("--allow-downgrade");
            return this;
        }

        /// <summary>
        /// ForceDependencies - Force dependencies to be reinstalled when force installing package(s). Must be used in conjunction with --force.
        /// </summary>
        /// <returns></returns>
        public ChocolateyInstallTask ForceDependencies()
        {
            WithArguments("--force-dependencies");
            return this;
        }

        /// <summary>
        ///  IgnoreDependencies - Ignore dependencies when installing package(s).
        /// </summary>
        /// <returns></returns>
        public ChocolateyInstallTask IgnoreDependencies()
        {
            WithArguments("--ignore-dependencies");
            return this;
        }

        /// <summary>
        /// Skip Powershell - Do not run chocolateyInstall.ps1. Defaults to false.
        /// </summary>
        /// <returns></returns>
        public ChocolateyInstallTask SkipAutomationScripts()
        {
            WithArguments(" --skip-automation-scripts");
            return this;
        }

        /// <summary>
        ///  User - used with authenticated feeds. Defaults to empty.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ChocolateyInstallTask User(string user)
        {
            WithArguments($"--user={user}");
            return this;
        }

        /// <summary>
        ///  Password - the user's password to the source. Defaults to empty.
        /// </summary>
        /// <param name="paswword"></param>
        /// <returns></returns>
        public ChocolateyInstallTask Password(string paswword)
        {
            WithArguments($"--password={paswword}", true);
            return this;
        }

        /// <summary>
        /// Client certificate - PFX pathname for an x509 authenticated feeds. Defaults to empty. Available in 0.9.10+.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public ChocolateyInstallTask Cert(string path)
        {
            WithArguments($"--cert={path}");
            return this;
        }

        /// <summary>
        ///   Certificate Password - the client certificate's password to the source. Defaults to empty. Available in 0.9.10+.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public ChocolateyInstallTask CertPassword(string password)
        {
            WithArguments($"--certpassword={password}", true);
            return this;
        }

        /// <summary>
        ///  IgnoreChecksums - Ignore checksums provided by the package. Overrides the default feature 'checksumFiles' set to 'True'. Available in 0.9.9.9+.
        /// </summary>
        /// <returns></returns>
        public ChocolateyInstallTask IgnoreChecksums()
        {
            WithArguments($"--ignore-checksums");
            return this;
        }

        /// <summary>
        ///   Allow Empty Checksums - Allow packages to have empty/missing checksums for downloaded resources from non-secure locations (HTTP, FTP). Use this
        ///   switch is not recommended if using sources that download resources from the internet. Overrides the default feature 'allowEmptyChecksums' set to  'False'. Available in 0.10.0+.
        /// </summary>
        /// <returns></returns>
        public ChocolateyInstallTask AllowEmptyChecksums()
        {
            WithArguments("--allow-empty-checksums");
            return this;
        }

        /// <summary>
        /// Allow Empty Checksums Secure - Allow packages to have empty checksums for downloaded resources from secure locations (HTTPS). Overrides the
        /// default feature 'allowEmptyChecksumsSecure' set to 'True'. Available in 0.10.0+.
        /// </summary>
        /// <returns></returns>
        public ChocolateyInstallTask AllowEmptyChecksumsSecure()
        {
            WithArguments("--allow-empty-checksums-secure");
            return this;
        }

        /// <summary>
        /// Require Checksums - Requires packages to have checksums for downloaded resources (both non-secure and secure). Overrides the default feature
        /// 'allowEmptyChecksums' set to 'False' and 'allowEmptyChecksumsSecure' set to 'True'. Available in 0.10.0+.
        /// </summary>
        /// <returns></returns>
        public ChocolateyInstallTask RequireCheckSums()
        {
            WithArguments("--require-checksums");
            return this;
        }

        /// <summary>
        /// Download Checksum - a user provided checksum for downloaded resources for the package. Overrides the package checksum (if it has one).
        /// Defaults to empty. Available in 0.10.0+.
        /// </summary>
        /// <returns></returns>
        public ChocolateyInstallTask DownloadChecksum(string checksum)
        {
            WithArguments($"--download-checksum={checksum}");
            return this;
        }

        /// <summary>
        /// Download Checksum 64bit - a user provided checksum for 64bit downloaded resources for the package. Overrides the package 64-bit checksum (if it has one).
        /// Defaults to same as Download Checksum. Available in 0.10.0+.
        /// </summary>
        /// <param name="checksum"></param>
        /// <returns></returns>
        public ChocolateyInstallTask DownloadChecksumX64(string checksum)
        {
            WithArguments($"--download-checksum-x64={checksum}");
            return this;
        }

        /// <summary>
        /// Download Checksum Type 64bit - a user provided checksum for 64bit downloaded resources for the package. Overrides the package 64-bit
        /// checksum (if it has one). Used in conjunction with Download Checksum  64bit. Available values are 'md5', 'sha1', 'sha256' or 'sha512'.
        /// Defaults to same as Download Checksum Type. Available in 0.10.0+.
        /// </summary>
        /// <param name="checksumType"></param>
        /// <returns></returns>
        public ChocolateyInstallTask DownloadChecksumType(string checksumType)
        {
            WithArguments($"--download-checksum-type={checksumType}");
            return this;
        }

        /// <summary>
        /// IgnorePackageExitCodes - Exit with a 0 for success and 1 for non-succes-s, no matter what package scripts provide for exit codes. Overrides the
        /// default feature 'usePackageExitCodes' set to 'True'. Available in 0.-9.10+.
        /// </summary>
        /// <returns></returns>
        public ChocolateyInstallTask IgnorePackageExitCodes()
        {
            WithArguments("--ignore-package-exit-codes");
            return this;
        }

        /// <summary>
        /// UsePackageExitCodes - Package scripts can provide exit codes. Use those  for choco's exit code when non-zero (this value can come from a
        ///    dependency package). Chocolatey defines valid exit codes as 0, 1605, 1614, 1641, 3010.  Overrides the default feature 'usePackageExitCodes' set to 'True'. Available in 0.9.10+.
        /// </summary>
        /// <returns></returns>
        public ChocolateyInstallTask UsePackageExitCodes()
        {
            WithArguments("--use-package-exit-codes");
            return this;
        }

        public ChocolateyInstallTask StopOnFirstPackageFailiure()
        {
            WithArguments("--stop-on-first-package-failure");
            return this;
        }

        /// <summary>
        ///  Exit When Reboot Detected - Stop running install, upgrade, or uninstall when a reboot request is detected. Requires 'usePackageExitCodes'
        ///  feature to be turned on. Will exit with either 350 or 1604.  Overrides  the default feature 'exitOnRebootDetected' set to 'False'.  Available in  0.10.12+.
        /// </summary>
        /// <returns></returns>
        public ChocolateyInstallTask ExitWhenRebotDetected()
        {
            WithArguments("--exit-when-reboot-detected");
            return this;
        }

        /// <summary>
        /// Ignore Detected Reboot - Ignore any detected reboots if found. Overrides  the default feature 'exitOnRebootDetected' set to 'False'.  Available in 0.10.12+.
        /// </summary>
        /// <returns></returns>
        public ChocolateyInstallTask IgnoreDetectedReboot()
        {
            WithArguments("--ignore-detected-reboot");
            return this;
        }

        /// <summary>
        ///  Skip Download Cache - Use the original download even if a private CDN cache is available for a package. Overrides the default feature
        /// 'downloadCache' set to 'True'. Available in 0.9.10+. [Licensed editions](https://chocolatey.org/compare) only. See https://chocolatey.org/docs/features-private-cdn
        /// </summary>
        /// <returns></returns>
        public ChocolateyInstallTask SkipDownloadCache()
        {
            WithArguments("--skip-download-cache");
            return this;
        }

        public ChocolateyInstallTask UseDownloadCache()
        {
            WithArguments("--use-download-cache");
            return this;
        }

        /// <summary>
        /// kip Virus Check - Skip the virus check for downloaded files on this run. Overrides the default feature 'virusCheck' set to 'True'. Available
        /// in 0.9.10+. [Licensed editions](https://chocolatey.org/compare) only. See https://chocolate-y.org/docs/features-virus-check
        /// </summary>
        /// <returns></returns>
        public ChocolateyInstallTask SkipVirusCheck()
        {
            WithArguments("--skip-virus-check");
            return this;
        }

        /// <summary>
        ///  Virus Check - check downloaded files for viruses. Overrides the default feature 'virusCheck' set to 'True'. Available in 0.9.10+. Licensed
        ///    editions only. See https://chocolatey.org/docs/features-virus-check
        /// </summary>
        /// <returns></returns>
        public ChocolateyInstallTask VirusCheck()
        {
            WithArguments("--virus-check");
            return this;
        }

        /// <summary>
        ///  Virus Check Minimum Scan Result Positives - the minimum number of scan result positives required to flag a package. Used when virusScannerType
        ///  is VirusTotal. Overrides the default configuration value 'virusCheckMinimumPositives' set to '5'. Available in 0.9.10+. Licensed editions only. See https://chocolatey.org/docs/features-virus-check
        /// </summary>
        /// <returns></returns>
        public ChocolateyInstallTask VirusPositiveMin()
        {
            WithArguments("--viruspositivesmin");
            return this;
        }

        /// <summary>
        /// InstallArgumentsSensitive - Install Arguments to pass to the native installer in the package that are sensitive and you do not want logged.
        ///  Defaults to unspecified. Available in 0.10.1+. [Licensed editions](https://chocolatey.org/compare) only.
        /// </summary>
        /// <param name="argument"></param>
        /// <returns></returns>
        public ChocolateyInstallTask InstallArgumentsSensitive(string argument)
        {
            WithArguments($"--install-arguments-sensitive={argument}", true);
            return this;
        }

        /// <summary>
        /// PackageParametersSensitive - Package Parameters to pass the package that
        /// are sensitive and you do not want logged. Defaults to unspecified.
        /// Available in 0.10.1+. [Licensed editions](https://chocolatey.org/compare) only.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public ChocolateyInstallTask PackageParametersSensitive(string parameter)
        {
            WithArguments($"--package-parameters-sensitive={parameter}", true);
            return this;
        }

        /// <summary>
        /// Maximum Download Rate Bits Per Second - The maximum download rate in  bits per second. '0' or empty means no maximum. A number means that will
        /// be the maximum download rate in bps. Defaults to config setting of '0'.  Available in [licensed editions](https://chocolatey.org/compare) v1.10+ only. See https://chocolate- y.org/docs/features-package-throttle
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ChocolateyInstallTask MaxDownloadRate(int value)
        {
            WithArguments($"--max-download-rate={value}");
            return this;
        }

        /// <summary>
        /// Reducer Installed Package Size (Package Reducer) - Reduce size of the nupkg file to very small and remove extracted archives and installers.
        /// Overrides the default feature 'reduceInstalledPackageSpaceUsage' set to 'True'. [Licensed editions](https://chocolatey.org/compare) only (version 1.12.0+). See https://chocolate-y.org/docs/features-package-reducer
        /// </summary>
        /// <returns></returns>
        public ChocolateyInstallTask ReducePackageSize()
        {
            WithArguments("--reduce-package-siz");
            return this;
        }

        /// <summary>
        /// Do Not Reduce Installed Package Size - Leave the nupkg and files alone in the package. Overrides the default feature
        /// 'reduceInstalledPackageSpaceUsage' set to 'True'. [Licensed editions](https://chocolatey.org/compare) only (version 1.12.0+). See https://chocolatey.org/docs/features-package-reducer
        /// </summary>
        /// <returns></returns>
        public ChocolateyInstallTask NoReducePackageSize()
        {
            WithArguments("--no-reduce-package-size");
            return this;
        }

        /// <summary>
        /// Reduce Only Nupkg File Size - reduce only the size of nupkg file when using Package Reducer. Overrides the default feature
        /// 'reduceOnlyNupkgSize' set to 'False'. [Licensed editions](https://chocolatey.org/compare) only (version -1.12.0+). See https://chocolatey.org/docs/features-package-reducer
        /// </summary>
        /// <returns></returns>
        public ChocolateyInstallTask ReduceNupkgOnly()
        {
            WithArguments("--reduce-nupkg-only");
            return this;
        }

        protected override string Description { get; set; }
    }
}
