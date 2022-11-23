using System;
using System.ComponentModel;
using Microwave.Classes.Interfaces;

namespace Microwave.Classes.Boundary
{
    public class PowerTube : IPowerTube
    {
        private IOutput myOutput;
        public int DefaultValue = 700;

        private bool IsOn = false;

        public PowerTube(IOutput output)
        {
            myOutput = output;
        }


        public void changePowerTubeValue(int  newValue)
        {
            if(newValue < 500 || newValue > 1000)
                throw new ArgumentOutOfRangeException($"Please , Insert value between 500 and 1000");

            this.DefaultValue = newValue;

        }

        public void TurnOn(int power)
        {
            if (power < 1 || DefaultValue < power)
            {
                throw new ArgumentOutOfRangeException("power", power, $"Must be between 1 and {DefaultValue} (incl.)");
            }

            if (IsOn)
            {
                throw new ApplicationException("PowerTube.TurnOn: is already on");
            }

            myOutput.OutputLine($"PowerTube works with {power}");
            IsOn = true;
        }

        public void TurnOff()
        {
            if (IsOn)
            {
                myOutput.OutputLine($"PowerTube turned off");
            }

            IsOn = false;
        }
    }
}