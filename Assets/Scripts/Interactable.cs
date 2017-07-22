using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Interactable : MonoBehaviour {
    [HideInInspector]
    
    public NavMeshAgent playerAgent;

    public bool hasInteracted;


    public virtual void MoveToInteraction(NavMeshAgent playerAgent)
    {
        this.playerAgent = playerAgent;

        if (!hasInteracted && playerAgent != null && !playerAgent.pathPending)
        {
            playerAgent.GetComponent<WorldInteraction>().grounded = false;
            if (playerAgent.remainingDistance <= playerAgent.stoppingDistance)
            {
                hasInteracted = true;
                playerAgent.GetComponent<WorldInteraction>().grounded = true;
            }
        }
    }

    private void Update()
    {

        Interact();
    }

    public virtual void Interact()
    {
        Debug.Log("Interact() with base class");
    }

}
