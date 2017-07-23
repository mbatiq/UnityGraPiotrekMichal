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
        hasInteracted = false;
        this.playerAgent = playerAgent;
        playerAgent.stoppingDistance = 3f;
        playerAgent.destination = transform.position;
    }

    private void Update()
    {
        //tutaj ruch przejmuje obiekt Interactable nad postacią. 
        //Trzeba zamieścic flagę/metodę która zatrzyma przyciski klawiatury wykonywane w Update "WorldInteraction
        //pobrany jest stamtąd playerAgent. 
        //Brakuje dojścia do colldera.
        //Wrzucam dodatkowy obiekt do sceny. Kostkę z rotacją to co wcześniej nie przeszło.
        if (!hasInteracted && playerAgent != null && !playerAgent.pathPending)
        {
            playerAgent.GetComponent<WorldInteraction>().grounded = false;
            if (playerAgent.remainingDistance <= playerAgent.stoppingDistance)
            {
                Interact();
                hasInteracted = true;
                playerAgent.GetComponent<WorldInteraction>().grounded = true;
            }
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Interact() with base class");
    }

}
