using NavMeshPlus.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.AI;
using UnityEngine;

public class PlacementScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public NavMeshSurface surface;
    public GameObject building;
    private bool blocked = true;
    private bool buildingMode = false;

    public float gridSize = 0.5f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();     
    }
    void Update()
    {
        if (buildingMode == false)
        {
            spriteRenderer.enabled = false;
        }
        else
        {
            spriteRenderer.enabled = true;

            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 snappedPosition = new Vector2(Mathf.Round(pos.x / gridSize) * gridSize,
                                                 Mathf.Round(pos.y / gridSize) * gridSize);
            transform.position = snappedPosition;
        }

        if (Input.GetMouseButtonDown(0) && buildingMode == true)
        {
            if (getBlocked() == false)
            {
                placeBuilding();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.tag != null)
        {
            spriteRenderer.color = Color.red;
            blocked = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.color = Color.green;
        blocked = false;
    }

    public void placeBuilding()
    {
        Instantiate(building, transform.position, transform.rotation);
        surface.BuildNavMesh();
    }

    public bool getBlocked()
    {
        return blocked;
    }

    public void enableBuilding()
    {
        buildingMode = true;
        Debug.Log("Building On");
    }

    public void disableBuilding()
    {
        buildingMode = false;
        spriteRenderer.enabled = false;
        Debug.Log("Building Off");
    }

}

