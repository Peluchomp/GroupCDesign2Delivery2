using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

// Eldertree’s Blossom Ability
public class EldertreeBlossomCommand : FightCommand
{
    public EldertreeBlossomCommand()
    {
        PossibleTargets = TargetTypes.FriendNotSelf;
        FightCommandType = FightCommandTypes.EldertreeBlossom;
    }

    public EldertreeBlossomCommand(Fighter executor, Fighter target, float priority) : base(executor, target, priority)
    {
        PossibleTargets = TargetTypes.FriendNotSelf;
        FightCommandType = FightCommandTypes.EldertreeBlossom;
    }

    public override void Excecute()
    {
        _target.Heal(25);
        _target.AddDefense(2);
        _executor.Mana(30);
    }

    public override void Undo()
    {
        _target.Heal(-25);
    }
}