using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceRuntime
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Dynamics.Commerce.Runtime;
    using Microsoft.Dynamics.Commerce.Runtime.DataModel;
    using Microsoft.Dynamics.Commerce.Runtime.Messages;

/// <summary>
/// Class that implements a post trigger for the GetExtensionPackageDefinitionsRequest request type.
/// </summary>
public class DefinePosExtensionPackageTrigger : IRequestTrigger
{
    /// <summary>
    /// Gets the supported requests for this trigger.
    /// </summary>
    public IEnumerable<Type> SupportedRequestTypes
    {
        get
        {
            return new[] { typeof(GetExtensionPackageDefinitionsRequest) };
        }
    }

    /// <summary>
    /// Post trigger to retrieve extension package.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="response">The response.</param>
    public void OnExecuted(Request request, Response response)
    {
        var getExtensionsResponse = (GetExtensionPackageDefinitionsResponse)response;
        var extensionPackageDefinition = new ExtensionPackageDefinition();

        // Should match the PackageName used when packaging the customization package.
        extensionPackageDefinition.Name = "AVS.TestExtension";
        extensionPackageDefinition.Publisher = "Alpha Variance Solutions";
        extensionPackageDefinition.IsEnabled = true;

        getExtensionsResponse.ExtensionPackageDefinitions.Add(extensionPackageDefinition);
    }

    public void OnExecuting(Request request)
    {
    }
}
}
