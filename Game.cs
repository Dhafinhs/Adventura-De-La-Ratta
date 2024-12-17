using System;

namespace AdventuraDeLaRatta
{
    public class Game
    {
        private Player player;
        private Random rand = new Random();

        public void Start()
        {
            Console.WriteLine("Selamat Datang di Adventura De La Ratta!");
            Console.Write("Masukkan nama tikus Anda: ");
            string name = Console.ReadLine();
            player = new Player(name);

            Console.WriteLine($"\nPetualangan {player.Name} dimulai...\n");
            MainLoop();
        }

        private void MainLoop()
        {
            while (player.Health > 0)
            {
                Console.WriteLine("\nAksi Anda: 'forward', 'status', 'quit'");
                string action = Console.ReadLine().ToLower();

                switch (action)
                {
                    case "forward":
                        Explore();
                        break;
                    case "status":
                        ShowStatus();
                        break;
                    case "quit":
                        Console.WriteLine("Petualangan berakhir. Sampai jumpa lagi!");
                        return;
                    default:
                        Console.WriteLine("Perintah tidak dikenal.");
                        break;
                }
            }

            Console.WriteLine("Game Over. Tikus Anda mati!");
        }

        private void Explore()
        {
            int eventChance = rand.Next(1, 4);

            if (eventChance == 1)
            {
                Console.WriteLine("\nAnda menemukan makanan! Health bertambah 20.");
                player.Health += 20;
            }
            else if (eventChance == 2)
            {
                Console.WriteLine("\nAnda menemukan Health Potion!");
                player.Potions++;
            }
            else
            {
                StartBattle();
            }
        }

        private void StartBattle()
        {
            Enemy enemy = new Enemy("Kucing Liar", player.Level);
            Console.WriteLine($"\nMusuh muncul: {enemy.Name} | Health: {enemy.Health}, Attack: {enemy.AttackPower}");

            while (enemy.Health > 0 && player.Health > 0)
            {
                Console.WriteLine("\nPilih aksi: 'attack', 'potion', 'run'");
                string action = Console.ReadLine().ToLower();

                switch (action)
                {
                    case "attack":
                        int playerDamage = rand.Next(player.AttackPower - 3, player.AttackPower + 3);
                        enemy.TakeDamage(playerDamage);
                        Console.WriteLine($"Anda menyerang {enemy.Name} dan memberikan {playerDamage} damage.");

                        if (enemy.Health > 0)
                        {
                            int enemyDamage = rand.Next(enemy.AttackPower - 2, enemy.AttackPower + 2);
                            player.TakeDamage(enemyDamage);
                            Console.WriteLine($"{enemy.Name} menyerang Anda dan memberikan {enemyDamage} damage.");
                        }
                        break;

                    case "potion":
                        player.Heal();
                        break;

                    case "run":
                        Console.WriteLine("Anda melarikan diri dari pertarungan.");
                        return;

                    default:
                        Console.WriteLine("Aksi tidak dikenal.");
                        break;
                }

                Console.WriteLine($"Health Anda: {player.Health} | Health Musuh: {enemy.Health}");
            }

            if (player.Health <= 0)
            {
                Console.WriteLine("Anda kalah dalam pertarungan...");
            }
            else if (enemy.Health <= 0)
            {
                Console.WriteLine($"Anda mengalahkan {enemy.Name}!");
                player.LevelUp();
            }
        }

        private void ShowStatus()
        {
            Console.WriteLine($"\nStatus {player.Name}:");
            Console.WriteLine($"Health: {player.Health}");
            Console.WriteLine($"Level: {player.Level}");
            Console.WriteLine($"Attack Power: {player.AttackPower}");
            Console.WriteLine($"Health Potions: {player.Potions}");
        }
    }
}
