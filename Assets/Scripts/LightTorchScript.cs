using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTorchScript : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject lightTorch;
    
    [SerializeField] private AudioClip torchOn;
    [SerializeField] private AudioClip torchOff;
    
    private bool torchActive = false;
    
    public void DeactivateTorch()
    {
        if (torchActive)
        {
            audioSource.PlayOneShot(torchOff);
            lightTorch.SetActive(false);
        }
        else
        {
            audioSource.PlayOneShot(torchOn);
            lightTorch.SetActive(true);
        }
        
        torchActive = !torchActive;
    }
}
