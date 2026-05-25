using Godot;

public partial class Spell : Area3D
{
    [Export] public float Speed = 15f;
    [Export] public float Damage = 25f;
    [Export] public float Lifetime = 3f;

    private Vector3 _direction;

    public void Initialize(Vector3 direction, Player.SpellType spellType)
    {
        _direction = direction.Normalized();
        SetSpellType(spellType);
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

    private void SetSpellType(Player.SpellType spellType)
    {
        var mesh = GetNode<MeshInstance3D>("MeshInstance3D");
        if (mesh == null) return;

        var material = new StandardMaterial3D();
        material.EmissionEnabled = true;

        Color color = spellType switch
        {
            Player.SpellType.Fireball  => new Color(1.0f, 0.2f, 0.0f),
            Player.SpellType.IceShard  => new Color(0.0f, 0.5f, 1.0f),
            Player.SpellType.Lightning => new Color(1.0f, 1.0f, 0.0f),
            Player.SpellType.Poison    => new Color(0.0f, 1.0f, 0.2f),
            _ => new Color(1.0f, 1.0f, 1.0f)
        };

        material.AlbedoColor = color;
        material.Emission = color;
        material.EmissionEnergyMultiplier = 2.0f;
        mesh.MaterialOverride = material;
    }
}