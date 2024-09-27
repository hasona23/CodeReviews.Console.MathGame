namespace MathGame.hasona23;
public class Program{
    public static void Main(string[] args)
    {
        Menu.Start();
        while(true){
            int input  = Menu.GetOptions();
            //since exit is always the last options
            if (input == (int)Options.Exit)
            {
                break;
            }
            //ShowHistory
            if (input == 5)
            {
                Game.ShowHistory();
                continue;
            }
            Game game = Game.NewGame(input);
            game.Answer();
            if (game.Ans != game.Solution){
                Console.WriteLine($"Wrong Answer. Solution is:{game.Solution}");
                
            } else{
                Console.WriteLine("Good Job !");
            }
            Console.WriteLine("Press Enter To continue");
            Console.ReadLine();

        }
    }
}