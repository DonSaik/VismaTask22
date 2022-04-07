using System;

namespace VismaTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Command command = Command.help;
            ICommandController controller = new CommandController();
            controller.ReadMeeting();
            while (command != Command.exit)
            {
                switch (command)
                {
                    case Command.help:
                        controller.DisplayCommands();
                        break;
                    case Command.createMeeting:
                        controller.CreateMeeting();
                        break;
                    case Command.outputMeetings:
                        controller.OutputMeeting();
                        break;
                    case Command.changeCurrentUser:
                        controller.ChangeUser();
                        break;
                    case Command.addPerson:
                        controller.AddPerson();
                        break;
                    case Command.deleteMeeting:
                        controller.DeleteMeeting();
                        break;
                    case Command.filterMeeting:
                        controller.FilterMeeting();
                        break;
                    default:
                        Console.WriteLine($"Commands {command} doesnt exist");
                        break;
                }
                try
                {
                    command = (Command)Enum.Parse(typeof(Command), Console.ReadLine());
                }
                catch (Exception  ex)
                {
                    command = Command.help;
                    Console.WriteLine("Please type numbers for command");
                }
            }
        }
    }
}


