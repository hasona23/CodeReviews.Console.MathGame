public class Game {

    private Game(int operation){
                switch ((Options)operation){
            case Options.Add :
            Operation = "+";
            break;
            case Options.Sub :
            Operation = "-";
             break;
            case Options.Multiply :
            Operation = "x";
             break;
            case Options.Divide :
            Operation = "/";
             break;
          
        }
    }
    public int Ans;
    public int Solution;
    public int Num1;
    public int Num2;
    public string? Operation;
    public static List<Game> History = new List<Game>();
    
    public string Equation(){
        return  $"{Num1} {Operation} {Num2} ";
    }
    public void Answer(){
      
        string? Readline;
       int answer ;
       bool success;
       Console.WriteLine(Equation());
        do
        { 
            Console.Write("answer : ");
            Readline  =Console.ReadLine();
            success = int.TryParse(Readline,out answer);
        }
        while(!success);

       this.Ans = answer;
    }
    public void Solve(){
        switch (Operation) {
            case "+":
            Solution= Num1 + Num2;
            break;
            case "-":
            Solution  = Num1 - Num2;
            break;
            case "x":
           Solution =  Num1*Num2;
           break;
            case "/":
            Solution= Num1/Num2;
            break;
          
        }
    }
    public static Game NewGame(int operation){
        Game game = new Game(operation);
        //special case of division to limit numbers to 100 and prevent decimals
        if (operation == (int)Options.Multiply || operation == (int)Options.Divide){
            game.Num1 = new Random().Next(1,101);
            if (operation == (int)Options.Multiply)
            {
                game.Num2 = new Random().Next(0,101);
            }
            else{
            do
            {
                game.Num2 = new Random().Next(1,game.Num1);
            }while(game.Num1 % game.Num2 != 0 || game.Num2 == 0);
            }
        } else{
            //limits the highest number of num1 and num2 to prevent reallt large numbers
            game.Num1  = new Random().Next(1000);
            game.Num2 = new Random().Next(1000);
        }
        game.Solve();
        History.Add(game);
        return game;
    }
    public static void ShowHistory(){
        Console.Clear();
        Console.WriteLine("Results:");

        // Print the header with specific column width using composite formatting
        Console.WriteLine("{0,-20} {1,-15} {2,-10} {3,-10}", "Equation", "Solution", "Answer", "Correct");

        // Print each row with fixed-width columns
        foreach (var game in Game.History)
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

