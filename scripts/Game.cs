using Godot;
using System;

public partial class Game : Node2D
{
    private PackedScene _mobScene = GD.Load<PackedScene>("res://mob.tscn");
    private PathFollow2D _pathFollow2D;

    public override void _Ready()
    {
        _pathFollow2D = GetNode<PathFollow2D>("%PathFollow2D");
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
}
