using Machine_Learning_Studio.Helpers;
using System.Linq;

namespace Machine_Learning_Studio.DataSetsPage;

public partial class DataSetsPage : ContentView
{
    private const string _datasetFolderName = "Datasets";  

	public DataSetsPage()
	{
		InitializeComponent();
        Mediator.MessageReceived += OnMessageReceived;
    }

    private void OnMessageReceived(object? sender, string message)
    {
        if (message == "datasets_activated")
        {
            ActivatePage();
        }
    }

    public void ActivatePage()
	{
        var listOfAllDataSetNames = GetAllDatasetNames();
        Haha.Text = listOfAllDataSetNames.First();
	}

    public IEnumerable<string> GetAllDatasetNames()
    {
        var projectFolder = FileHelper.GetProjectFolder();
        var directoryPath = Path.Combine(projectFolder, _datasetFolderName);
        var datasetNames = Directory.GetDirectories(directoryPath);
        var trimmedDatasetNames = new List<string>();
        datasetNames.ToList().ForEach(path => trimmedDatasetNames.Add(path.Replace(directoryPath+"\\", "")));

        return trimmedDatasetNames;
    }

}