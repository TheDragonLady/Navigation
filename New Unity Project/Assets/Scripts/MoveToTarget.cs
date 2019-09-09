using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToTarget : MonoBehaviour
{
    public List<Transform> target;
    private NavMeshAgent nav;
    private int currentDestination = 0;
    public float targetDistanceThreshold;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        if (nav.remainingDistance< targetDistanceThreshold)
        {
            SetNewDestination();
        }

        
    }

    private void SetNewDestination()
    {
        currentDestination++;

        if(currentDestination > target.Count-1)
        {
            currentDestination = 0;
        }

        nav.SetDestination(target[currentDestination].position);
    }


}
