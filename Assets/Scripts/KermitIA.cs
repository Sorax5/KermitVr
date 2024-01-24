using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KermitIA : MonoBehaviour
{
    public bool isStarted = false;
    private bool isStuck = false;
    private float stuckTime = 0;

    public GameObject kermit;
    public GameObject player;

    void Start()
    {

    }

    void Update()
    {
        Debug.Log(distanceToPlayerNoY());
        if (distanceToPlayerNoY() < 20)
        {
            if (!isStarted)
            {
                isStarted = true;
            }
        }
        
        if (isStarted)
        {
            if (distanceToPlayerNoY() < 2)
            {
                this.Attack();
            }
            else if (distanceToPlayerNoY() > 40)
            {
                this.MoveRandomly();
            }
            else
            {
                this.MoveTowardsPlayerWithObstacleAvoidance();
            }
        }
    }

    private float distanceToPlayerNoY()
    {
        float distanceY = Mathf.Abs(player.transform.position.y - kermit.transform.position.y);

        if (distanceY > 2 || distanceY < -2)
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
        kermit.transform.LookAt(player.transform);
        kermit.transform.position = new Vector3(
            player.transform.position.x + Random.Range(-5, 5),
            player.transform.position.y,
            player.transform.position.z + Random.Range(-5, 5)
        );
    }

    private void MoveTowardsPlayerWithObstacleAvoidance()
    {
        RaycastHit hit;
        if (Physics.Raycast(kermit.transform.position, kermit.transform.forward, out hit, 3f))
        {
            if (!isStuck)
            {
                isStuck = true;
                stuckTime = 20;
            }
            kermit.transform.Rotate(Vector3.up, 45f);
        } 
        else if (isStuck)
        {
            stuckTime--;
            kermit.transform.position += kermit.transform.forward * 0.1f;
            if (stuckTime <= 0)
            {
                isStuck = false;
            }
        }
        else
        {
            this.MoveTowardsPlayer();
        }
    }

    private void MoveTowardsPlayer()
    {
        if (Random.Range(0, 100) < 5)
        {
            this.Fall();
        }
        else
        {
            kermit.transform.LookAt(player.transform);
            kermit.transform.position += kermit.transform.forward * 0.1f;
        }
    }

    private void Fall()
    {

    }

    private void Attack()
    {
        // Attaquer le joueur
    }
}