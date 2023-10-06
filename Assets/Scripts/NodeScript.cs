using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour
{
    public static int CAPACITY = 3;
    public int currentCap = 0;

    public void assignWorker()
    {
        if (currentCap < CAPACITY)
        {
            currentCap++;
        }
    }
}
