using System;
using Microwave.Classes.Boundary;
using Microwave.Classes.Controllers;

namespace Microwave.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Button startCancelButton = new Button();
            Button powerButton = new Button();
            Button timeButton = new Button();

            Door door = new Door();

            Output output = new Output();

            Display display = new Display(output);

            //PowerTube powerTube = new PowerTube(output);


            output.OutputLine($"Change the power of the powertube between 500-1000");
            int value = Convert.ToInt32(Console.ReadLine());
            PowerTube powerTube2 = new PowerTube(output,value);

            Buzzer buzzer = new Buzzer(output);

            Light light = new Light(output);

            Microwave.Classes.Boundary.Timer timer = new Timer();

            CookController cooker = new CookController(timer, display, powerTube2);

            UserInterface ui = new UserInterface(powerButton, timeButton, startCancelButton, door, buzzer, display, light, cooker);

            // Finish the double association
            cooker.UI = ui;

            // Simulate a simple sequence

            powerButton.Press();

            timeButton.Press();
            // Time button pressed two times to prolong the amount of time
            timeButton.Press();

            startCancelButton.Press();

            // The simple sequence should now run

            System.Console.WriteLine("When you press enter, the program will stop");
            // Wait for input

            System.Console.ReadLine();
        }
    }
}
