using Warfare.Model.Enums;
using Warfare.Model.Interfaces;

namespace Warfare.Model
{
    public class Squad
    {
        private List<Soldier> _aliveSoldiers;

        public Squad(List<Soldier> soldiers, ConsoleColor teamColor) 
        { 
            _aliveSoldiers = soldiers;
            Team = teamColor;

            Awake(soldiers);
        }

        public IEnumerable<IDamageable> AliveSoldiers => _aliveSoldiers;
        public ConsoleColor Team { get; }

        public void Attack(IEnumerable<IDamageable> enemies) 
        {
            var availableTargets = enemies.ToArray();

            foreach (var soldier in _aliveSoldiers) 
            {
                soldier.Attack(availableTargets);
            }
        }

        private void OnSoldierDeath(Soldier deadSoldier)
        {
            deadSoldier.Died -= OnSoldierDeath;
            _aliveSoldiers.Remove(deadSoldier);

            Console.WriteLine($"Боец {deadSoldier.Type} из отряда {Team} погибает ");
        }

        private void OnDamageTaken(SoldierType type, int damage) 
        {
            Console.WriteLine($"Боец {type} из отряда {Team} получает {damage} урона");
        }

        private void Awake(List<Soldier> soldiers) 
        {
            foreach (var soldier in soldiers) 
            {
                soldier.Died += OnSoldierDeath;
                soldier.DamageTaken += OnDamageTaken;
            }
        }
    }
}
