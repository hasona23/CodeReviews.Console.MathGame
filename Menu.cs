enum Options{
    Add = 1,
    Sub = 2,
    Multiply = 3,
    Divide = 4,
    ShowHistory = 5,
    Exit = 6,
}
public static class Menu{
    public static void Start(){
        Console.WriteLine("==============================================");
        Console.WriteLine("=============Welcome to Math Game=============");
        Console.WriteLine("==============================================");
        Thread.Sleep(2 * 1000); //waits for 2 Seconds
    }

   /// <summary>
   /// Prints the Options menu and get the input
   /// </summary>
    public static int GetOptions(){
        Console.Clear();
        Console.WriteLine("Enter Option's Number:");
        Console.WriteLine("{1} ADD");
        Console.WriteLine("{2} Sub");
        Console.WriteLine("{3} Multiply");
        Console.WriteLine("{4} Divide");
        Console.WriteLine("{5} ShowHistory");
        Console.WriteLine("{6} Exit");
        return GetInput();
    }
    public static int GetInput(){
        string? Readline;
        int input = -1;
        do
        { 
             Console.Write("INPUT : ");
            Readline  =Console.ReadLine();
            int.TryParse(Readline,out input);
        }
        while(!Enum.IsDefined(typeof(Options),input));
        return input;
    }
}