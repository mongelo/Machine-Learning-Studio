using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Machine_Learning_Studio
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {

        private bool _showAlgorithmsPage;
        private bool _showDataSetsPage;
        private bool _showWikiPage;
        private bool _showStatsPage;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool ShowAlgorithmsPage
        {
            get => _showAlgorithmsPage;
            set{if (_showAlgorithmsPage != value) {_showAlgorithmsPage = value;OnPropertyChanged();}}
        }

        public bool ShowDataSetsPage
        {
            get => _showDataSetsPage;
            set { if (_showDataSetsPage != value) { _showDataSetsPage = value; OnPropertyChanged(); } }
        }

        public bool ShowWikiPage
        {
            get => _showWikiPage;
            set { if (_showWikiPage != value) { _showWikiPage = value; OnPropertyChanged(); } }
        }

        public bool ShowStatsPage
        {
            get => _showStatsPage;
            set { if (_showStatsPage != value) { _showStatsPage = value; OnPropertyChanged(); } }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;

            AlgorithmsButton.Command = new Command(ExecuteAlgorithmsButtonCommand);
            DataSetsButton.Command = new Command(ExecuteDataSetsButtonCommand);
            WikiButton.Command = new Command(ExecuteWikiButtonCommand);
            StatsButton.Command = new Command (ExecuteStatsButtonCommand);
        }

        //private void OnCounterClicked(object sender, EventArgs e)
        //{
        //    count++;

        //    if (count == 1)
        //        CounterBtn.Text = $"Clicked {count} time";
        //    else
        //        CounterBtn.Text = $"Clicked {count} times";

        //    SemanticScreenReader.Announce(CounterBtn.Text);
        //}

        private void HideAllPages() 
        {
            ShowAlgorithmsPage = false;
            ShowDataSetsPage = false;
            ShowWikiPage = false;
            ShowStatsPage = false;
            
        }

        private void ExecuteAlgorithmsButtonCommand()
        {
            HeaderLabel.Text = $"ALGORITHMS";
            HideAllPages();
            ShowAlgorithmsPage = true;
			Mediator.SendMessage("algorithms_activated");
		}

        private void ExecuteDataSetsButtonCommand()
        {
            HeaderLabel.Text = $"DATA SETS";
            HideAllPages();
            ShowDataSetsPage = true;
            Mediator.SendMessage("datasets_activated");
        }

        private void ExecuteWikiButtonCommand()
        {
            HeaderLabel.Text = $"WIKI";
            HideAllPages();
            ShowWikiPage = true;
        }

        private void ExecuteStatsButtonCommand()
        {
            HeaderLabel.Text = $"STATS";
            HideAllPages();
            ShowStatsPage = true;
        }
    }

}
