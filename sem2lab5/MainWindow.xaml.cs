using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sem2lab5;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private int _counter = 0;
    
    public MainWindow()
    {
        InitializeComponent();
        // foreach (var name in Enum.GetNames<LengthUnit>())
        // {
        //     ListBox.Items.Add(name);
        // }
        //uzupełnia listę
        TargetLengthUnit.ItemsSource = Enum.GetNames<LengthUnit>();
        SourceLengthUnit.ItemsSource = Enum.GetNames<LengthUnit>();
        // ListBox.Items.Add("MM");
        // ListBox.Items.Add("M");
        // ListBox.Items.Add("KM");
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        // Message.Text = $"Clicked {++_counter} times.";
        // Message.Content = $"Clicked {++_counter} times.";
        if (double.TryParse(Length.Text, out var parsed))
        {
            string unit = (string)TargetLengthUnit.SelectedItem;
            string unit2 = (string)SourceLengthUnit.SelectedItem;
            if (Enum.TryParse<LengthUnit>(unit, out var targetUnit))
            {
                if(Enum.TryParse<LengthUnit>(unit2, out var sourceUnit))
                {
                    Result.Content = $"{((decimal)parsed * targetUnit.ToDecimal()) / sourceUnit.ToDecimal()}";
                
                }
            }
        }
    }
}