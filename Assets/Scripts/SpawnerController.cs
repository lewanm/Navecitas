using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class SpawnerController : MonoBehaviour
{

    [SerializeField] GameObject[] enemyList;
    [SerializeField] float spawningCd;
    [SerializeField] bool toTheRight;
    [SerializeField] float spawnerSpeed;
    [SerializeField] int timeToSpawn;

    // Start is called before the first frame update
    void Awake()
    {
        
        SpawnEnemy();
    }

    void Update()
    {
        Move();
    }

    public int TimeToSpawn() {
        return timeToSpawn;
    }

    async void SpawnEnemy()
    {
        foreach(GameObject enemy in enemyList)
        {
            Instantiate(enemy, transform.position, Quaternion.Euler(0, 0, 0));
            float randomNumber = Random.Range(spawningCd * 0.2f, spawningCd * 2f);
            await Task.Delay(Mathf.RoundToInt(randomNumber));
        }

        gameObject.SetActive(false);
    }

    void Move()
    {
        transform.Translate(spawnerSpeed * Time.deltaTime * (toTheRight ? 1 : -1), 0, 0);
    }
}
