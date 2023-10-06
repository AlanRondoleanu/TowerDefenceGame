using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    public NodeScript[] nodes;
    private Worker[] workers ;
    public Transform spawnPoint;
    public GameObject workerPrefab;

    void Start()
    {
        nodes = FindObjectsOfType<NodeScript>();
        workers = new Worker[0];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && workers.Length != 0)
        {
            foreach (Worker worker in workers)
            {
                WorkerAssignWork(worker);
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            // Create new worker
            Worker newWorker = Instantiate(workerPrefab, spawnPoint.position, Quaternion.identity).GetComponent<Worker>();
            newWorker.assignBase(this);
            WorkerAssignWork(newWorker);

            // Add Worker to Array
            workers.Append(newWorker);
        }
    }
    void WorkerAssignWork(Worker t_worker)
    {
        if (t_worker.getWorking() == false)
        {
            foreach (NodeScript node in nodes)
            {
                if (node.currentCap <= 0)
                {
                    t_worker.assignNode(node);
                }
            }
        }
    }
}
