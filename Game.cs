public class Game
{

    private Game(int operation)
    {
        switch ((Options)operation)
        {
            case Options.Add:
                _operation = "+";
                break;
            case Options.Sub:
                _operation = "-";
                break;
            case Options.Multiply:
                _operation = "x";
                break;
            case Options.Divide:
                _operation = "/";
                break;

        }
    }
    public int Ans;
    public int Solution;
    private int _num1;
    private int _num2;
    private string? _operation;
    private static List<Game> _history = new List<Game>();

    public string Equation()
    {
        return $"{_num1} {_operation} {_num2} ";
    }
    public void Answer()
    {
        string? readLine;
        int answer;
        bool success;
        Console.WriteLine(Equation());
        do
        {
            Console.Write("answer : ");
            readLine = Console.ReadLine();
            success = int.TryParse(readLine, out answer);
        }
        while (!success);

        this.Ans = answer;
    }
    public void Solve()
    {
        switch (_operation)
        {
            case "+":
                Solution = _num1 + _num2;
                break;
            case "-":
                Solution = _num1 - _num2;
                break;
            case "x":
                Solution = _num1 * _num2;
                break;
            case "/":
                Solution = _num1 / _num2;
                break;

        }
    }
    public static Game NewGame(int operation)
    {
        Game game = new Game(operation);
        if (operation == (int)Options.Multiply || operation == (int)Options.Divide)
        {
            game._num1 = new Random().Next(1, 101);
            if (operation == (int)Options.Multiply)
            {
                game._num2 = new Random().Next(0, 101);
            }
            else
            {
                do
                {
                    game._num2 = new Random().Next(1, game._num1);
                } while (game._num1 % game._num2 != 0 || game._num2 == 0);
            }
        }
        else
        {
            //limits the highest number of num1 and num2 to prevent reallt large numbers
            game._num1 = new Random().Next(1000);
            game._num2 = new Random().Next(1000);
        }
        game.Solve();
        _history.Add(game);
        return game;
    }
    public static void ShowHistory()
    {
        Console.Clear();
        Console.WriteLine("Results:");
        Console.WriteLine("{0,-20} {1,-15} {2,-10} {3,-10}", "Equation", "Solution", "Answer", "Correct");

        // Print each row with fixed-width columns
        foreach (var game in Game._history)
        {
            string equation = game.Equation();
            string solution = game.Solution.ToString();
            string answer = game.Ans.ToString();
            string correct = (game.Solution == game.Ans).ToString();

            Console.WriteLine("{0,-20} {1,-15} {2,-10} {3,-10}", equation, solution, answer, correct);
        }

        Console.WriteLine("Press enter to continue");
        Console.ReadLine();
    }
}

