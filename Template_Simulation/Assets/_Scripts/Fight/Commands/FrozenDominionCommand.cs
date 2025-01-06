using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrozenDominionCommand : FightCommand
{
    public FrozenDominionCommand()
    {
        PossibleTargets = TargetTypes.Enemy;
        FightCommandType = FightCommandTypes.FrozenDominion;
    }
    public FrozenDominionCommand(Fighter executor, Fighter target, float priority) : base(executor, target, priority)
    {
        PossibleTargets = TargetTypes.Enemy;
        FightCommandType = FightCommandTypes.FrozenDominion;
    }

    public override void Excecute()
    {
        _target.TakeDamage(15);
        _executor.Heal(15);
        _executor.Mana(20);
    }

    public override void Undo()
    {
        _target.TakeDamage(-15);
        _executor.Heal(-15);
        _executor.Mana(20);
    }
}
