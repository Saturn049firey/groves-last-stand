using Godot;
using System;

public partial class Staff : Node3D
{
	[Export] public MeshInstance3D Crystal;

	public override void _Ready()
	{
		SetCrystalColor(Player.SpellType.Fireball);
	}

	public override void _Process(double delta)
	{
	}

	public void SetCrystalColor(Player.SpellType spell)
	{
		if (Crystal == null)
		{
			GD.Print("Crystal je null!");
			return;
		}

		var material = Crystal.GetActiveMaterial(0);
		GD.Print("Material typ: " + material?.GetType().Name);

		var shaderMat = material as ShaderMaterial;
		if (shaderMat == null)
		{
			GD.Print("Není ShaderMaterial!");
			return;
		}

		Color color = spell switch
		{
			Player.SpellType.Fireball => new Color(1.0f, 0.2f, 0.0f),
			Player.SpellType.IceShard => new Color(0.0f, 0.5f, 1.0f),
			Player.SpellType.Lightning => new Color(1.0f, 1.0f, 0.0f),
			Player.SpellType.Poison => new Color(0.0f, 1.0f, 0.2f),
			_ => new Color(1.0f, 1.0f, 1.0f)
		};

		shaderMat.SetShaderParameter("crystal_color", color);
		GD.Print("Barva nastavena: " + color);
	}
}
