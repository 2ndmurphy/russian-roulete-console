class RussianRoulette
{
    static readonly string[] Players = ["Player One", "Player Two"];
    static readonly Random random = new();
    static bool[]? cylinder;
    static int currentChamberIndex = 0;
    static int bulletsCount = 1; // default 1 peluru

    static void Main()
    {
        Console.WriteLine("🎲 Welcome to Russian Roulette!");
        Console.WriteLine("One or more live rounds in the cylinder. Take turns and see who gets unlucky...\n");

        bool playing = true;

        while (playing)
        {
            SetupGame(); // NEW: user pilih jumlah peluru
            StartGame();

            bool gameRunning = true;
            ShuffleCylinder();
            currentChamberIndex = random.Next(cylinder!.Length);

            string[] currentPlayers = ShufflePlayerOrder();

            Console.WriteLine($"🔄 Random start! {currentPlayers[0]} goes first.\n");

            while (gameRunning)
            {
                foreach (string player in currentPlayers)
                {
                    Console.Write($"{player}'s turn, press Enter to pull the trigger...");
                    Console.ReadLine();

                    bool gotShot = cylinder![currentChamberIndex];

                    if (gotShot)
                    {
                        Console.WriteLine($"💥 BOOM! {player} got shot.\n💀 Game over.");
                        gameRunning = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"😮 {player} got blank. You're lucky!");
                    }

                    currentChamberIndex++;

                    if (currentChamberIndex >= cylinder.Length)
                    {
                        Console.WriteLine("\n🔁 Cylinder is being reshuffled...\n");
                        ShuffleCylinder();
                        currentChamberIndex = random.Next(cylinder.Length);
                    }
                }
            }

            playing = AskToPlayAgain();
        }

        Console.WriteLine("\n👋 Thanks for playing!");
    }

    static void SetupGame()
    {
        Console.Write("💡 Enter number of bullets (1-5): ");
        while (true)
        {
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int num) && num >= 1 && num <= 5)
            {
                bulletsCount = num;
                double chanceOfGettingShot = (double)bulletsCount / 6.0 * 100;
                Console.WriteLine($"🎯 Chance of getting shot per turn: {chanceOfGettingShot:0.0}%\n");
                break;
            }
            Console.Write("❌ Invalid input. Enter number between 1 and 5: ");
        }
    }

    static void StartGame()
    {
        currentChamberIndex = 0;
    }

    static void ShuffleCylinder()
    {
        cylinder = new bool[6];

        for (int i = 0; i < bulletsCount; i++)
        {
            cylinder[i] = true;
        }

        ShuffleArray(cylinder);
    }

    static void ShuffleArray(bool[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            (array[i], array[j]) = (array[j], array[i]);
        }
    }

    static string[] ShufflePlayerOrder()
    {
        int startIndex = random.Next(Players.Length);
        string[] newOrder = new string[Players.Length];

        for (int i = 0; i < Players.Length; i++)
        {
            newOrder[i] = Players[(startIndex + i) % Players.Length];
        }

        return newOrder;
    }

    static bool AskToPlayAgain()
    {
        Console.Write("\n🔁 Do you want to play again? (yes/no): ");
        string? input = Console.ReadLine()?.Trim().ToLower();
        return input == "yes" || input == "y";
    }
}
