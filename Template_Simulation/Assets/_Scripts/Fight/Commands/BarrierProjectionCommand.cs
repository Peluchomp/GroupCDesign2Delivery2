using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierProjectionCommand : FightCommand
{
    public BarrierProjectionCommand()
    {
        PossibleTargets = TargetTypes.FriendNotSelf;
        FightCommandType = FightCommandTypes.BarrierProjection;
    }
    public BarrierProjectionCommand(Fighter executor, Fighter target, float priority) : base(executor, target, priority)
    {
        PossibleTargets = TargetTypes.FriendNotSelf;
        FightCommandType = FightCommandTypes.BarrierProjection;
    }

    public override void Excecute()
    {
        _target.AddDefense(40);
        _executor.Mana(35);
    }

    public override void Undo()
    {
        _executor.Mana(35);
    }
}
