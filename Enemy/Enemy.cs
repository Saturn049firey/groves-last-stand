using Godot;

public partial class Enemy : CharacterBody3D
{
	[Export] public float Speed = 2.5f;
	[Export] public float DamageAmount = 10f;
	[Export] public float AttackDistance = 1.5f;
	[Export] public float AttackCooldown = 1.0f;
	[Export] public float StopDistance = 1.5f;
	[Export] public float MaxHealth = 100f;
	[Export] public ProgressBar HpBar;

	private float _health;
	private Node3D _target;
	private float _attackTimer = 0f;

	public override void _Ready()
	{
		_health = MaxHealth;
		_target = GetTree().GetFirstNodeInGroup("flower") as Node3D;

		if (HpBar != null)
		{
			HpBar.MaxValue = MaxHealth;
			HpBar.Value = _health;
		}
	}

	public void Kill()
	{
		QueueFree();
	}

	public void TakeDamage(float amount)
	{
		_health -= amount;
		_health = Mathf.Max(_health, 0);

		if (HpBar != null)
			HpBar.Value = _health;

		GD.Print("Demon HP: " + _health);

		if (_health <= 0)
		{
			_health = 0;
			Kill();
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		if (_target == null) { return; }

		Vector3 toTarget = _target.GlobalPosition - GlobalPosition;
		toTarget.Y = 0;

		Vector3 velocity = Velocity;

		if (toTarget.Length() <= AttackDistance)
		{
			_attackTimer -= (float)delta;
			if (_attackTimer <= 0f)
			{
				var player = _target as Player;
				if (player != null)
				{
					player.TakeDamage(DamageAmount);
					GD.Print("Demon has hit the player!");
				}

				var flower = _target as Flower;
				if (flower != null)
				{
					flower.TakeDamage(DamageAmount);
					GD.Print("Demon has hit the flower!");
				}

				_attackTimer = AttackCooldown;
			}
		}
		else
		{
			_attackTimer = 0f;
		}

		if (toTarget.Length() > StopDistance)
		{
			velocity.X = toTarget.Normalized().X * Speed;
			velocity.Z = toTarget.Normalized().Z * Speed;
		}
		else
		{
			velocity.X = 0;
			velocity.Z = 0;
		}

		if (!IsOnFloor())
		{
			velocity.Y += GetGravity().Y * (float)delta;
		}

		Velocity = velocity;

		MoveAndSlide();
	}
}