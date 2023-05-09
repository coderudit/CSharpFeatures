using AutoFixture;
using BenchmarkDotNet.Attributes;

namespace JsonBenchmarks;

[MemoryDiagnoser]
public class JsonBenchmark
{
    private static readonly IFixture Fixture = new Fixture();
    private static readonly User User = Fixture.Create<User>();
    private const string UserAsText = "{\"PublicGists\":170, \"Following\":240, \"Followers\": 130}";

    [Benchmark]
    public string Serialization_Text_Newtonsoft() => Newtonsoft.Json.JsonConvert.SerializeObject(User);
    
    [Benchmark]
    public string Serialization_Text_SystemTextJson() => System.Text.Json.JsonSerializer.Serialize(User);
    
    [Benchmark]
    public string Serialization_Text_Jil() => Jil.JSON.Serialize(User);
    
    [Benchmark]
    public string Serialization_Text_Utf8Json() => Utf8Json.JsonSerializer.ToJsonString(User);

    [Benchmark]
    public User Deserialization_Text_Newtonsoft() => Newtonsoft.Json.JsonConvert.DeserializeObject<User>(UserAsText);
    
    [Benchmark]
    public User Deserialization_Text_SystemTextJson() => System.Text.Json.JsonSerializer.Deserialize<User>(UserAsText);
    
    [Benchmark]
    public User Deserialization_Text_Jil() => Jil.JSON.Deserialize<User>(UserAsText);
    
    [Benchmark]
    public User Deserialization_Text_Utf8Json() => Utf8Json.JsonSerializer.Deserialize<User>(UserAsText);
}