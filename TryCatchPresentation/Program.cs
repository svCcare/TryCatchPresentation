using TryCatchPresentation.Exceptions;

namespace TryCatchPresentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var domainObject = new DomainObject(2, 3);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Throw basic Exception (show on release verions)");
                Console.WriteLine("2. Throw the same Exception, but now handled");
                Console.WriteLine("3. Throw the same Exception, but now handled, no stack");
                Console.WriteLine("4. Throw the same Exception, but now handled, stack");
                Console.WriteLine("5. Let's nest some code");
                Console.WriteLine("6. Nested try catch v1");
                Console.WriteLine("7. Nested try catch v2");
                Console.WriteLine("8. Nested try catch v3 with custom exception");
                Console.WriteLine("9. Will General Exception be handled by specific catch?");
                Console.WriteLine("10. Very popular endpoint that could potentially throw exception. But won't");
                Console.WriteLine("11. How about centralized exception handling?");
                Console.WriteLine("12. ApplicationException?");
                Console.WriteLine("0. Exit");
                Console.Write("Enter the number of your choice: ");

                // Read user input
                string input = Console.ReadLine();

                // Validate and process user input
                if (int.TryParse(input, out int choice))
                {
                    Console.WriteLine("_______________________________________________________________________");
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine($"You have selected Option {choice}. Performing action...");
                            throw new Exception("Something went wrong");
                        case 2:
                            Console.WriteLine($"You have selected Option {choice}. Performing action...");
                            try
                            {
                                throw new Exception("Something went wrong");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"{ex.Message}");
                                break;
                            }
                        case 3: // throw vs throw ex
                            Console.WriteLine($"You have selected Option {choice}. Performing action...");
                            try
                            {
                                ThrowingMethod();
                                break;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"{ex.Message}");
                                throw ex;
                            }
                        case 4: // throw vs throw ex
                            Console.WriteLine($"You have selected Option {choice}. Performing action...");
                            try
                            {
                                ThrowingMethod();
                                break;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"{ex.Message}");
                                throw;
                            }
                        case 5: // very nested try catch
                            Console.WriteLine($"You have selected Option {choice}. Performing action...");
                            try
                            {
                                try
                                {
                                    try
                                    {
                                        throw new Exception("error");
                                    }
                                    catch (Exception ex)
                                    {
                                        throw;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    throw;
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"{ex.Message}");
                                break;
                            }
                        case 6: // testing nested try catch
                            Console.WriteLine($"You have selected Option {choice}. Performing action...");
                            domainObject.MethodThatWillThrowExceptionWithTryCatch(3);
                            break;
                        case 7: // testing nested try catch
                            Console.WriteLine($"You have selected Option {choice}. Performing action...");
                            try
                            {
                                domainObject.MethodThatWillThrowException(3);
                                break;
                            }
                            catch (IndexOutOfRangeException ex)
                            {
                                Console.WriteLine($"{ex.Message}");
                                break;
                            }
                        case 8: // testing nested try catch but with CustomException
                            Console.WriteLine($"You have selected Option {choice}. Performing action...");
                            try
                            {
                                domainObject.MethodThatWillThrowExceptionDomainException(3);
                                break;
                            }
                            catch (AccessingInvalidIndexOfDomainObjectCollectionException ex) when (ex.Index < 0)
                            {
                                Console.WriteLine($"{ex.Message}");
                                Console.WriteLine($"Index cannot be negative");
                                break;
                            }
                            catch (AccessingInvalidIndexOfDomainObjectCollectionException ex) when (ex.Index > ex.CollectionSize)
                            {
                                Console.WriteLine($"{ex.Message}");
                                break;
                            }
                            //https://thomaslevesque.com/2015/06/21/exception-filters-in-c-6/
                            catch (AccessingInvalidIndexOfDomainObjectCollectionException ex)
                            {
                                if (ex.Index < 0)
                                {
                                    Console.WriteLine($"{ex.Message}");
                                    Console.WriteLine($"Index cannot be negative");
                                }
                                if (ex.Index > ex.CollectionSize)
                                {
                                    Console.WriteLine($"{ex.Message}");
                                }
                                break;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"{ex.Message}");
                                break;
                            }
                        case 9: // general vs specific (multiple catch statements)
                            Console.WriteLine($"You have selected Option {choice}. Performing action...");
                            try
                            {
                                throw new Exception("Very general error");
                            }
                            catch (IOException specificException)
                            {
                                Console.WriteLine($"{specificException.Message}");
                                break;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"{ex.Message}");
                                break;
                            }
                        case 10: // avoiding performance issues when throwing many exceptions
                            Console.WriteLine($"You have selected Option {choice}. Performing action...");
                            var result = domainObject.VeryPopularMethodThatCouldPossiblyThrowException(30);
                            Console.WriteLine(result);
                            break;
                        case 11: // centralized way of handling errors
                            try
                            {
                                ThrowingMethodAnotherException();
                            }
                            catch (IOException ex)
                            {
                                ErrorHandler.HandleException(ex);
                                break;
                            }
                            break;
                        case 12: // ApplicationException
                            try
                            {
                                throw new ApplicationException();
                            }
                            catch (ApplicationException ex)
                            {
                                ErrorHandler.HandleException(ex);
                                break;
                            }
                        case 0:
                            Console.WriteLine("Exiting program. Goodbye!");
                            return; // Exit the program
                        default:
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }

                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }

        private static void ThrowingMethod()
        {
            throw new Exception("Something went wrong");
        }

        private static void ThrowingMethodAnotherException()
        {
            throw new IOException("OI Exception");
        }
    }
}