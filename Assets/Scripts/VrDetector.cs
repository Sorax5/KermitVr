using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Management;

public class VrDetector : MonoBehaviour
{
    
    [SerializeField] private GameObject xrOrigin;
    [SerializeField] private GameObject desktopOrigin;
    
    // Start is called before the first frame update
    void Start()
    {
        var xrSettings = XRGeneralSettings.Instance;
        
        if (xrSettings == null)
        {
            Debug.LogError("No XRGeneralSettings found in the scene.");
            return;
        }
        
        var xrManager = xrSettings.Manager;
        
        if (xrManager == null)
        {
            Debug.LogError("No XRManager found in XRGeneralSettings.");
            return;
        }
        
        var xrLoader = xrManager.activeLoader;
        
        if (xrLoader == null)
        {
            Debug.Log("No XRLoader found in XRManager.");
            xrOrigin.SetActive(false);
            desktopOrigin.SetActive(true);
            return;
        }
        
        Debug.Log("XRLoader name: " + xrLoader.name);
        xrOrigin.SetActive(true);
        desktopOrigin.SetActive(false);
        
        

    }
}
