using System.Reflection;

class Program
{
    public static void Main(string[] args)
    {
        IList<string> names = new List<string>() { "Ewa", "Adam", "Karol" };
        names.Add("Robert");
        names.Remove("Ewa");
        names.RemoveAt(0);
        names[0] = "Ewa";
        Console.WriteLine(string.Join(", ", names));
        
        // ZAMIANA OSTATNIEGO Z PIERWSZYM
        (names[0], names[names.Count - 1]) = (names[names.Count - 1], names[0]);
        Console.WriteLine(string.Join(", ", names));
        
        names.Add("Beata");
        Console.WriteLine(string.Join(", ", names));
        
        // OSTATNI IDZIE NA POCZĄTEK
        names.Insert(0, names.Last());
        names.RemoveAt(names.Count - 1);
        Console.WriteLine(string.Join(", ", names));

        // LINKEDLIST
        string[] arr = { "b", "a", "c" };
        LinkedList<string> linked = new LinkedList<string>(arr);
        var first = linked.First;
        Console.WriteLine(first.Value);
        
        // DODANIE NOWEGO ELEMENTU ZA PIERWSZYM
        linked.AddAfter(first, new LinkedListNode<string>("z"));
        Console.WriteLine(string.Join(", ", linked));

        // ZADANIE Z PLAYERS
        
        var players = new List<Player>()
        {
            new Player(){ Id = 1, Name = "Adam", Points = 123 },
            new Player(){ Id = 2, Name = "Karol", Points = 30 },
            new Player(){ Id = 3, Name = "Ania", Points = 330 },
            new Player(){ Id = 3, Name = "Ania", Points = 330 },
        };
        
        // TRZEBA DODAĆ EQUALS ABY TO DZIAŁAŁO (LUPA -> GEN CODE -> EQUALITY MEMBERS)
        Console.WriteLine(players.IndexOf(new Player(){ Id = 1 }));
        
        // wyświetl graczy z imieniem zaczynającym się na literę a
        players.ForEach(player =>
        {
            if(player.Name.ToLower()[0] == 'a') Console.WriteLine(player.Name);
        });
        
        // UŻYCIE SET
        ISet<Player> room = new HashSet<Player>(players);
        room.Add(new Player() { Id = 4, Name = "Paweł", Points = 100 });
        Console.WriteLine(string.Join(", ", room));
        Console.WriteLine(room.Contains(new Player() { Id = 5 }));
        ISet<Player> team = new HashSet<Player>();
        team.Add(players[1]);
        team.Add(new Player() { Id = 6, Name = "Stefan", Points = 12 });
        
        // CZĘŚĆ WSPÓLNA ROOM I TEAM
        var intersect = new HashSet<Player>(room); // kopiowanie zbioru
        intersect.IntersectWith(team);
        Console.WriteLine(string.Join(", ", intersect));
        
        // ALFABETYCZNIE
        ISet<string> sortedNames = new SortedSet<string>(names);
        sortedNames.Add("Alicja");
        Console.WriteLine(string.Join(", ", sortedNames));
        ISet<Player> sortedPlayers = new SortedSet<Player>(players);
        Console.WriteLine(string.Join(", ", sortedPlayers));
        IDictionary<string, Player> playersDictionary = new Dictionary<string, Player>();
        playersDictionary.Add("adam@wsei.edu.pl", players[0]);
        playersDictionary.Add("karol@wsei.edu.pl", players[1]);
        playersDictionary.Add("ania@wsei.edu.pl", players[2]);
        Console.WriteLine(string.Join(", ", playersDictionary));
        Console.WriteLine(playersDictionary["ania@wsei.edu.pl"]);
        
        // dodaj 10 punktów graczowi o adresie ania@wsei.edu.pl
        var playerToChange = playersDictionary["ania@wsei.edu.pl"];
        playerToChange = new Player()
        {
            Id = playerToChange.Id,
            Name = playerToChange.Name,
            Points = playerToChange.Points + 10
        };
        playersDictionary["ania@wsei.edu.pl"] = playerToChange;
    }

    class Player : IComparer<Player>, IComparable<Player>
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public int Points { get; init; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Points)}: {Points}";
        }

        protected bool Equals(Player other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Player)obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public int Compare(Player x, Player y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (ReferenceEquals(null, y)) return 1;
            if (ReferenceEquals(null, x)) return -1;
            return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
        }

        public int CompareTo(Player? other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return string.Compare(Name, other.Name, StringComparison.Ordinal);
        }
    } 
}

