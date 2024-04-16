using System.Collections;
using System.Text;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sem2lab6;

public partial class Customer
{
    public string Address { get; set; }
}

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        Customer customer = new Customer()
        {
            Address = "Św. Filipa 17";
            Name = "";
        };

        for (var i = 1; i <= team.Length; i++)
        {
            Button button = new Button()
            {
                Content = team[i]
            };
            Panel.Children.Add(button);
        }
        
        // for (var enumerator = team.GetEnumerator(); enumerator.MoveNext();)
        // {
        //     var member = enumerator.Current;
        // }
        //
        // foreach (var member in team)
        // {
        //     Button button = new Button()
        //     {
        //         Content = member
        //     };
        //     Panel.Children.Add(button);
        // }

        Info.Content = team[1];
    }
}

class Team : IEnumerable<string>
{
    public string Lead { get; set; }
    public string? Architect { get; set; }
    public string[] Testers { get; set; }
    public string[] Developers { get; set; }

    public int Length
    {
        get
        {
            return (1 + (Architect is null ? 0 : 1) + Testers.Length + Developers.Length);
        }
    }

    public string this[int i]
    {
        get
        {
            switch(i)
            {
               case 1: return Lead;
               case 2: return Architect;
               default:
                   if (i > 2 && i <= Testers.Length + 2)
                   {
                       return Testers[i - 2];
                   }else if (i > 2 + Testers.Length && i <= Developers.Length + Testers.Length + 2)
                   {
                       return Developers[i - 3 - Testers.Length];
                   }
                   throw new IndexOutOfRangeException();
            }
        }
        set
        {
            
        }
    }

    public class TeamEnumerator : IEnumerator<string>
    {
        private string[] _items;

        public TeamEnumerator(Team team)
        {
            int size = 1 + team.Testers.Length + team.Developers.Length + (team.Architect == null ? 1 : 0);
            _items = new string[size];
            _items[0] = team.Lead;
            if (team.Architect == null)
            {
                for (int i = 0; i < team.Testers.Length; i++)
                {
                    _items[i + 1] = team.Testers[i];
                }
                for (int i = 0; i < team.Testers.Length; i++)
                {
                    _items[i + 1 + team.Testers.Length] = team.Developers[i];
                }
            }
            else
            {
                _items[1] = team.Architect;
                for (int i = 0; i < team.Testers.Length; i++)
                {
                    _items[i + 2] = team.Testers[i];
                }
                for (int i = 0; i < team.Developers.Length; i++)
                {
                    _items[i + 2 + team.Testers.Length] = team.Developers[i];
                }
            }
        }

        private int _index = -1;
        
        public bool MoveNext()
        {
            return ++_index < _items.Length;
        }

        public void Reset()
        {
            _index = -1;
        }

        public string Current
        {
            get
            {
                return _items[_index];
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }
    } 
    public IEnumerator<string> GetEnumerator()
    {
        // return new TeamEnumerator(this);
        yield return Lead;
        if (Architect != null)
        {
            yield return Architect;
        }

        foreach (var tester in Testers)
        {
            yield return tester;
        }

        foreach (var dev in Developers)
        {
            yield return dev;
        }
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}