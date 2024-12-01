using ReflectionFactory;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;

public class CombatManager_Auto : MonoBehaviour
{
    public EntityManager EntityManager;
   
    public Invoker Invoker;
 

    private FightCommandTypes _chosenType;
    private CommandFactory _factory;
    private FightCommand _currentCommand;

    int _round;
    // Start is called before the first frame update
    
    int nSimulations = 50;
    const int nSamples=40;
    int[] winA = new int[nSamples];
    int[] winB = new int[nSamples];
    int iteration = 0;

    int[] _hp = new int[nSamples];
    int[] _mana = new int[nSamples];

    void Start()
    {
        _factory = new CommandFactory();
        Sensitivity();
    }
    void Sensitivity()
    {
        for (int i = 0; i < nSamples; i++)
        {
            _hp[i] = i * 10;
            RepeatBattle();
            iteration++;
           // Debug.Log(_hp[i] + ";" + winA[i] + ";" + winB[i]);
        }
        WriteFile();
    }

    void WriteFile()
    {
        string path = "Assets/test.txt";

        //Write some text to the test.txt file

        StreamWriter writer = new StreamWriter(path, true);

        for (int i = 0; i < nSamples; i++)
        {
            
            writer.WriteLine(_hp[i] + ";"+winA[i]+";"+winB[i]);
        }
        

        writer.Close();
    }

    void RepeatBattle()
    {
        
        
        for (int i = 0; i < nSimulations; i++)
        {
            
            StartBattle();
        }
        //Debug.Log("WinA: " + winA + "  WinB: " + winB);
    }

    void StartBattle()
    {
        SetParameters();
        DoAllTurns();
    }

    void SetParameters()
    {
        foreach (var fighter in EntityManager.AllFighters)
        {
            fighter.SetParameters(100, 100,10, 5);
        }

        EntityManager.AllFighters[2].SetParameters(_hp[iteration], _mana[iteration], 10, 5);
    }

    void DoAllTurns()
    {
        Team winner = Team.None;
        Debug.Log("Remove winner");
        while (winner == Team.None)
        {
            DoOneTurn();
            winner = GetWinner();
            Debug.Log(winner);
            //Debug.Log("Round: " + ++_round);
        }
        //Debug.Log("Winner is: " + winner);
        if (winner == Team.TeamA)
            winA[iteration]++;
        if (winner == Team.TeamB)
            winB[iteration]++;



    }

    private Team GetWinner()
    {
        Debug.Log(EntityManager.GetWinner());
        return EntityManager.GetWinner();
    }

    void DoOneTurn()
    {
       
        _currentCommand = GetCommand();
        var target = ChooseTarget(_currentCommand);
        _currentCommand.SetFighters(EntityManager.ActiveFighter, target);
      
        _currentCommand.Excecute();
        EntityManager.ActiveFighter.ResetFighter();
        EntityManager.SetNextEntity();
        Debug.Log("Turn");
    }

    FightCommand GetCommand()
    {
        var possibleCommandsList = ((Fighter)EntityManager.ActiveEntity).PossibleCommands;
        if (possibleCommandsList.Count == 0)
            return null;

        int rdm = Random.Range(0, possibleCommandsList.Count);
       
        return _factory.GetCommand(possibleCommandsList[rdm]);
    }

    public void DoAction(FightCommandTypes commandType)
    {
        _chosenType = commandType;
        _currentCommand = _factory.GetCommand(_chosenType);

        ChooseTarget(_currentCommand);
        //DoAction(EntityManager.ActiveEntity, EntityManager.OtherEntity, type);
        //NextTurn();

    }

     

    private Fighter ChooseTarget(FightCommand _currentCommand)
    {
        var targetTypes = _currentCommand.PossibleTargets;

        Entity[] possibleTargets;

        switch (targetTypes)
        {
            case TargetTypes.Enemy:
                possibleTargets = EntityManager.Enemies;
                break;
            case TargetTypes.Friend:
                possibleTargets = EntityManager.Friends;
                break;
            case TargetTypes.FriendNotSelf:
                possibleTargets = EntityManager.FriendsNotSelf;
                break;
            case TargetTypes.Self:
                possibleTargets = new Entity[1];
                possibleTargets[0] = EntityManager.ActiveEntity;
                break;

            default:
                possibleTargets = EntityManager.Enemies;
                break;
        }

        if (possibleTargets.Length == 0)
            return null;

        int rdm = Random.Range(0, possibleTargets.Length);
        return possibleTargets[rdm] as Fighter;
        //ActionButtonController.ChooseTarget(EntityManager.ActiveEntity);
        //TargetChooser.StartChoose(possibleTargets);
    }

   
 

}
