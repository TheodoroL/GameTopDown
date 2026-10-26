using Godot;
using System;

public partial class Gun : Area2D
{
    private PackedScene _bulletScene = GD.Load<PackedScene>("res://bullet.tscn");
    private Marker2D _shootingPointer;
    
    public override void _Ready()
    {
        _shootingPointer = GetNode<Marker2D>("%ShootingPointer");
    }
    
    public override void _PhysicsProcess(double delta)
    {
        //pegando a lista de Node2D
       var enemies =  GetOverlappingBodies();
       
       if (enemies.Count > 0)
       {
           //pegando a posição do inimigo mais proximo
           var targetEnemies = enemies[0];
           LookAt(targetEnemies.GlobalPosition);
       }
    }

    public void Shoot()
    {
        Node2D newBullet = (Node2D)_bulletScene.Instantiate();
    
        // 1. Adiciona a bala na raiz do jogo (ou na cena atual) para que ela siga reto sozinha
        GetTree().Root.AddChild(newBullet);
    
        // 2. Define a posição inicial na ponta do cano
        newBullet.GlobalPosition = _shootingPointer.GlobalPosition;
    
        // 3. Faz a bala herdar a rotação atual da arma para saber para onde ir
        newBullet.GlobalRotation = GlobalRotation;
    }

    public void OnTimerTimeout()
    {
        Shoot();
    }
}
