using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecroticBeamCommand : FightCommand
{
    public NecroticBeamCommand()
    {
        PossibleTargets = TargetTypes.Enemy;
        FightCommandType = FightCommandTypes.NecroticBeam;
    }
    public NecroticBeamCommand(Fighter executor, List<Fighter> targets, float priority) : base(executor, null, priority)
    {
        PossibleTargets = TargetTypes.Enemy;
        FightCommandType = FightCommandTypes.NecroticBeam;
    }

    public override void Excecute()
    {
      
        _target.TakeDamage(55);
        _executor.Mana(60);
    }

    public override void Undo()
    {
        _target.TakeDamage(-55);
        _executor.Mana(60);
    }
}
