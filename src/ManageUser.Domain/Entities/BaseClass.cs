namespace ManageUser.Domain.Entities
{
    public abstract class BaseClass
    {
        public long Id { get; set; }

        internal List<string> _errors { get; set; }

        public IReadOnlyCollection<string> Errors => _errors;

        public abstract bool Validate();
    }
}
