namespace Project.Controllers
{
    public class GreetingDependency : IGreetingDependency
    {
        private int _counter;
        public string Greeting()
        {
            String greeting = "Hello";
            for (int i = 0; i < _counter; i++)
            {
                greeting += ", hello";
            }
            greeting += " world!";
            _counter++;
            return greeting;
        }
    }
}