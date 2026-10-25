using Godot;
using System;

public partial class Gun : Area2D
{
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
}
