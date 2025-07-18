using CSharpFunctionalExtensions;

namespace WEB.Domain.Venue
{
    public record VenueName
    {
        private VenueName(string prefix, string name)
        {
            Prefix = prefix;
            Name = name;
        }

        public string Prefix { get; }
        public string Name { get; }
        public override string ToString() => $"{Prefix}-{Name}";

        public static Result<VenueName> Create(string prefix, string name)
        {
            if (string.IsNullOrWhiteSpace(prefix) || string.IsNullOrWhiteSpace(name))
            {
                return Result.Failure<VenueName>("prefix or name can not be empty!");
            }

            return Result.Success(new VenueName(prefix, name));
        }
    }
}