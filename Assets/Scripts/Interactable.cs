using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Interactable : MonoBehaviour {
    [HideInInspector]
    
    public NavMeshAgent playerAgent;


    public virtual void MoveToInteraction(NavMeshAgent playerAgent)
    {
        this.playerAgent = playerAgent;
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
