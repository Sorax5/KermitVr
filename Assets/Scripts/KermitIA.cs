using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KermitIA : MonoBehaviour
{
    public bool isStarted = false;

    public GameObject kermit;

    public GameObject player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (distanceToPlayerNoY() > 20)
        {
            if (!isStarted)
            {
                isStarted = true;
            }
        }
        else if (isStarted)
        {
            if (distanceToPlayerNoY() < 2)
            {
                this.Attack();
            }
            else if (distanceToPlayerNoY() > 100)
            {
                this.MoveRandomly();
            }
            else
            {
                this.MoveTowardsPlayer();
            }
        }
        else
        {
            // move randomly
        }
    }

    private float distanceToPlayerNoY()
    {
        float distanceY = Mathf.Abs(player.transform.position.y - kermit.transform.position.y);
        Debug.Log(distanceY);

        if (distanceY > 2)
        {
            return 1000;
        }
        else if (distanceY < -2)
        {
            return 1000;
        }
        else
        {
            return Vector3.Distance(player.transform.position, kermit.transform.position);
        }
    }

    private void MoveRandomly()
    {
        // move randomly
    }

    private void MoveTowardsPlayer()
    { 
        if (Random.Range(0, 100) < 5)
        {
            this.Fall();
        } else
        {
            kermit.transform.LookAt(player.transform);
            kermit.transform.position += kermit.transform.forward * 0.1f;
        }
    }

    private void Attack()
    {
        // attack
    }

    private void Fall()
    {
        // fall
    }

}
