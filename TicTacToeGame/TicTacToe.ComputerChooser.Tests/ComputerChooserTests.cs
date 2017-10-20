namespace TicTacToe.ComputerChooser.Tests
{
    using Computer;
    using ComputerMinMax;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Computer.Interfaces;

    [TestClass]
    public class ComputerChooserTests
    {
        [TestMethod]
        public void ComputerChooser_Should_Instantiate_MyComputer_If_The_Username_Is_computer_at_yahoo_dot_com()
        {
            ComputerChooser chooser = new ComputerChooser(new Computer(), new MinMaxComputer());

            IComputer computer = chooser.GetComputerByName("computer@yahoo.com");

            Assert.IsTrue(computer is Computer);
        }

        [TestMethod]
        public void ComputerChooser_Should_Instantiate_MinMax_Computer_If_The_Computer_Name_Is_Not_computer_at_yahoo_dot_com()
        {
            ComputerChooser chooser = new ComputerChooser(new Computer(), new MinMaxComputer());

            IComputer computer = chooser.GetComputerByName("other-computer@yahoo.com");

            Assert.IsTrue(computer is MinMaxComputer);
        }
    }
}