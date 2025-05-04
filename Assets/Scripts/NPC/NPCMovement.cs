using System.Collections;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float waitTimeAtPoint = 2f;

    private int currentWaypointIndex = 0;
    private Coroutine moveCoroutine;

    private void Start()
    {
        moveCoroutine = StartCoroutine(MoveNPC());
    }

    private IEnumerator MoveNPC()
    {
        while (true)
        {
            Transform targetWaypoint = waypoints[currentWaypointIndex];

            while (Vector3.Distance(transform.position, targetWaypoint.position) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);
                yield return null;
            }

            yield return new WaitForSeconds(waitTimeAtPoint);

            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    public void StopMovement()
    {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
            moveCoroutine = null;
        }
    }

    public void ResumeMovement()
    {
        if (moveCoroutine == null)
        {
            moveCoroutine = StartCoroutine(MoveNPC());
        }
    }
}