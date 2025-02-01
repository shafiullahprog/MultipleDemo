using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject spawnPoint, endPoint;
    [SerializeField] float timeInterval;

    [SerializeField] Transform minY, maxY;
    [SerializeField] float minX, maxX;
    [SerializeField] float distance;

    private Vector3 lastSpawnPosition;

    public void SpawnStage()
    {
        GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            float gap = Random.Range(minX, maxX);
            float height = Random.Range(minY.position.y, maxY.position.y);
            Vector3 newPosition = lastSpawnPosition + new Vector3(distance + gap, height, 0);

            bullet.transform.position = newPosition;
            bullet.transform.rotation = spawnPoint.transform.rotation;
            bullet.SetActive(true);

            lastSpawnPosition.x = newPosition.x;

            StartCoroutine(DisableWhenOutOfView(bullet));
        }
    }

    private void Start()
    {
        lastSpawnPosition = spawnPoint.transform.position;
        StartCoroutine("spawnGround", 2);
    }

    IEnumerator spawnGround()
    {
        SpawnStage();
        yield return new WaitForSeconds(timeInterval);
        StartCoroutine(spawnGround());
    }
    private IEnumerator DisableWhenOutOfView(GameObject obj)
    {
        while (obj.activeSelf)
        {
            if (obj.transform.position.x < endPoint.transform.position.x)
            {
                obj.SetActive(false);
                yield break;
            }
            yield return null;
        }
    }
}

