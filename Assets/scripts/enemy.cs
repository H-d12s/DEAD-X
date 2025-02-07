using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{[SerializeField]  Transform target;
NavMeshAgent agent;
        void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
         Vector3 direction = target.position - transform.position; // Get direction to player
    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Convert to angle
    transform.rotation = Quaternion.Euler(0, 0, angle); // Rotate enemy
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "player")
        {
            agent.SetDestination(target.position);
        }
    }
}
