using System.Reflection;

namespace BlazorDynamicComponentsWithCallbacks.Utils;

public static class ReflectionHelpers
{
  public static Type? ResolveComponent(string componentNamespacePrefix, string componentName)
  {
    var componentAssembly = componentNamespacePrefix.Split('.').First();
    var assembly = Assembly.Load(componentAssembly);

    var res = assembly.GetTypes()
            .Where(t =>
                t.Namespace != null &&
                t.Namespace.StartsWith(componentNamespacePrefix, StringComparison.InvariantCultureIgnoreCase))
            .Where(t => t.Name.Equals(componentName, StringComparison.InvariantCultureIgnoreCase))
            .FirstOrDefault();
    return res;
  }
}
