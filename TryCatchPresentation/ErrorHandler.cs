namespace TryCatchPresentation
{
    public static class ErrorHandler
    {
        public static void HandleException(Exception exception)
        {
            LogException(exception);

            ShowErrorMessage(exception);
        }

        private static void LogException(Exception exception)
        {
            // logger.Log
        }

        private static void ShowErrorMessage(Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}
