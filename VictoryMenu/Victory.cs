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
		GetTree().Paused = false;
		GetTree().ChangeSceneToFile("res://MainMenu/main_menu.tscn");
	}

	private void OnQuitButtonPressed()
	{
		GD.Print("Quit");
		GetTree().Quit();
	}
}