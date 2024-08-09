// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using Mapper;

var summary = BenchmarkRunner.Run<MappingBenchmark>();

Console.WriteLine("Hello, World!");