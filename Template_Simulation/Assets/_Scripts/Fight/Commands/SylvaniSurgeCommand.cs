using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SylvaniSurgeCommand : FightCommand
{
    public SylvaniSurgeCommand()
    {
        PossibleTargets = TargetTypes.Friend;
        FightCommandType = FightCommandTypes.SylvaniSurge;
    }

    public SylvaniSurgeCommand(Fighter executor, Fighter target, float priority) : base(executor, target, priority)
    {
        PossibleTargets = TargetTypes.Friend;
        FightCommandType = FightCommandTypes.SylvaniSurge;
    }

    public override void Excecute()
    {
        _executor.RestoreMana(30);
    }

    public override void Undo()
    {
        _executor.RestoreMana(-20);
    }
}