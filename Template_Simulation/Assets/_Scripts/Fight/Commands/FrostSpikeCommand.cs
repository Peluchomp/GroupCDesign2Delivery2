using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostSpikeCommand : FightCommand
{
    public FrostSpikeCommand()
    {
        PossibleTargets = TargetTypes.Enemy;
        FightCommandType = FightCommandTypes.FrostSpike;
    }
    public FrostSpikeCommand(Fighter executor, Fighter target, float priority) : base(executor, target, priority)
    {
        PossibleTargets = TargetTypes.Enemy;
        FightCommandType = FightCommandTypes.FrostSpike;
    }

    public override void Excecute()
    {
        _target.TakeDamage(30);
        _target.AddDefense(-2); 
        _executor.Mana(30);
    }

    public override void Undo()
    {
        _target.TakeDamage(-30);
        _executor.Mana(30);
    }
}
