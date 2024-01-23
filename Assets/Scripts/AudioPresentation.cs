using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPresentation : MonoBehaviour
{
    public AudioClip[] audioClips;
    private AudioPlayer audioPlayer;

    void Start()
    {
        audioPlayer = GetComponent<AudioPlayer>();

        foreach (var clip in audioClips)
        {
            audioPlayer.AddCommand(new PlayAudioCommand(GetComponent<AudioSource>(), clip));
        }

        audioPlayer.ExecuteCommands();
    }
}
