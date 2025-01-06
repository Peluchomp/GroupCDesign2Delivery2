using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RunicDisruptionCommand : FightCommand
{
    public RunicDisruptionCommand()
    {
        PossibleTargets = TargetTypes.Enemy;
        FightCommandType = FightCommandTypes.RunicDisruption;
    }
    public RunicDisruptionCommand(Fighter executor, Fighter target, float priority) : base(executor, target, priority)
    {
        PossibleTargets = TargetTypes.Enemy;
        FightCommandType = FightCommandTypes.RunicDisruption;
    }

    public override void Excecute()
    {
        _target.AddDefensePermanent(2);
        _executor.Mana(20);
    }

    public override void Undo()
    {
        _executor.Mana(20);
    }
}
