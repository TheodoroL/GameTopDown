using Godot;

public partial class Player : CharacterBody2D
{
    [Signal]
    public delegate void HealthDepletedEventHandler();
    
    private int _speed = 600;
    private double  _health = 100;
    private int _damage = 5;

    private ProgressBar _progressBar;

    public override void _Ready()
    {
        _progressBar = GetNode<ProgressBar>("%ProgressBar");
    }
    
    public override void _PhysicsProcess(double delta)
    {
        // Pegando a direção dos controles do jogador
        var direction = Input.GetVector(
            "left", "right", "up", "down"
        ).Normalized();
        
        Velocity = direction * _speed;
        MoveAndSlide();

        var happyBoo = GetNode("HappyBoo");
        
        if (Velocity.Length() > 0)
            /*
             * pegando o Node que está dentro do player e usando a funcionalidades
             * que estão em gdscript e executando em C#
             */
        
            happyBoo.Call("play_walk_animation");
        else
            happyBoo.Call("play_idle_animation");
        
        var overlanppingMobs = GetNode<Area2D>("%HurfBox").GetOverlappingBodies();

        if (overlanppingMobs.Count > 0)
        {
            _health-= _damage *overlanppingMobs.Count *delta;
            _progressBar.Value = _health;
           
            if (_health <= 0)
                EmitSignal(nameof(HealthDepletedEventHandler));
        }
        
    }
}