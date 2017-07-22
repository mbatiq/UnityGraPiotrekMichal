using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldInteraction : MonoBehaviour {

    public bool grounded = true;
    public float SilaSkoku = 5;
    Rigidbody rb;
    public float SzybkoscPrzodTyl = 0.5f;
    public float SzybkoscObrotKlawiszami = 75f;

    public bool hasInteracted;

    NavMeshAgent playerAgent;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAgent = GetComponent<NavMeshAgent>(); 
    }
    IEnumerator SetGrounded()
    {
        yield return new WaitForSeconds(1);
        grounded = true;
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
            {
            grounded = false;

            if (playerAgent.enabled != false) playerAgent.enabled = false;
            
            rb.AddForce(0, 250 * SilaSkoku , 0);
            if (rb.useGravity == false) rb.useGravity = true;
            grounded = false;
            StartCoroutine("SetGrounded");
        }
    }
    // Update is called once per frame
    void Update () {


        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (Input.GetButton("Horizontal"))
        {
            if (playerAgent.enabled != false)
            {
                playerAgent.enabled = true;
                if (playerAgent.isStopped != true) playerAgent.isStopped = true;
            }
            transform.Rotate(new Vector3(0, h * SzybkoscObrotKlawiszami, 0));

        }
        if (Input.GetButton("Vertical"))
        {
            if (playerAgent.enabled != false)
            {
                playerAgent.enabled = true;
                if (playerAgent.isStopped != true) playerAgent.isStopped = true;
            }

            transform.Translate(new Vector3(0, 0, v * SzybkoscPrzodTyl * Time.deltaTime));
        }
        
		if(Input.GetMouseButtonDown(0) && grounded == true && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            if (playerAgent.enabled == false) playerAgent.enabled = true;

            if (playerAgent.isStopped == true) playerAgent.isStopped = false;

            GetInteracion();
        }
	}

    void GetInteracion()
    {

        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition); // punkt startowy nacisniecia myszką w świecie
        RaycastHit InteractionInfo; // informacje na co kliknelismy takie jak pozycja i inne
        if(Physics.Raycast(interactionRay,out InteractionInfo, Mathf.Infinity)) //Mathf.Infinity dlugosc promienia Raycast zwraca prawde kiedy promien przecina obiekt z colliderem
        {
            GameObject interactedObject = InteractionInfo.collider.gameObject;
            if(interactedObject.tag == "Interatable Object")
            {
                Debug.DrawLine(interactionRay.origin, InteractionInfo.point);

                interactedObject.GetComponent<WorldInteraction>();

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
            else
            {
                playerAgent.stoppingDistance = 0f;
                Debug.DrawLine(interactionRay.origin, InteractionInfo.point);
                playerAgent.destination = InteractionInfo.point;
            }
        }
    }
}
