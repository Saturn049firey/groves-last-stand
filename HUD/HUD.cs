using Godot;

public partial class HUD : CanvasLayer
{
	[Export] public ProgressBar HealthBar;
	[Export] public ProgressBar ManaBar;
	[Export] public Label SpellLabel;
	[Export] public Player Player;

	public override void _Process(double delta)
	{
		if (Player == null) return;

		HealthBar.MaxValue = Player.MaxHealth;
		HealthBar.Value = Player.Health;

		ManaBar.MaxValue = Player.MaxMana;
		ManaBar.Value = Player.Mana;

		SpellLabel.Text = "Spell: " + Player.CurrentSpell;
	}
}
