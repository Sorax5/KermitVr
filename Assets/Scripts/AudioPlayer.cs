using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private List<ICommand> commandQueue = new List<ICommand> ();

    public void AddCommand(ICommand command)
    {
        commandQueue.Add(command);
    }

    public void ExecuteCommands()
    {
        foreach (ICommand command in commandQueue)
        {
            command.Execute();
        }

        commandQueue.Clear ();
    }
}
