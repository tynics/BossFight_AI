using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TornadoBehaviour : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.position;

        
        timer += Time.deltaTime;
        if(timer >= 10)
        {
            Destroy(gameObject);
        }
    }

}
