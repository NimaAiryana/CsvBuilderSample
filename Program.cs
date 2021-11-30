using CsvSample.Example;
using CsvSample.Export;

Console.WriteLine("Hello, World!");

List<Foo> foos = new List<Foo>()
{
    new Foo(Guid.NewGuid(), 1, "Nima1", "Desc1"),
    new Foo(Guid.NewGuid(), 2, "Nima2", "Desc2"),
    new Foo(Guid.NewGuid(), 3, "Nima3", "Desc3")
};

var path = "Path";
var fileName = "nima";

List<string> headers = new List<string>()
{
    nameof(Foo.Id),
    nameof(Foo.Name)
};

path = CsvBuilder<Foo>.Build(foos, headers, path, fileName);
