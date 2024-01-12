namespace TryCatchPresentation
{
    [Serializable]
    internal class DomainObjectFirstCannotBeBiggerThanSecondException : Exception
    {
        public DomainObjectFirstCannotBeBiggerThanSecondException()
        {
        }

        public DomainObjectFirstCannotBeBiggerThanSecondException(string? message) : base(message)
        {
        }

        public DomainObjectFirstCannotBeBiggerThanSecondException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}