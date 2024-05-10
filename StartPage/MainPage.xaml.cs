using System.Windows.Input;

namespace Machine_Learning_Studio
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        public ICommand Button1Command { get; }
        public ICommand Button2Command { get; }

        public MainPage()
        {
            InitializeComponent();
            Button1Command = new Command(ExecuteButton1Command);
            Button2Command = new Command(ExecuteButton2Command);
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void ExecuteButton1Command()
        {
            Console.WriteLine("Button 1 clicked");
            CounterBtn.Text = $"Clime";
        }

        private void ExecuteButton2Command()
        {
            Console.WriteLine("Button 2 clicked");
            CounterBtn.Text = $"Clime";
        }
    }

}
