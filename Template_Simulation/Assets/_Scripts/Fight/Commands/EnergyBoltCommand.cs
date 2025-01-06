using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBoltCommand : FightCommand
{
    public EnergyBoltCommand()
    {
        PossibleTargets = TargetTypes.Enemy;
        FightCommandType = FightCommandTypes.EnergyBolt;
    }
    public EnergyBoltCommand(Fighter executor, Fighter target, float priority) : base(executor, target, priority)
    {
        PossibleTargets = TargetTypes.Enemy;
        FightCommandType = FightCommandTypes.EnergyBolt;
    }

    public override void Excecute()
    {
        _target.TakeDamage(40);
        _executor.Mana(30);
    }

    public override void Undo()
    {
        _target.TakeDamage(-30);
        _executor.Mana(20);
    }
}