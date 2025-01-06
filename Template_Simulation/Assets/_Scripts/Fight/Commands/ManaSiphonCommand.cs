using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ManaSiphonCommand : FightCommand
{
    public ManaSiphonCommand()
    {
        PossibleTargets = TargetTypes.Self;
        FightCommandType = FightCommandTypes.ManaSiphon;
    }
    public ManaSiphonCommand(Fighter executor, Fighter target, float priority) : base(executor, target, priority)
    {
        PossibleTargets = TargetTypes.Self;
        FightCommandType = FightCommandTypes.ManaSiphon;
    }

    public override void Excecute()
    {
        _executor.RestoreMana(25);
    }

    public override void Undo()
    {
        _executor.Mana(-15);
    }
}
