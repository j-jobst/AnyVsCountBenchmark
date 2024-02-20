using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace AnyVsCountBenchmark;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[MemoryDiagnoser]
public class PerformanceBenchmark
{
    private static readonly IEnumerable<int> _numbersEnumerable = Enumerable.Range(1, 50000);
    private static readonly ICollection<int> _numbersCollection = Enumerable.Range(1, 50000).ToList();
    private static readonly List<int> _numbersList = Enumerable.Range(1, 50000).ToList();

    [Benchmark]
    public bool CheckEnumerableWithAny()
    {
        return _numbersEnumerable.Any();
    }
    
    [Benchmark]
    public bool CheckEnumerableWithAnyAndCondition()
    {
        return _numbersEnumerable.Any(x => x > 500);
    }
    
    [Benchmark]
    public bool CheckEnumerableWithCount()
    {
        return _numbersEnumerable.Count() > 0;
    }
    
    [Benchmark]
    public bool CheckEnumerableWithCountAndCondition()
    {
        return _numbersEnumerable.Count(x => x > 500) > 0;
    }
    
    [Benchmark]
    public bool CheckCollectionWithAny()
    {
        return _numbersCollection.Any();
    }
    
    [Benchmark]
    public bool CheckCollectionWithAnyAndCondition()
    {
        return _numbersCollection.Any(x => x > 500);
    }
    
    [Benchmark]
    public bool CheckCollectionWithCount()
    {
        return _numbersCollection.Count() > 0;
    }
    
    [Benchmark]
    public bool CheckCollectionWithCountAndCondition()
    {
        return _numbersCollection.Count(x => x > 500) > 0;
    }
    
    [Benchmark]
    public bool CheckCollectionWithCountProperty()
    {
        return _numbersCollection.Count > 0;
    }
    
    [Benchmark]
    public bool CheckListWithAny()
    {
        return _numbersList.Any();
    }
    
    [Benchmark]
    public bool CheckListWithCountProperty()
    {
        return _numbersList.Count > 0;
    }
}