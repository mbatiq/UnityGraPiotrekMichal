using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // potrzebna bibioteka do NavMeshAgent

public class Monster : MonoBehaviour
{
    /* Obiekt Monter otagowałem tagiem Interetable Object <-- to jest wazne
    dzięki temu ta klasa wykona sie zawsze po mimo tego ze nie ma podpięcia do sceny.
    dalej tworzymy w klasie /wilk i tak definiujemy podejscie wilka do gracza, parametry.
    Szkic z ktorego bedziemy trzyrzyli juz nowe monstraaaaaaa...

    w projekcie jako czerwona kostka
     */

    //to nas, to co tu jest nie interesuje tworzymy dziedziczenie po tej klasie np: wilk
    // i dziedziczymy funkcje z Monster
    [HideInInspector]
    public NavMeshAgent playerAgent;
    private bool hasInteracted;

    public virtual void MoveToInteraction(NavMeshAgent playerAgent)
    {
        hasInteracted = false;
        this.playerAgent = playerAgent;
        playerAgent.stoppingDistance = 3f;
        playerAgent.destination = transform.position;

    }
    private void Update()
    {
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
        Debug.Log("Interact() with base class Monster");
    }
}
