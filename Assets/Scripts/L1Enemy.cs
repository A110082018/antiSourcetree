using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1Enemy : MonoBehaviour
{
    private float L1EnemyHP = 100f;

    private GameObject focusPlayer;
    public float FindPlayerminiDist = 9999;

    void Start()
    {
        
    }

    void Update()
    {
        FindPlayer();
    }

    public void FindPlayer()
    {
        // find target
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        
        foreach (GameObject Player in players)
        {
            float d = Vector3.Distance(transform.position, Player.transform.position);

            if (d < FindPlayerminiDist)
            {
                FindPlayerminiDist = d;
                focusPlayer = Player;
            }
        }
        //focus enemy
        if (focusPlayer)
        {
            var targetRotation = Quaternion.LookRotation(focusPlayer.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 20 * Time.deltaTime);
        }
    }

    // be hit by bullet
    private void OnTriggerEnter(Collider other)
    {
        // collision by "Bullet"
        if (other.tag == "Bullet")
        {
            Bullet bullet = other.GetComponent<Bullet>();
            L1EnemyHP -= bullet.atk;
            if (L1EnemyHP <= 0)
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}
