using Microwave.Classes.Boundary;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Microwave.Classes.Interfaces;
using NSubstitute;

namespace Microwave.Test.Unit
{
    [TestFixture]
    public class BuzzerTest
    {
        private Buzzer uut;
        private IOutput output;

        [SetUp]
        public void Setup()
        {
            output = Substitute.For<IOutput>();
            uut = new Buzzer(output);
        }

        [TestCase(1000,1)]
        [TestCase(1000, 2)]
        [TestCase(1000, 3)]
        public void playBuzzerThreeTimesWithDurationOfOneSecond(int dur, int amount)
        {
            uut.playBuzz(dur,amount);
            output.Received(amount).OutputLine($"Microwave buzzes for {dur}");
        }

        [TestCase(1000, -1)]
        [TestCase(1000, 4)]
        public void playBuzzerThreeTimesWithException(int dur, int amount)
        {
            //uut.playBuzz(dur, amount);
            Assert.That(() => uut.playBuzz(dur, amount), Throws.TypeOf<ArgumentException>());
        }
    }
}
