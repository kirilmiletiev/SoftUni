using System;
using System.Linq;
using System.Text;


class Program
{
    public static SoldiersManager manager;
    public static StringBuilder stat;
    static void Main(string[] args)
    {
        manager = new SoldiersManager();
        stat = new StringBuilder();


        manager = new SoldiersManager();
        stat = new StringBuilder();


        var command = Console.ReadLine().Split();

        while (command[0] != "End")
        {
            ExecuteCommand(command);
            command = Console.ReadLine().Split();
        }

        Console.WriteLine(stat.ToString().Trim());
    }

    private static void ExecuteCommand(string[] command)
    {
        var id = command[1];
        var firstName = command[2];
        var lastName = command[3];
        double salary;
        string corps;
        string cmdResult;

        try
        {
            switch (command[0])
            {
                case "Private": // “Private <id> <firstName> <lastName> <salary>”
                    salary = double.Parse(command[4]);
                    cmdResult = manager.RegisterPrivate(id, firstName, lastName, salary);
                    stat.AppendLine(cmdResult);
                    break;
                case "LeutenantGeneral": // “LeutenantGeneral <id> <firstName> <lastName> <salary> <private1Id> <private2Id> … <privateNId>”
                    salary = double.Parse(command[4]);
                    cmdResult = manager.RegisterLeutenantGeneral(id, firstName, lastName, salary, command.Skip(5));
                    stat.AppendLine(cmdResult);
                    break;
                case "Engineer": // “Engineer <id> <firstName> <lastName> <salary> <corps> <repair1Part> <repair1Hours> … <repairNPart> <repairNHours>” 
                    salary = double.Parse(command[4]);
                    corps = command[5];
                    cmdResult = manager.RegisterEngineer(id, firstName, lastName, salary, corps, command.Skip(6).ToArray());
                    stat.AppendLine(cmdResult);
                    break;
                case "Commando": // “Commando <id> <firstName> <lastName> <salary> <corps> <mission1CodeName>  <mission1state> … <missionNCodeName> <missionNstate>”
                    salary = double.Parse(command[4]);
                    corps = command[5];
                    cmdResult = manager.RegisterCommando(id, firstName, lastName, salary, corps, command.Skip(6).ToArray());
                    stat.AppendLine(cmdResult);
                    break;
                case "Spy": // “Spy <id> <firstName> <lastName> <codeNumber>”
                    var codeNumber = int.Parse(command[4]);
                    cmdResult = manager.RegisterSpy(id, firstName, lastName, codeNumber);
                    stat.AppendLine(cmdResult);
                    break;
                default:
                    break;
            }
        }
        catch (ArgumentException)
        {
            return;
        }
    }
}
