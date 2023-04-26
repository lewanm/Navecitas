using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Navecitas.Variables;
using System.Threading.Tasks;

public class gameController : MonoBehaviour
{
    [SerializeField] FloatReference timer;
    [SerializeField] GameObject spawnersContainer;
    GameObject[] spawners;

    // Start is called before the first frame update
    void Start()
    {
        timer.Value = 0;
        Application.targetFrameRate = 60;

        spawners = new GameObject[spawnersContainer.transform.childCount];

        for(int i = 0; i < spawners.Length; i++ )
        {
            spawners[i] = spawnersContainer.transform.GetChild(i).gameObject;
        }

        ActivateSpawner();

    }

    // Update is called once per frame
    void Update()
    {
        timer.Value += Time.deltaTime;

    }



    async void ActivateSpawner()
    {
        foreach (GameObject spawner in spawners)
        {
            SpawnerController sc = spawner.GetComponent<SpawnerController>();
            //Debug.Log($"Nombre: {spawner.name} // tiempo de spawn: {sc.TimeToSpawn()}");
            //No sirve el Invoke para esto :(
            //Invoke("ActivateSpawner", 5f);

            await Task.Delay(sc.TimeToSpawn() * 1000);
            spawner.SetActive(true);

        }
    }
}
