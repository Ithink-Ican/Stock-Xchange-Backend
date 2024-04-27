namespace Domain.Issuers
{
    public class Issuer
    {
        public IssuerId Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Guid CommentId { get; private set; }
    }
}
