using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Movement playerMovement;
    public PlacementScript placementScript;

    void Start()
    {
        playerMovement = gameObject.GetComponent<Movement>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            playerMovement.setTarget(targetPosition);           
        }
    }
}
