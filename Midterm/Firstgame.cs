using System;
using System.Collections.Generic;

// the whole idea and concept belong to the ai except codes of course i took help when i get stuck


class Firstgame
{
    private class Player
    {
        public string Name { get; set; }
        public Dictionary<string, string> Choices { get; set; }

        public Player()
        {
            Choices = new Dictionary<string, string>();
        }
    }

    private class GameLogic
    {
        private Player _player;
        private Random _random;

        public GameLogic()
        {
            _player = new Player();
            _random = new Random();
        }

        public void Introduction()
        {
            Console.WriteLine("Welcome to the Mysterious  Adventure!");
            Console.Write("What is your name, brave adventurer? ");
            _player.Name = CapitalizeName(Console.ReadLine());
            Console.WriteLine($"\nWelcome, {_player.Name}! Your adventure begins...");
        }

        private string CapitalizeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "Adventurer";
            return char.ToUpper(name[0]) + name.Substring(1).ToLower();
        }

        public void Questions()
        {
            _player.Choices["survival"] = Questions(
                $"\n{_player.Name}, you find yourself in a mysterious forest...",
                "What do you do first?",
                new[] { 
                    "A. Look for shelter", 
                    "B. Search for food", 
                    "C. Try to find a way out" 
                }
            );

            _player.Choices["encounter"] = Questions(
                "\nA mystical creature appears before you!",
                "How do you react?",
                new[] { 
                    "A. Try to realise", 
                    "B. Try to defend yourself to survive", 
                    "C. Attempt to run away" 
                }
            );

            _player.Choices["resources"] = Questions(
                "\nYou discover limited resources...",
                "What's your priority?",
                new[] { 
                    "A. Conserve energy", 
                    "B. Explore aggressively", 
                    "C. Carefully plan your next move" 
                }
            );

            _player.Choices["challenge"] = Questions(
                "\nA The moment has come when you must make an important decision....",
                "What's your move?",
                new[] { 
                    "A. Take a risk you're prepared for", 
                    "B. Choose the safest way", 
                    "C. Trust your instincts" 
                }
            );
        }

        private string Questions(string scenario, string prompt, string[] options)
        {
            Console.WriteLine(scenario);
            Console.WriteLine(prompt);
            
            foreach (var option in options)
            {
                Console.WriteLine(option);
            }

            while (true)
            {
                Console.Write("Enter your choice (A/B/C): ");
                string input = Console.ReadLine()?.ToUpper();

                if (input == "A" || input == "B" || input == "C")
                {
                    return input;
                }

                Console.WriteLine("Invalid input. Please enter A, B, or C.");
            }
        }

        public void AnalyzeResults()
        {
            string[] responses = {
                $"Wow, {_player.Name}! Your choices reveal a truly unique adventurer's spirit!",
                $"{_player.Name}, you've navigated this adventure with remarkable intuition!",
                $"The path you've chosen tells an incredible story, {_player.Name}!"
            };

            List<string> analysisDetails = new List<string>();

            analysisDetails.Add(_player.Choices["survival"] switch
            {
                "A" => "You prioritize safety and shelter - a wise survival strategy!",
                "B" => "Your focus on immediate needs shows practical thinking.",
                "C" => "You're driven by the desire to escape and find your way.",
                _ => "An unexpected choice emerges..."
            });

            analysisDetails.Add(_player.Choices["encounter"] switch
            {
                "A" => "Your diplomatic approach suggests you value understanding over conflict.",
                "B" => "A defensive stance reveals your preparedness and caution.",
                "C" => "Your instinct to flee shows self-preservation is key for you.",
                _ => "Your reaction defies typical expectations!"
            });

            Console.WriteLine("\n" + GetRandomResponse(responses));
            Console.WriteLine("\nAnalysis of your journey:");
            
            foreach (var detail in analysisDetails)
            {
                Console.WriteLine($"• {detail}");
            }
        }

        private string GetRandomResponse(string[] responses)
        {
            return responses[_random.Next(responses.Length)];
        }
    }

    static void Main()
    {
        GameLogic game = new GameLogic();
        
        try
        {
            game.Introduction();
            game.Questions();
            game.AnalyzeResults();

            Console.WriteLine("\nThank you for playing!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}