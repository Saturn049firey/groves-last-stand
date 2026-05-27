using Godot;

public partial class MainMenu : Control
{
	[Export] public SpinBox FinalWaveSpinBox;

	public override void _Ready()
	{
		// Výchozí hodnota finální vlny
		FinalWaveSpinBox.Value = 10;
		FinalWaveSpinBox.MinValue = 1;
		FinalWaveSpinBox.MaxValue = 99;
	}

	private void OnPlayButtonPressed()
	{
		// Uložíme finální vlnu do globální proměnné
		GameData.FinalWave = (int)FinalWaveSpinBox.Value;

		// Načteme herní scénu
		GetTree().ChangeSceneToFile("res://Main.tscn");
	}

	private void OnQuitButtonPressed()
	{
		GetTree().Quit();
	}
}