using TryCatchPresentation.Exceptions;

namespace TryCatchPresentation.Models
{
    internal class DomainObject
    {
        // business says it is impossible for this array to have more than 2 elements
        private int[] ints = new int[2];

        public DomainObject(int first, int second)
        {
            if (first > second)
            {
                throw new DomainObjectFirstCannotBeBiggerThanSecondException();
            }
            ints[0] = first;
            ints[1] = second;
        }

        /// <summary>
        /// Get value from Array based on an given index
        /// </summary>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void MethodThatWillThrowException(int index)
        {
            Console.WriteLine(ints[index]);
        }

        /// <summary>
        /// Get value from Array based on an given index
        /// </summary>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void MethodThatWillThrowExceptionWithTryCatch(int index)
        {
            try
            {
                Console.WriteLine(ints[index]);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get value from Array based on an given index
        /// </summary>
        /// <exception cref="AccessingInvalidIndexOfDomainObjectCollectionException"></exception>
        public void MethodThatWillThrowExceptionDomainException(int index)
        {
            if (index > ints.Length || index < 0)
            {
                throw new AccessingInvalidIndexOfDomainObjectCollectionException(index, ints.Length);
            }

            Console.WriteLine(ints[index]);
        }

        /// <summary>
        /// Getting the value based on the index. Since this is very popular endpoint, many calls (and exceptions, as we cannot expect all of our consumers to send valid data) will result in performance issues.
        /// Exceptions are at least 30,000 times slower than return codes.
        /// </summary>
        /// <returns>
        /// Int value if found in array. Otherwise null
        /// </returns>
        public int? VeryPopularMethodThatCouldPossiblyThrowException(int index)
        {
            TryGetValue(index, out int? result);
            return result;
        }

        private bool TryGetValue(int index, out int? result)
        {
            result = default;

            if (index > ints.Length || index < 0)
            {
                return false;
            }

            result = ints[index];
            return true;
        }
    }
}