using Godot;

public partial class Player : CharacterBody2D
{
    private int _speed = 600;

    public override void _PhysicsProcess(double delta)
    {
        // Pegando a direção dos controles do jogador
        var direction = Input.GetVector(
            "left", "right", "up", "down"
        ).Normalized();
        
        Velocity = direction * _speed;
        MoveAndSlide();
        
        if (Velocity.Length() > 0)
            /*
             * pegando o Node que está dentro do player e usando a funcionalidades
             * que estão em gdscript e executando em C#
             */
        
            GetNode("HappyBoo").Call("play_walk_animation");
        else
            GetNode("HappyBoo").Call("play_idle_animation");
    }
}