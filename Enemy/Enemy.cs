using Godot;

public partial class Enemy : CharacterBody3D
{
    [Export] public float Speed = 2.5f;
    [Export] public float StopDistance = 1.5f; // vzdálenost kdy přestane chodit
    [Export] public float MaxHealth = 100f;
    private float _health;
    private Node3D _target;

    public override void _Ready()
    {
        _health = MaxHealth;
        _target = GetTree().GetFirstNodeInGroup("player") as Node3D;
    }

    public void TakeDamage(float amount)
    {
        _health -= amount;
        GD.Print("Demon HP: " + _health);
        if (_health <= 0)
            QueueFree();
    }

    public override void _PhysicsProcess(double delta)
    {
        if (_target == null) return;

        Vector3 toTarget = _target.GlobalPosition - GlobalPosition;
        toTarget.Y = 0; // pohyb jen horizontálně

        Vector3 velocity = Velocity;

        if (toTarget.Length() > StopDistance)
        {
            // Chodí směrem k cíli
            velocity.X = toTarget.Normalized().X * Speed;
            velocity.Z = toTarget.Normalized().Z * Speed;
        }
        else
        {
            // Zastaví se
            velocity.X = 0;
            velocity.Z = 0;
        }

        // Gravitace
        if (!IsOnFloor())
            velocity.Y += GetGravity().Y * (float)delta;

        Velocity = velocity;
        MoveAndSlide();
    }
}