using Warfare.Model;
using Warfare.Model.Enums;

namespace Warfare.Infrastructure
{
    public class SquadFactory
    {
        private SoldiersFactory _soldiersFactory;

        public SquadFactory() 
        { 
            _soldiersFactory = new SoldiersFactory();
        }

        public Squad Create(ConsoleColor teamColor, params SoldierType[] soldiers) 
        {
            var soldiersList = new List<Soldier>();

            foreach (var soldier in soldiers) 
            {
                soldiersList.Add(_soldiersFactory.Create(soldier));
            }

            return new Squad(soldiersList, teamColor);
        }
    }
}
