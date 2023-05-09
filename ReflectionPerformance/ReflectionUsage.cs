using System.Reflection;
using ReflectionPerformance.External;

namespace ReflectionPerformance;

public static class ReflectionUsage
{
    public static string SimpleGet()
    {
        var someClass = new VeryPublicClass();
        return someClass.VeryPublicProperty;
    }
    
    public static string TraditionalReflection()
    {
        var someClass = new VeryPublicClass();
        var propertyInfo = someClass.GetType()
            .GetProperty("VeryPrivateProperty", BindingFlags.Instance | BindingFlags.NonPublic);
        var value = propertyInfo!.GetValue(someClass);
        return value!.ToString();
    }
    
    private static  readonly PropertyInfo CachedProperty = typeof(VeryPublicClass).GetProperty("VeryPrivateProperty", BindingFlags.Instance | BindingFlags.NonPublic);
    public static string OptimizedReflection()
    {
        var someClass = new VeryPublicClass();
        var value = CachedProperty!.GetValue(someClass);
        return value!.ToString();
    }
}