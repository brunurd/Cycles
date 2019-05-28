namespace Cycles.Examples
{
    class HelloWorld
    {
        static void Main(string[] args)
        {
            var middleware = new LoggerMiddleware();

            // Success cycle.
            var myCycleSuccess = new MyCycle();
            myCycleSuccess.Start("Cycles");

            // It's a dead cycle.
            myCycleSuccess.Start("I'm alive?");
        }
    }
}