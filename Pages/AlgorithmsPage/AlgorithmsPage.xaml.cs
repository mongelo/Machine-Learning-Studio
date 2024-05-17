using System.Text.Json;
using Machine_Learning_Studio.Entities;
using Machine_Learning_Studio.Helpers;

namespace Machine_Learning_Studio.AlgorithmsPage;

public partial class AlgorithmsPage : ContentView
{
	private const string _algorithmsFolderName = "Algorithms";
	private List<AlgorithmsMetadata> _algorithmsMetadata = new List<AlgorithmsMetadata>();

	public AlgorithmsPage()
	{
		InitializeComponent();
		Mediator.MessageReceived += OnMessageReceived;
	}

	private void OnMessageReceived(object? sender, string message)
	{
		if (message == "algorithms_activated")
		{
			ActivatePage();
			Console.WriteLine("AlgorithmsPage initialized");
		}
	}

	public void ActivatePage()
	{
		LoadAlgorithmsMetadata();
		BindAlgorithmsToView();
	}

	private void BindAlgorithmsToView()
	{
		algorithmsMetadataList.ItemsSource = _algorithmsMetadata;
	}

	private void LoadAlgorithmsMetadata()
	{
		var projectFolder = FileHelper.GetProjectFolder();
		var directoryPath = Path.Combine(projectFolder, _algorithmsFolderName);
		var algorithmsDirectories = Directory.GetDirectories(directoryPath);

		foreach (var directory in algorithmsDirectories)
		{
			var jsonData = FileHelper.ReadJsonFromFile(directory + "\\algorithmMetadata.json");
			var algorithm = JsonSerializer.Deserialize<AlgorithmsMetadata>(jsonData);
			if (algorithm != null) _algorithmsMetadata.Add(algorithm);
		}
	}
}