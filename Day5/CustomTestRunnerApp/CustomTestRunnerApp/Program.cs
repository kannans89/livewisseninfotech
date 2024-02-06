



using CustomTestRunnerApp;
using System.Reflection;

 var assembly= Assembly.GetExecutingAssembly();
foreach (var type in assembly.GetTypes()) {
   // Console.WriteLine(type.Name);

    foreach (var method in type.GetMethods())
    {
        foreach (Attribute attribute in method.GetCustomAttributes())
        {
            if (attribute is MyTestCase)
            {
                Console.WriteLine(method.Name);
                var output = (bool)method.Invoke(Activator.CreateInstance(type), null);
                Console.WriteLine($"{output} ==> {method.Name}");
                if (output)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Test Pass");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Test failed");
                    Console.ResetColor();
                }
            }
        }
    }

}