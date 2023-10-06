using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Worker : MonoBehaviour
{
    private BaseScript mainBase;
    public NodeScript node;
    private Movement movement;

    // Mineral Farming
    private bool isInsideTrigger = false;
    private float timeInsideTrigger = 0.0f;
    private float triggerTimeThreshold = 5.0f;
    private bool collected = false;
    void Start()
    {
        movement = GetComponent<Movement>();
    }
    void Update()
    {
        if (node != null && mainBase != null)
        {
            // Movement Setting
            if (collected == false)
            {
                movement.setTarget(node.transform.position);
            }
            else
            {
                movement.setTarget(mainBase.transform.position);

                float distance = Vector2.Distance(transform.position, mainBase.transform.position);
                if (distance < 1)
                {
                    collected = false;
                }
            }  
            
            // Collecting Resource Timer
            if (isInsideTrigger)
            {
                timeInsideTrigger += Time.deltaTime;

                if (timeInsideTrigger >= triggerTimeThreshold)
                {
                    // Worker has been inside the trigger for 10 seconds or more
                    collected = true;
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Mineral"))
        {
            isInsideTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Mineral"))
        {
            timeInsideTrigger = 0.0f;
            isInsideTrigger = false;
        }
    }

    public void assignBase(BaseScript t_base)
    {
        mainBase = t_base;
    }

    public void assignNode(NodeScript t_node)
    {
        node = t_node;
    }

    public bool getWorking()
    {
        return node != null;
    }
}
