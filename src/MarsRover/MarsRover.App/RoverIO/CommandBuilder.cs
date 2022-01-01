using System.Text;

namespace MarsRover.App.RoverIO
{
    internal class CommandBuilder
    {
        private StringBuilder commands;

        public CommandBuilder()
        {
            commands = new StringBuilder();
        }

        public CommandBuilder AddMoveForward()
        {
            commands.Append('F');
            return this;
        }

        public CommandBuilder AddMoveBackward()
        {
            commands.Append('B');
            return this;
        }

        public CommandBuilder AddTurnLeft()
        {
            commands.Append('L');
            return this;
        }

        public CommandBuilder AddTurnRight()
        {
            commands.Append('R');
            return this;
        }

        public string Build()
        {
            return commands.ToString();
        }
    }
}