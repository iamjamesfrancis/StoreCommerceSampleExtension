namespace Microsoft.Dynamics.Commerce.Sdk.Installers.StoreCommerce
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Microsoft.Dynamics.Commerce.Installers.Framework;
    using Microsoft.Dynamics.Commerce.Installers.Framework.DatabaseExtensions;
    using Microsoft.Dynamics.Commerce.Sdk.Installers;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Class representing a Store Commerce extension package installer setup.
    /// </summary>
    public sealed class StoreCommerceExtensionPackageInstallerSetup : ExtensionPackageInstallerSetup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StoreCommerceExtensionPackageInstallerSetup"/> class.
        /// </summary>
        public StoreCommerceExtensionPackageInstallerSetup() : base(Assembly.GetExecutingAssembly())
        {
            this.InstallerCommandLineOption = new object();

            this.CoreInstallSteps = new List<IInstallerStep>()
            {
                new InstallOfflineDatabaseExtensionsStep(),
            };

            this.CoreUninstallSteps = new List<IInstallerStep>();
        }

        /// <summary>
        /// Gets the value for the installer name.
        /// </summary>
        public override string InstallerName { get; } = "Store Commerce";

        /// <inheritdoc/>
        public override string ExtensionName => "AVS.TestExtension";

        /// <summary>
        /// Gets the configuration sources.
        /// </summary>
        public IEnumerable<IConfigurationSource> InstallerConfigurationSources { get; }

        /// <summary>
        /// Gets the command line options for Store Commerce extension installer.
        /// </summary>
        public object InstallerCommandLineOption { get; }

        /// <summary>
        /// Gets a set of Installer Step Context Configuration properties to be persisted once installation is completed.
        /// </summary>
        public override IEnumerable<string> ConfigurationPropertiesToPersist
        {
            get
            {
                return Array.Empty<string>();
            }
        }

        /// <summary>
        /// Gets the core/stock install steps for the Store Commerce extension installer.
        /// </summary>
        protected override IReadOnlyCollection<IInstallerStep> CoreInstallSteps { get; }

        /// <summary>
        /// Gets the core/stock uninstall steps for the Store Commerce extension installer.
        /// </summary>
        protected override IReadOnlyCollection<IInstallerStep> CoreUninstallSteps { get; }

        /// <summary>
        /// Gets the core/stock pre-install steps for the Store Commerce extension installer.
        /// </summary>
        protected override IReadOnlyCollection<IInstallerStep> CorePreInstallSteps { get; }
    }
}