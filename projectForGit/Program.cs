namespace projectForGit;

internal class Program
{
    public static List<Item> shop = new List<Item>();
    public static int itemId = 0;
    static void Main(string[] args)
    {
        Item.seedItems();
        while (true)
        {
            printOptions();

            int input = ValidateInput.Int();

            switch (input)
            {
                case 1:
                    Item.printItems();
                    break;
                case 2:
                    Item.addNewItem();
                    break;
                case 3:
                    Item.updateItem();
                    break;
                case 4:
                    Item.deleteItem();
                    break;
                case 5:
                    quitProgram();
                    break;
            }
        }
    }


    public static void quitProgram()
    {
        Console.WriteLine("iseinu");
        Environment.Exit(0);
    }

    public static bool back()
    {
        Console.WriteLine("Jei norite sugrizti iveskite back, jei norite testi spauskite enter");
        if (Console.ReadLine().ToLower().Equals("back"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void printOptions()
    {
        Console.WriteLine("-----------------------");
        Console.WriteLine("1. pamatyti prekes");
        Console.WriteLine("2. prideti preke");
        Console.WriteLine("3. redaguoti preke");
        Console.WriteLine("4. istrinti preke");
        Console.WriteLine("5. iseiti is programos");
        Console.WriteLine("-----------------------");
    }
}
