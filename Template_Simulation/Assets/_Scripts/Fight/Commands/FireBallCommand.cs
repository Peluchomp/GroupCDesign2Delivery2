using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FireBallCommand : FightCommand
{
    public FireBallCommand()
    {
        PossibleTargets = TargetTypes.Enemy;
        FightCommandType = FightCommandTypes.FireBall;
    }
    public FireBallCommand(Fighter executor, Fighter target, float priority) : base(executor, target, priority)
    {
        PossibleTargets = TargetTypes.Enemy;
        FightCommandType = FightCommandTypes.FireBall;
    }

    public override void Excecute()
    {
        _target.TakeDamage(_executor.Attack*2f);
        _executor.Mana(30);
    }

    public override void Undo()
    {
        _target.TakeDamage(-_executor.Attack);
    }
}
