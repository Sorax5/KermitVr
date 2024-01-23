using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public enum QteType
{
    Single,
    Multiple
}

public class QTESystem : MonoBehaviour
{
    private QteType qteType = QteType.Single;
    public float qteDuration = 5f;
    public Canvas canvas;
    public TMPro.TMP_Text text;

    private bool qteActive = false;
    private int currentTouchIndex = 0;
    private float timer = 0f;
    private char[] qteSequence;

    private int numberOfTouches = 1;

    void Update()
    {
        if (qteActive)
        {
            timer += Time.deltaTime;
            if(timer >= qteDuration)
            {
                QTEFailed();
            }

            if (qteType == QteType.Single)
            {
                UpdateSingleQTE();
            }
        }
    }

    private void Start()
    {
        StartQTE();
    }

    void StartQTE()
    {
        // G�n�rer la s�quence QTE
        GenerateQTESequence();

        // D�marrer le QTE en fonction du type
        if (qteType == QteType.Single)
        {
            StartSingleQTE();
        }
    }

    void UpdateSingleQTE()
    {
        if (Keyboard.current.anyKey.wasPressedThisFrame)
        {
            if (Keyboard.current[KeyFromChar(qteSequence[currentTouchIndex])].wasPressedThisFrame)
            {
                QTECompleted();
            }
            else
            {
                QTEFailed();
            }
        }
    }

    void StartSingleQTE()
    {
        Debug.Log($"QTE unique d�marr� ! Appuyez sur la touche '{qteSequence[currentTouchIndex]}' avant {qteDuration} secondes.");
        qteActive = true;
        timer = 0f;
        canvas.gameObject.SetActive(true);
        text.text = qteSequence[currentTouchIndex].ToString();
    }

    void QTECompleted()
    {
        Debug.Log("QTE r�ussi !");
        StartCoroutine(ResetCoroutine(Color.green));
    }

    void QTEFailed()
    {
        Debug.Log("QTE �chou� !");
        StartCoroutine(ResetCoroutine(Color.red));
    }

    private IEnumerator ResetCoroutine(Color color)
    {
        text.color = color;

        yield return new WaitForSeconds(2);

        ResetQTE();
    }

    void ResetQTE()
    {
        qteActive = false;
        currentTouchIndex = 0;
        timer = 0f;
        canvas.gameObject.SetActive(false);
        text.text = "";
        Debug.Log("QTE r�initialis�.");
    }

    void GenerateQTESequence()
    {
        qteSequence = new char[numberOfTouches];
        for (int i = 0; i < numberOfTouches; i++)
        {
            qteSequence[i] = GenerateRandomQTE();
        }
    }

    char GenerateRandomQTE()
    {
        char[] possibleKeys = { 'a', 'e', 'f', 'c' };
        int randomIndex = Random.Range(0, possibleKeys.Length);
        return possibleKeys[randomIndex];
    }

    Key KeyFromChar(char character)
    {
        // Ajoutez des correspondances pour d'autres touches si n�cessaire
        switch (character)
        {
            case 'a': return Key.Q;
            case 'e': return Key.E;
            case 'f': return Key.F;
            case 'c': return Key.C;
            default: return Key.None;
        }
    }
}
