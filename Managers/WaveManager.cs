using Godot;

public partial class WaveManager : Node
{
    [Export] public PackedScene EnemyScene;
    [Export] public Node3D SpawnPoint;
    [Export] public float TimeBetweenWaves = 10f;
    [Export] public int EnemiesPerWave = 3;

    private int _currentWave = 0;
    private float _waveTimer = 0f;
    private bool _waveInProgress = false;
    private int _enemiesAlive = 0;

    // Public property pro HUD
    public int CurrentWave => _currentWave;
    public bool WaveInProgress => _waveInProgress;

    public override void _Process(double delta)
    {
        if (_waveInProgress) return;

        _waveTimer -= (float)delta;

        if (_waveTimer <= 0f)
            StartWave();
    }

    private int GetEnemiesInWave()
    {
        return EnemiesPerWave + (_currentWave - 1) * 2;
    }

    private void StartWave()
    {
        _currentWave++;

        if (_currentWave > GameData.FinalWave)
        {
            GD.Print("VICTORY!");
            // TODO: zobrazit victory screen
            return;
        }

        GD.Print("StartWave zavolano, vlna: " + _currentWave);
        _waveInProgress = true;

        int count = GetEnemiesInWave();
        _enemiesAlive = count;

        GD.Print($"Vlna {_currentWave} začíná! Počet démonů: {count}");

        for (int i = 0; i < count; i++)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        if (EnemyScene == null || SpawnPoint == null) return;

        var enemy = EnemyScene.Instantiate<Enemy>();
        AddChild(enemy);

        var offset = new Vector3(
            GD.Randf() * 2f - 1f,
            0,
            GD.Randf() * 2f - 1f
        );
        enemy.GlobalPosition = SpawnPoint.GlobalPosition + offset;
        enemy.TreeExited += OnEnemyDied;
    }

    private void OnEnemyDied()
    {
        _enemiesAlive--;
        GD.Print($"Démon zabit, zbývá: {_enemiesAlive}");

        if (_enemiesAlive <= 0)
        {
            GD.Print("Vlna dokončena!");
            _waveInProgress = false;
            _waveTimer = TimeBetweenWaves;
        }
    }
}