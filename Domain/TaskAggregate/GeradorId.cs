namespace Domain.UserAggregate
{
    internal class GeradorId
    {
        static int nextId;
        public int Id { get; set; }

        public int AtribuirId()
        {
            Id = Interlocked.Increment(ref nextId);
            return Id;
        }
    }
}
