using Godot;
using System;

public partial class GameOver : CanvasLayer
{
	public override void _Ready()
	{
		// Na začátku bude skrytý
		Visible = false;
	}

	public void ShowGameOver()
	{
		// Zobraz UI
		Visible = true;

		// Uvolní myš
		Input.MouseMode = Input.MouseModeEnum.Visible;

		// Pauzne hru
		GetTree().Paused = true;
	}

	private void OnRestartButtonPressed()
	{
		GD.Print("Restart");
		// Odpauzne hru
		GetTree().Paused = false;

		// Chytí myš zpátky
		Input.MouseMode = Input.MouseModeEnum.Captured;

		// Restartuje scénu
		GetTree().ReloadCurrentScene();
	}

	private void OnQuitButtonPressed()
	{
		GD.Print("Quit");
		GetTree().Quit();
	}
}