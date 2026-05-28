using Godot;

public partial class Victory : CanvasLayer
{
	public override void _Ready()
	{
		Visible = false;
	}

	public void ShowVictory()
	{
		Visible = true;
		Input.SetMouseMode(Input.MouseModeEnum.Visible);
		GetTree().Paused = true;
	}

	private void OnPlayAgainButtonPressed()
	{
		GD.Print("Play again");
		GetTree().Paused = false;
		Input.SetMouseMode(Input.MouseModeEnum.Captured);
		GetTree().ChangeSceneToFile("res://MainMenu.tscn");
	}

	private void OnQuitButtonPressed()
	{
		GD.Print("Quit");
		GetTree().Quit();
	}
}