namespace sem2lab6;

public partial class MainWindow
{
    public void GenerateButtons(StackPanel panel)
    {
        var team = new Team()
        {
            Lead = "Adam", 
            Architect = "Ewa", 
            Testers = new[] { "Karol", "Adrian" },
            Developers = new[] { "Jan", "Grzegorz" }
        };
        
    }
}