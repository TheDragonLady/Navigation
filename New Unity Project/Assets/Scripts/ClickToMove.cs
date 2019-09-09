using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// This line will make sure one player doesn't have more than one ClickToMove script
[DisallowMultipleComponent]
// This line will make it so Unity automatically add a NavMeshAgent to the player
[RequireComponent(typeof(NavMeshAgent))]

public class ClickToMove : MonoBehaviour
{

    // This variable will hold the 3d position of where we are going.
    private Vector3 targetPosition;

    // The NavMeshAgent will do all the magic when we get there.
    NavMeshAgent meshAgent;

    /// 
    /// Here we will set our variables.
    /// 
    void Awake()
    {
        meshAgent = GetComponent<NavMeshAgent>();
    }

    /// 
    /// This method will run when we initiate our class.
    /// 
    void Start()
    {
        // Set the default position of our target to the player.
        targetPosition = transform.position;
    }

    /// 
    /// This method runs every frame and will check for player input and
    /// if we should move the player.
    /// 
    void Update()
    {
        // Check if the player is trying to move.
        if (Input.GetMouseButton(0)) // 0 = Left mouse button.
        {
            // The player clicked or is holding down the left mouse button.
            SetTargetPosition();
        }

        // We run MovePlayer() on every frame.
        MovePlayer();
    }

    /// 
    /// This method will set the position we want the player to move to.
    /// 
    void SetTargetPosition()
    {
        // Set up the plane and where the player is right no
        Plane plane = new Plane(Vector3.up, transform.position);
        // We then create a ray and set it to wherever the player clicked
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float point = 0f;

        // If the position where the player clicked is somewhere in the plane we
        // will set targetPosition.
        if (plane.Raycast(ray, out point))
        {
            // We put this point into our Vector3.
            targetPosition = ray.GetPoint(point);
        }
    }

    /// 
    /// This method will move the player in the target direction, the player will
    /// stop when ever they reach their destination.
    /// 
    void MovePlayer()
    {
        // Since our meshAgent will handle the movement we just have to set the
        // destination and the rest will be taken care of by the meshAgent.
        meshAgent.SetDestination(targetPosition);

        // This is optional, just to display a blue line to where the player is
        // going. It makes it easier to see the result.
        Debug.DrawLine(transform.position, targetPosition, Color.blue);
    }
}