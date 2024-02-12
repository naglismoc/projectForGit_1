using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectForGit
{
    internal class Item
    {
        public static int IdCounter = 0;

        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public bool isEco { get; set; }

        public Item()
        {
            this.Id = ++IdCounter;
        }
        public Item(bool real)
        {
            if (real)
            {
                this.Id = ++IdCounter;
            }
        }
        public Item(string title, string description, double price, bool isEco)
        {
            this.title = title;
            this.description = description;
            this.price = price;
            this.isEco = isEco;
            this.Id = ++IdCounter;
        }

        public override string? ToString()
        {
            return $"{Id}. Item : {title}, {description}, {price}, preke yra "
                + ((isEco) ? "ekologiska " : "neekologiska");
        }

        public static void printItems()
        {
            Console.WriteLine();
            foreach (var item in Program.shop)
            {
                Console.WriteLine(item);
            }
        }

        public static void addNewItem()
        {
            Item itm = new Item();
            Console.WriteLine();
            Console.WriteLine("Iveskite prekes pavadinima");
            itm.title = Console.ReadLine();
            Console.WriteLine("Iveskite prekes aprasym1");
            itm.description = Console.ReadLine();
            Console.WriteLine("Iveskite prekes kaina");
            while (true)
            {
                try
                {
                    itm.price = Convert.ToDouble(Console.ReadLine());
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Įveskite teisingą kainą. formatas 20,22");
                }
            }
            Console.WriteLine("Iveskite ar prekė ekologiška");

            while (true)
            {
                try
                {
                    itm.isEco = Convert.ToBoolean(Console.ReadLine());
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Įveskite reikšmes 'true' arba 'false'");
                }
            }
            Program.shop.Add(itm);
        }

        public static void updateItem()
        {
            int itemId = 0;
            // string inputS = Console.ReadLine().ToLower();
            string inputS;
            Console.WriteLine("Įveskites prekės Id kurią norite redaguoti");
            itemId = ValidateInput.Int();
            itemId = ValidateInput.Int();
            Item i = getItem(itemId) ?? new(false);
            Item ni = new(false);

            Console.WriteLine($"Iveskite prekes pavadinima.(dabartinis: {i.title}) ");
            ni.title = ValidateInput.StringLen(3, 255);
            Console.WriteLine($"Iveskite prekes aprasyma.(dabartinis: {i.description}) ");
            ni.description = ValidateInput.StringLen(3, 65025);
            Console.WriteLine($"Iveskite prekes kaina.(dabartinis: {i.price}) ");
            ni.price = ValidateInput.Double();
            Console.WriteLine($"Iveskite ar prekė ekologiška.(dabartinis: {i.isEco}) ");
            ni.isEco = ValidateInput.Bool();
            Console.WriteLine(ni);
            while (true)
            {
                Console.WriteLine("ar norite issaugoti pakeitimus? Taip/Ne");
                string input = Console.ReadLine().Trim().ToLower();
                if (input.Equals("ne"))
                {
                    return;
                }
                if (input.Equals("taip"))
                {
                    break;
                }
            }
            ni.Id = i.Id;
            for (int a = 0; a < Program.shop.Count; a++)
            {
                if (Program.shop[a].Id == itemId)
                {
                    Program.shop[a] = ni;
                    break;
                }
            }

        }

        public static Item getItem(int itemId)
        {
            foreach (var item in Program.shop)
            {
                if (item.Id == itemId)
                {
                    return item;
                }
            }
            return null;
        }

        public static void deleteItem()
        {
            Console.WriteLine("Įveskites prekės Id kurią norite trinti.");
            int itemId = ValidateInput.Int();
            bool removed = false;
            foreach (var item in Program.shop)
            {
                if (item.Id == itemId)
                {
                    string title = item.title;
                    removed = Program.shop.Remove(item);
                    Console.WriteLine($"prekė {title} sėkmingai ištrinta");
                    break;
                }
            }
            if (!removed)
            {
                Console.WriteLine("prekė nerasta");
            }
        }

        public static void seedItems()
        {
            Program.shop.Add(new Item("sokoladas", "skanus tikrai", 46.89, true));
            Program.shop.Add(new Item("braske", "veganiska", 46.89, false));
        }
    }
}
