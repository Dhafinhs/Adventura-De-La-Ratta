namespace AdventuraDeLaRatta
{
    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; } = 100;
        public int Level { get; private set; } = 1;
        public int AttackPower { get; set; } = 10;
        public int Potions { get; set; } = 3;

        public Player(string name)
        {
            Name = name;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
        }

        public void Heal()
        {
            if (Potions > 0)
            {
                Health += 30;
                Potions--;
                Console.WriteLine($"{Name} menggunakan potion! Health bertambah menjadi {Health}");
            }
            else
            {
                Console.WriteLine("Potion Anda habis!");
            }
        }

        public void LevelUp()
        {
            Level++;
            AttackPower += 5;
            Health += 20;
            Console.WriteLine($"{Name} naik level! Sekarang level {Level}, Attack Power {AttackPower}, Health {Health}");
        }
    }
}
