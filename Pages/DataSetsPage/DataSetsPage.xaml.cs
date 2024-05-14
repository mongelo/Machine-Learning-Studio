using Machine_Learning_Studio.Entities;
using Machine_Learning_Studio.Helpers;
using System.Linq;
using System.Text.Json;

namespace Machine_Learning_Studio.DataSetsPage;

public partial class DataSetsPage : ContentView
{
    private const string _datasetFolderName = "Datasets";
    private List<Dataset> _datasets = new List<Dataset>();

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
        LoadDatasetMetadata();
        BindDatasetsToView();
    }

    private void BindDatasetsToView()
    {
        dataSetsMetadataList.ItemsSource = _datasets;
    }

    private void LoadDatasetMetadata() 
    {
        var projectFolder = FileHelper.GetProjectFolder();
        var directoryPath = Path.Combine(projectFolder, _datasetFolderName);
        var datasetDirectories = Directory.GetDirectories(directoryPath);

        foreach (var directory in datasetDirectories)
        {
            var jsonData = FileHelper.ReadJsonFromFile(directory+"\\datasetMetadata.json");
            var dataset = JsonSerializer.Deserialize<Dataset>(jsonData);
            if(dataset!=null) _datasets.Add(dataset);
        }
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