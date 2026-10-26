using Godot;
using System;

public partial class Bullet : Area2D
{
	private float _speed = 1000f;
	private float _travelldedDistance = 0;
	private float  _range = 1200f;
	public override void _PhysicsProcess(double delta)
	{
		var direction = Vector2.Right.Rotated(Rotation);
    
		Position += direction * _speed * (float)delta;
    
		_travelldedDistance += _speed * (float)delta;
      
		if (_travelldedDistance > _range)
			QueueFree();
	}

	public void OnBodyEntered(Node2D body)
	{
		QueueFree();
		if (body.HasMethod("TakeDamage"))
		{
			body.Call("TakeDamage");
		}
	}
}
