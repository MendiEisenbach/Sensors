using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;


namespace Sensors.Models
{

    public class IranianAgent
    {
        private List<string> weaknesses;        

        private List<Sensor> attachedSensors;   

        public IranianAgent(List<string> weaknesses)
        {
            this.weaknesses = new List<string>();
            foreach (string weakness in weaknesses)
            {
                this.weaknesses.Add(weakness);
            }

            attachedSensors = new List<Sensor>();
        }

        public void AttachSensor(Sensor sensor)
        {
            attachedSensors.Add(sensor);
        }

        public (int correct, int total) ActivateSensors()
        {
            int correctCount = 0;

            List<string> tempWeaknesses = new List<string>();
            foreach (string weakness in weaknesses)
            {
                tempWeaknesses.Add(weakness);
            }

            foreach (Sensor sensor in attachedSensors)
            {
                string? match = null;

                foreach (string weakness in tempWeaknesses)
                {
                    if (sensor.Activate(weakness))
                    {
                        match = weakness;
                        break;
                    }
                }

                if (match != null)
                {
                    correctCount++;
                    tempWeaknesses.Remove(match);
                }
            }

            return (correctCount, weaknesses.Count);
        }

        public bool IsExposed()
        {
            var result = ActivateSensors();
            return result.correct == result.total;
        }
    }

}
