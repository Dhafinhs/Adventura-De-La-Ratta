namespace AdventuraDeLaRatta
{
    public class Enemy
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }

        public Enemy(string name, int level)
        {
            Name = name;
            Health = 50 + (level * 10);
            AttackPower = 5 + (level * 2);
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
        }
    }
}
