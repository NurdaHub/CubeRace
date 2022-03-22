using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    private Vector3 spawnPosition = new Vector3(-40, 0, 0);
    private Vector3 destination;
    private float moveSpeed = 0.5f;
    private float speedBalancer = 0.1f;

    public void Init(float distance, float _moveSpeed)
    {
        transform.position = spawnPosition;
        destination = new Vector3(transform.position.x + distance, 0, 0);
        moveSpeed = _moveSpeed;
    }
    
    private void Update()
    {
        DestinationHasReached();
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * speedBalancer);
    }

    private void DestinationHasReached()
    {
        if (transform.position == destination)
            gameObject.SetActive(false);
    }
}
