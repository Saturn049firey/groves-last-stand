using Godot;

public partial class HUD : CanvasLayer
{
	[Export] public ProgressBar HealthBar;
	[Export] public ProgressBar ManaBar;
	[Export] public Label SpellLabel;
	[Export] public ProgressBar FlowerHpBar;
	[Export] public Player Player;
	[Export] public Flower Flower;
	[Export] public Label WaveLabel;
	[Export] public WaveManager WaveManager;

	public override void _Process(double delta)
	{
		if (Player != null)
		{
			HealthBar.MaxValue = Player.MaxHealth;
			HealthBar.Value = Player.Health;

			ManaBar.MaxValue = Player.MaxMana;
			ManaBar.Value = Player.Mana;

			SpellLabel.Text = "Spell: " + Player.CurrentSpell;
		}

		if (Flower != null && FlowerHpBar != null)
		{
			FlowerHpBar.MaxValue = Flower.MaxHealth;
			FlowerHpBar.Value = Flower.Health;
		}

		if (WaveManager != null && WaveLabel != null)
		{
			//GD.Print("CurrentWave: " + WaveManager.CurrentWave);
			WaveLabel.Text = "Wave: " + WaveManager.CurrentWave;
		}
	}
}
