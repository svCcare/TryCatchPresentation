namespace TryCatchPresentation.Exceptions
{
    [Serializable]
    internal class AccessingInvalidIndexOfDomainObjectCollectionException : Exception
    {
        public int Index { get; }
        public int CollectionSize { get; }

        public AccessingInvalidIndexOfDomainObjectCollectionException(int index, int collectionSize) : base("Index out of range")
        {
            Index = index;
            CollectionSize = collectionSize;
        }
    }
}