using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] private GameObject prefabObstacles; 
    [SerializeField] private float speed = 5f; 
    [SerializeField] private float spawnTime = 2f; 
    [SerializeField] private float negativeAreaY = -1f;
    [SerializeField] private float positiveAreaY = 3f; 
    [SerializeField] private float positionSpawnX = 11f; 
    [SerializeField] private float positionSpawnZ = -1.5f; 

    private void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    private void MoveObstacles()
    {
        float posicionY = Random.Range(negativeAreaY, positiveAreaY);  
        Vector3 posicionSpawn = new Vector3(positionSpawnX, posicionY, positionSpawnZ);  
        GameObject clone = Instantiate(prefabObstacles, posicionSpawn, Quaternion.identity); 
        Rigidbody rb = clone.GetComponent<Rigidbody>(); 
        rb.AddForce(Vector3.left * speed, ForceMode.Impulse); 
    }

    IEnumerator SpawnObstacles()
    {
        while (true) 
        {
            MoveObstacles();
            yield return new WaitForSeconds(spawnTime); 
        }
    }
}
