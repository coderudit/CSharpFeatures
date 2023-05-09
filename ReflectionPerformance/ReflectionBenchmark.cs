using BenchmarkDotNet.Attributes;

namespace ReflectionPerformance;

[MemoryDiagnoser]
public class ReflectionBenchmark
{
    [Benchmark]
    public string SimpleGet() => ReflectionUsage.SimpleGet();
    
    [Benchmark]
    public string TraditionalReflection() => ReflectionUsage.TraditionalReflection();
    
    [Benchmark]
    public string OptimizedReflection() => ReflectionUsage.OptimizedReflection();
}