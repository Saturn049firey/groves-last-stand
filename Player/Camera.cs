using Godot;

public partial class Camera : Camera3D
{
	[Export] public float Sensitivity = 0.003f;

	private float _rotationX = 0f;
	private float _rotationY = 0f;  // ukládáme rotaci hráče

	public override void _Ready()
	{
		Input.SetMouseMode(Input.MouseModeEnum.Captured);
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseMotion mouseMotion)
		{
			// Jen ukládáme hodnoty, nerotujeme přímo
			_rotationY -= mouseMotion.Relative.X * Sensitivity;
			_rotationX -= mouseMotion.Relative.Y * Sensitivity;
			_rotationX = Mathf.Clamp(_rotationX, -Mathf.Pi / 2, Mathf.Pi / 2);
		}

		if (Input.IsActionJustPressed("ui_cancel"))
		{
			Input.SetMouseMode(Input.MouseModeEnum.Visible);
		}
	}

	public override void _Process(double delta)
	{
		// Aplikujeme rotaci každý snímek plynule
		var player = GetParent<CharacterBody3D>();
		player.Rotation = new Vector3(0, _rotationY, 0);
		Rotation = new Vector3(_rotationX, 0, 0);
	}
}
