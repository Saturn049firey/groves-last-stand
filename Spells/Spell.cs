using Godot;

public partial class Spell : Area3D
{
    [Export] public float Speed = 15f;
    [Export] public float Damage = 25f;
    [Export] public float Lifetime = 3f;

    private Vector3 _direction;

    public void Initialize(Vector3 direction)
    {
        _direction = direction.Normalized();
    }

    public override void _Ready()
    {
        var timer = GetTree().CreateTimer(Lifetime);
        timer.Timeout += QueueFree;

        BodyEntered += OnBodyEntered;
    }

    public override void _Process(double delta)
    {
        GlobalPosition += _direction * Speed * (float)delta;
    }

    private void OnBodyEntered(Node3D body)
    {
        if (body is Enemy enemy)
        {
            enemy.TakeDamage(Damage);
            QueueFree();
        }
    }
}