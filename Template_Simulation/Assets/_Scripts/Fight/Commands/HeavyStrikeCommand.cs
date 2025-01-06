using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyStrikeCommand : FightCommand
{
    public HeavyStrikeCommand()
    {
        PossibleTargets = TargetTypes.Enemy;
        FightCommandType = FightCommandTypes.HeavyStrike;
    }
    public HeavyStrikeCommand(Fighter executor, Fighter target, float priority) : base(executor, target, priority)
    {
        PossibleTargets = TargetTypes.Enemy;
        FightCommandType = FightCommandTypes.HeavyStrike;
    }

    public override void Excecute()
    {
        _target.TakeDamage(20);
        _target.AddDefense(-2); 
        _executor.Mana(20);
    }

    public override void Undo()
    {
        _target.TakeDamage(-20);
    }
}