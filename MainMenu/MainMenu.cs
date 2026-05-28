using Godot;

public partial class MainMenu : CanvasLayer
{
	[Export] public SpinBox FinalWaveSpinBox;

	public override void _Ready()
	{
		FinalWaveSpinBox.Value = 10;
		FinalWaveSpinBox.MinValue = 1;
		FinalWaveSpinBox.MaxValue = 99;
	}

	private void OnPlayButtonPressed()
	{
		GameData.FinalWave = (int)FinalWaveSpinBox.Value;
		GetTree().ChangeSceneToFile("res://Main.tscn");
	}

	private void OnQuitButtonPressed()
	{
		GetTree().Quit();
	}
}