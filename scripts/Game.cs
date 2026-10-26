using Godot;
using System;

public partial class Game : Node2D
{
    private PackedScene _mobScene = GD.Load<PackedScene>("res://mob.tscn");
    private PathFollow2D _pathFollow2D;
    private CanvasLayer _gamerOver;
    
    public override void _Ready()
    {
        _pathFollow2D = GetNode<PathFollow2D>("%PathFollow2D");
        _gamerOver = GetNode<CanvasLayer>("%GamerOver");
    }

    private void _spawnMob()
    {
        var mob = (Node2D)_mobScene.Instantiate();  
        
        // Adicionado o (float) aqui para corrigir o tipo
        _pathFollow2D.ProgressRatio = (float)GD.Randf();
       
        mob.GlobalPosition = _pathFollow2D.GlobalPosition;
        AddChild(mob);     
    }

    public void OnTimerTimeout()
    {
        _spawnMob();
        GD.Print("Spawned mob");
    }

    public void OnPlayerHealthDepleted()
    {
        // 1. Torna visível primeiro
        _gamerOver.Visible = true;
    
        // 2. Pausa o jogo depois
        GetTree().Paused = true;
    }
    public void OnButtonPressed()
    {
        GetTree().Paused = false;
        GetTree().ReloadCurrentScene();
        GD.Print("Button pressed");
    }
}
