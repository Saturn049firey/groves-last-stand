using Godot;
using System;

public partial class GameManager : Node3D
{
    [Export] private GameOver gameOver;

    public void OnFlowerDeath()
    {
        gameOver.ShowGameOver();
    }

}
