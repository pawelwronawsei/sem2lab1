//git -> create repo -> commit -> push
class Program
{
    public static void Main()
    {
        //Lab1 < data.txt
        var s1 = Console.ReadLine();
        var s2 = Console.ReadLine();

        if (int.TryParse(s1, out var arg1) && int.TryParse(s2, out var arg2))
        {
            Console.WriteLine(arg1 + arg2);
        }
        else
        {
            Console.WriteLine("Invalid format");
        }
    }
    
    public static void Main2(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Error invalid number of parameters.");
            return;
        }

        if (int.TryParse(args[0], out var arg1) && int.TryParse(args[1], out var arg2))
        {
            Console.WriteLine(arg1 + arg2);
        }
    }
}