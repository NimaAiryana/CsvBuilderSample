namespace CsvSample.Example
{
    internal class Foo
    {
        public Foo(Guid id, long number, string name, string desc)
        {
            Id = id;
            Number = number;
            Name = name;
            Desc = desc;
        }

        public Guid Id { get; set; }
        public long Number { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
    }
}
