using Godot;

public partial class WaveManager : Node
{
    [Export] public PackedScene EnemyScene;     // přetáhni Enemy.tscn
    [Export] public Node3D SpawnPoint;          // portál kde spawnou démoni
    [Export] public float TimeBetweenWaves = 10f; // čas mezi vlnami
    [Export] public int EnemiesPerWave = 3;     // démoni v první vlně

    private int _currentWave = 0;
    private float _waveTimer = 0f;
    private bool _waveInProgress = false;
    private int _enemiesAlive = 0;

    public override void _Process(double delta)
    {
        if (_waveInProgress) return;

        _waveTimer -= (float)delta;

        if (_waveTimer <= 0f)
            StartWave();
    }

    private void StartWave()
    {
        _currentWave++;
        _waveInProgress = true;

        // Každá vlna má více démonů
        int count = EnemiesPerWave + (_currentWave - 1) * 2;
        _enemiesAlive = count;

        GD.Print($"Vlna {_currentWave} začíná! Démonů: {count}");

        for (int i = 0; i < count; i++)
            SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        if (EnemyScene == null || SpawnPoint == null) return;

        var enemy = EnemyScene.Instantiate<Enemy>();
        GetParent().AddChild(enemy);

        // Spawn u portálu s malým rozptylem
        var offset = new Vector3(
            GD.Randf() * 2f - 1f,
            0,
            GD.Randf() * 2f - 1f
        );
        enemy.GlobalPosition = SpawnPoint.GlobalPosition + offset;

        // Když démon zemře → zkontroluj jestli vlna skončila
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