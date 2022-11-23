using Microwave.Classes.Boundary;
using Microwave.Classes.Interfaces;
using NSubstitute;
using NSubstitute.Core.Arguments;
using NUnit.Framework;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;

namespace Microwave.Test.Unit
{
    [TestFixture]
    public class PowerTubeTest
    {
        private PowerTube uut;
        private IOutput output;

        [SetUp]
        public void Setup()
        {
            output = Substitute.For<IOutput>();
            uut = new PowerTube(output);
        }

        [TestCase(1)]
        [TestCase(50)]
        [TestCase(100)]
        [TestCase(699)]
        [TestCase(700)]
        public void TurnOn_WasOffCorrectPower_CorrectOutput(int power)
        {
            uut.TurnOn(power);
            output.Received().OutputLine(Arg.Is<string>(str => str.Contains($"{power}")));
        }

        [TestCase(-5)]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(701)]
        [TestCase(750)]
        public void TurnOn_WasOffOutOfRangePower_ThrowsException(int power)
        {
            Assert.Throws<System.ArgumentOutOfRangeException>(() => uut.TurnOn(power));
        }

        [Test]
        public void TurnOff_WasOn_CorrectOutput()
        {
            uut.TurnOn(50);
            uut.TurnOff();
            output.Received().OutputLine(Arg.Is<string>(str => str.Contains("off")));
        }

        [Test]
        public void TurnOff_WasOff_NoOutput()
        {
            uut.TurnOff();
            output.DidNotReceive().OutputLine(Arg.Any<string>());
        }

        [Test]
        public void TurnOn_WasOn_ThrowsException()
        {
            uut.TurnOn(50);
            Assert.Throws<System.ApplicationException>(() => uut.TurnOn(60));
        }

        [TestCase(500)]
        [TestCase(501)]
        [TestCase(1000)]
        [TestCase(999)]
        public void Change_Power_of_PowerTube_With_Different_Values(int value)
        {
            uut.changePowerTubeValue(value);
            Assert.AreEqual(uut.DefaultValue,value);
        }


        [TestCase(499)]
        [TestCase(1001)]
        public void Change_Power_of_PowerTube_With_Exception(int value)
        {
            Assert.Throws<System.ArgumentOutOfRangeException>(() => uut.changePowerTubeValue(value));
        }


    }
}