using Godot;
using System;

public partial class Mob : CharacterBody2D
{
	private Player _player;
	private int _speed = 300;
	private int _health = 3;
	private PackedScene _smkeScene =  GD.Load<PackedScene>("res://smoke_explosion/smoke_explosion.tscn");
	
	
	public override void _Ready()
	{
		_player = GetNode<Player>("../Player");
		GetNode("%Slime").Call("play_walk");
	}

	public override void _PhysicsProcess(double delta)
	{
		//pegar a direção do player e fazer que o mob segue ele
		var direction = GlobalPosition.DirectionTo(_player.GlobalPosition);
		Velocity = direction * _speed;
		MoveAndSlide();

	}

	public void TakeDamage()
	{
		_health--;
		GetNode("%Slime").Call("play_hurt");

		if (_health <= 0)
		{
			QueueFree();

			var smoke = (Node2D)_smkeScene.Instantiate();
			GetParent().AddChild(smoke);
			smoke.GlobalPosition = GlobalPosition;
		}
			
		
	}
}
