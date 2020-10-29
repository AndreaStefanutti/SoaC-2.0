using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject theEnemy;
    public float xPos;
    public float zPos;
    public int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EnemyDrop()
    {
        while(enemyCount < 100)
        {
            xPos = Random.Range(30, 20);
            zPos = Random.Range(0, -63);
            Instantiate(theEnemy, new Vector3(xPos, 0, zPos), Quaternion.identity);
            xPos = Random.Range(30, 20);
            zPos = Random.Range(-62, -54);
            Instantiate(theEnemy, new Vector3(xPos, 0, zPos), Quaternion.identity);
            xPos = Random.Range(-55,-65);
            zPos = Random.Range(0, -63);
            Instantiate(theEnemy, new Vector3(xPos, 0, zPos), Quaternion.identity);
            xPos = Random.Range(-55, -65);
            zPos = Random.Range(-62, -54);
            Instantiate(theEnemy, new Vector3(xPos, 0, zPos), Quaternion.identity);
            yield return new WaitForSeconds(5f);
            enemyCount += 1;
        }
    }
}
