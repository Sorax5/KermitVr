using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioPlayer : MonoBehaviour
{
    private List<ICommand> commandQueue = new List<ICommand> ();

    public GameObject objectToMove; // R�f�rence � l'objet que vous souhaitez d�placer
    public GameObject playerXR;

    // Ajoutez une fonction pour mettre � jour la position de l'objet
    private void UpdateObjectPosition(float elapsedTime)
    {
        float speed = 1.0f;
        objectToMove.transform.position += new Vector3(0, 0, speed * elapsedTime);
        playerXR.transform.position = new Vector3(playerXR.transform.position.x, playerXR.transform.position.y, objectToMove.transform.position.z - 10f);
    }

    public void AddCommand(ICommand command)
    {
        commandQueue.Add(command);

        // V�rifier si la file d'attente contient plus d'une commande
        if (commandQueue.Count > 1)
        {
            // Lancer la coroutine pour v�rifier p�riodiquement la fin de l'AudioClip
            StartCoroutine(CheckAudioClipEnd());
        }
    }

    public void ExecuteCommands()
    {
        StartCoroutine(PlayAudioSequence());
    }

    private IEnumerator PlayAudioSequence()
    {
        foreach (var command in commandQueue)
        {
            command.Execute();

            yield return new WaitForSecondsRealtime(command.GetAudioClipLength());
        }

        commandQueue.Clear();
        SceneManager.LoadSceneAsync(2);
    }

    private IEnumerator CheckAudioClipEnd()
    {
        while (commandQueue.Count > 0)
        {
            if (!(commandQueue[0] as PlayAudioCommand).IsAudioPlaying())
            {
                commandQueue.RemoveAt(0);

                if (commandQueue.Count > 0)
                {
                    commandQueue[0].Execute();
                }
            }

            UpdateObjectPosition(Time.deltaTime);

            yield return null;
        }
    }
}
