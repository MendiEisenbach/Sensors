using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sensors.Models;

namespace Sensors.Managers
{
    public class InvestigationManager
    {
        private IranianAgent agent;
        private List<Sensor> availableSensors;

        public void StartGame()
        {
            Console.WriteLine("Investigation begins: Iranian agent");

            agent = new IranianAgent(new List<string> { "Thermal", "Thermal" });

            availableSensors = new List<Sensor>
        {
            new Sensor("Thermal"),
            new Sensor("Motion")
        };

            while (!agent.IsExposed())
            {
                Console.WriteLine("\nSelect a sensor to add:");
                for (int i = 0; i < availableSensors.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {availableSensors[i].Name}");
                }

                Console.Write("Enter a number: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int choice) && choice >= 1 && choice <= availableSensors.Count)
                {
                    var chosenSensor = availableSensors[choice - 1];
                    agent.AttachSensor(chosenSensor);

                    var (correct, total) = agent.ActivateSensors();
                    Console.WriteLine($"result: {correct}/{total} correct");
                }
                else
                {
                    Console.WriteLine("Incorrect input. Please try again.");
                }
            }

            Console.WriteLine("\nThe agent was successfully exposed!");
        }
    }

}
