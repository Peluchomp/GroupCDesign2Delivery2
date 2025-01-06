using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RootBindCommand : FightCommand
{
    public RootBindCommand()
    {
        PossibleTargets = TargetTypes.Enemy;
        FightCommandType = FightCommandTypes.RootBind;
    }

    public RootBindCommand(Fighter executor, Fighter target, float priority) : base(executor, target, priority)
    {
        PossibleTargets = TargetTypes.Enemy;
        FightCommandType = FightCommandTypes.RootBind;
    }

    public override void Excecute()
    {
        _target.TakeDamage(20);
        _target.AddDefense(-3);
        _executor.Mana(50);
    }

    public override void Undo()
    {
        _target.TakeDamage(-10);
  
    }
}
