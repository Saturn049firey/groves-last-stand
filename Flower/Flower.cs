using Godot;

public partial class Flower : StaticBody3D
{
    [Export] public float MaxHealth = 100f;
	public float Health => _health;
    private float _health;

    public override void _Ready()
    {
        _health = MaxHealth;
        AddToGroup("flower");
    }

    public void TakeDamage(float amount)
    {
        _health -= amount;
        _health = Mathf.Max(_health, 0);
        GD.Print("Flower HP: " + _health);

        if (_health <= 0)
        {
            GD.Print("GAME OVER - Flower died!");
            // TODO: game over obrazovka
        }
    }
}