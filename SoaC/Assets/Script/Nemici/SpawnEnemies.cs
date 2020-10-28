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
            xPos = Random.Range(40, 36);
            zPos = Random.Range(-13, 20);
            Instantiate(theEnemy, new Vector3(xPos, 0, zPos), Quaternion.identity);
            xPos = Random.Range(5, -17);
            zPos = Random.Range(18, 20);
            Instantiate(theEnemy, new Vector3(xPos, 0, zPos), Quaternion.identity);
            xPos = Random.Range(-18,-22);
            zPos = Random.Range(18, -26);
            Instantiate(theEnemy, new Vector3(xPos, 0, zPos), Quaternion.identity);
            Instantiate(theEnemy, new Vector3(xPos, 0, zPos), Quaternion.identity);
            yield return new WaitForSeconds(5f);
            enemyCount += 1;
        }
    }
}
