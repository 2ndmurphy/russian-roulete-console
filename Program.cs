using System;

class RussianRoulette
{
    static readonly string[] players = ["Player One", "Player Two"];
    static readonly Random random = new();
    static bool[]? cylinder;
    static int currentChamberIndex = 0;

    static void Main()
    {
        Console.WriteLine("🎲 Welcome to Russian Roulette!");
        Console.WriteLine("One live round in the cylinder. Take turns and see who gets unlucky...\n");

        bool playing = true;

        while (playing)
        {
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

    static void StartGame()
    {
        currentChamberIndex = 0;
    }

    static void ShuffleCylinder()
    {
        cylinder = [true, false, false, false, false, false];
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
        int startIndex = random.Next(players.Length);
        string[] newOrder = new string[players.Length];

        for (int i = 0; i < players.Length; i++)
        {
            newOrder[i] = players[(startIndex + i) % players.Length];
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
