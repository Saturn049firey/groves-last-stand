using Godot;

public partial class Flower : StaticBody3D
{
    [Signal] public delegate void DeathEventHandler();
    [Export] public float MaxHealth = 100f;
    public float Health => _health;
    private float _health;

    public override void _Ready()
    {
        _health = MaxHealth;
    }

    public void TakeDamage(float amount)
    {
        _health -= amount;
        _health = Mathf.Max(_health, 0);
        GD.Print("Flower HP: " + _health);

        if (_health <= 0)
        {
            GD.Print("GAME OVER - Flower died!");
            EmitSignal(SignalName.Death);
        }
    }
}