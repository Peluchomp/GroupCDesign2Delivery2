using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlacialShieldCommand : FightCommand
{
    public GlacialShieldCommand()
    {
        PossibleTargets = TargetTypes.Friend;
        FightCommandType = FightCommandTypes.GlacialShield;
    }
    public GlacialShieldCommand(Fighter executor, float priority) : base(executor, executor, priority)
    {
        PossibleTargets = TargetTypes.Self;
        FightCommandType = FightCommandTypes.GlacialShield;
    }

    public override void Excecute()
    {
        _executor.AddDefense(10);
        _executor.AddSpeed(2);
        _executor.Mana(60);
    }

    public override void Undo()
    {
       
    }
}