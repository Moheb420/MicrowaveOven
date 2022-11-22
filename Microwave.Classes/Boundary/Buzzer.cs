using System;
using System.Collections.Generic;
using System.Text;
using Microwave.Classes.Interfaces;

namespace Microwave.Classes.Boundary
{
    public class Buzzer:IBuzzer
    {
        private IOutput output;

        public Buzzer(IOutput output_)
        {
            output = output_;
        }

        public void playBuzz(int duration, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                output.OutputLine($"Microwave buzzes for {duration}");
            }
        }
    }
}
