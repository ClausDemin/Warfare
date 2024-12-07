using Warfare.Infrastructure;
using Warfare.Model.Enums;

namespace Warfare
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            SquadFactory factory = new SquadFactory();

            var squad1 = factory.Create(ConsoleColor.Red, SoldierType.Conscript, SoldierType.Conscript, SoldierType.Machinegunner, SoldierType.Stormtrooper, SoldierType.Marksman);
            var squad2 = factory.Create(ConsoleColor.Blue, SoldierType.Conscript, SoldierType.Marksman, SoldierType.Machinegunner, SoldierType.Stormtrooper, SoldierType.Marksman);

            while (squad1.AliveSoldiers.Count() > 0 && squad2.AliveSoldiers.Count() > 0) 
            {
                squad1.Attack(squad2.AliveSoldiers);
                Console.WriteLine();
                squad2.Attack(squad1.AliveSoldiers);
                Console.WriteLine();
            }

            if (squad1.AliveSoldiers.Count() == 0)
            {
                Console.WriteLine($"Команда {squad2.Team} победила");
            }
            else 
            {
                Console.WriteLine($"Команда {squad1.Team} победила");
            }
        }
    }
}
