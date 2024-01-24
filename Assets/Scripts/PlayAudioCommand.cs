using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayAudioCommand : ICommand
    {
        private AudioSource audioSource;
        private AudioClip audioClip;

        public PlayAudioCommand(AudioSource audioSource, AudioClip audioClip)
        {
            this.audioSource = audioSource;
            this.audioClip = audioClip;
        }

        public void Execute()
        {
            if (audioSource != null && audioClip != null)
            {
                audioSource.clip = audioClip;
                audioSource.Play();
            }
        }

        public float GetAudioClipLength()
        {
            return audioClip.length;
        }

        public bool IsAudioPlaying()
        {
            return audioSource.isPlaying;
        }
    }
}
