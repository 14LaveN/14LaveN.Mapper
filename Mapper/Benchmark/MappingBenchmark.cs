using BenchmarkDotNet.Attributes;
using Mapper.Entities;

namespace Mapper;

public class MappingBenchmark
{
    private readonly Source _source;
    private readonly IMapper<Source, Destination> _originalMapper;
    private readonly IMapper<Source, Destination> _optimizedMapper;

    public MappingBenchmark()
    {
        _source = new Source { Id = 1, Name = "Test", Date = DateTime.Now };
        _originalMapper = new GenericMapper<Source, Destination>();
        _optimizedMapper = new OptimizedMapper<Source, Destination>();
    }

    [Benchmark]
    public Destination OriginalMapperBenchmark() => _originalMapper.Map(_source);

    [Benchmark]
    public Destination OptimizedMapperBenchmark() => _optimizedMapper.Map(_source);
}