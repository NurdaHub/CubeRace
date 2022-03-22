using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public CubeMovement cubePrefab;

    private int cubesCount = 5;
    private float delay = 1;
    private float distance = 1;
    private float moveSpeed = 0.5f;
    private Pool<CubeMovement> cubePool;

    private void Start()
    {
        cubePool = new Pool<CubeMovement>(cubePrefab, cubesCount, transform);
    }

    public void SpawnNewCube(float _delay, float _distance, float _moveSpeed)
    {
        delay = _delay;
        distance = _distance > 0 ? _distance : distance;
        moveSpeed = _moveSpeed > 0 ? _moveSpeed : moveSpeed;
        StartCoroutine(SpawnWithDelay());
    }

    private IEnumerator SpawnWithDelay()
    {
        yield return new WaitForSeconds(delay);
        
        var currentCube = cubePool.GetFreeElement();
        currentCube.Init(distance, moveSpeed);
    }
}
