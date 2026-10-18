using Godot;
using System;

public partial class Mob : CharacterBody2D
{
	private Player _player;
	private int _speed = 300;
	public override void _Ready()
	{
		_player = GetNode<Player>("../Player");
	}

	public override void _PhysicsProcess(double delta)
	{
		//pegar a direção do player e fazer que o mob segue ele
		var direction = GlobalPosition.DirectionTo(_player.GlobalPosition);
		Velocity = direction * _speed;
		MoveAndSlide();

	}
}
