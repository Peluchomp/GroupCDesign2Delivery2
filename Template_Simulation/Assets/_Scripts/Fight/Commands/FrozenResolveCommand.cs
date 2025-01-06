using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrozenResolveCommand : FightCommand
{
    public FrozenResolveCommand()
    {
        PossibleTargets = TargetTypes.Self;
        FightCommandType = FightCommandTypes.FrozenResolve;
    }
    public FrozenResolveCommand(Fighter executor, float priority) : base(executor, executor, priority)
    {
        PossibleTargets = TargetTypes.Self;
        FightCommandType = FightCommandTypes.FrozenResolve;
    }

    public override void Excecute()
    {
        _executor.AddAttackPermanent(5); 
        _executor.AddDefensePermanent(2);
        _executor.Mana(45);
    }

    public override void Undo()
    {
        _executor.AddAttackPermanent(-5); 
        _executor.AddDefensePermanent(-2);
    }
}
