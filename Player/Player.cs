using Godot;
using System;

public partial class Player : CharacterBody3D
{
	[Export] public float MaxHealth = 100f;
	[Export] public float MaxMana = 100f;
	public float Health => _health;
	public float Mana => _mana;
	public SpellType CurrentSpell => _currentSpell;

	private float _health;
	private float _mana;
	private float _manaRegenRate = 10f;

	public const float Speed = 5.0f;
	public const float JumpVelocity = 4.5f;

	public enum SpellType { Fireball, IceShard, Lightning, Poison }
	private SpellType _currentSpell = SpellType.Fireball;

	[Export] public Staff staff;

	public override void _Ready()
	{
		_health = MaxHealth;
		_mana = MaxMana;
		staff?.SetCrystalColor(_currentSpell);
	}

	public override void _PhysicsProcess(double delta)
	{
		// Mana regenerace
		_mana = Mathf.Min(_mana + _manaRegenRate * (float)delta, MaxMana);

		Vector3 velocity = Velocity;

		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		Vector2 inputDir = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
		if (direction != Vector3.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Z = direction.Z * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Z = Mathf.MoveToward(Velocity.Z, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseBtn && mouseBtn.Pressed)
		{
			if (mouseBtn.ButtonIndex == MouseButton.WheelUp)
				CycleSpell(1);
			else if (mouseBtn.ButtonIndex == MouseButton.WheelDown)
				CycleSpell(-1);
		}

		if (Input.IsActionJustPressed("spell_1")) SwitchSpell(SpellType.Fireball);
		if (Input.IsActionJustPressed("spell_2")) SwitchSpell(SpellType.IceShard);
		if (Input.IsActionJustPressed("spell_3")) SwitchSpell(SpellType.Lightning);
		if (Input.IsActionJustPressed("spell_4")) SwitchSpell(SpellType.Poison);
	}

	private void CycleSpell(int direction)
	{
		int count = Enum.GetValues(typeof(SpellType)).Length;
		int next = ((int)_currentSpell + direction + count) % count;
		SwitchSpell((SpellType)next);
	}

	private void SwitchSpell(SpellType spell)
	{
		_currentSpell = spell;
		staff?.SetCrystalColor(spell);
		GD.Print("Spell: " + spell);
	}
}