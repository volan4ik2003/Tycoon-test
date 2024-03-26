using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject[] cars;
    int carIndex;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    void SpawnCar() 
    {
        carIndex = Random.Range(0, cars.Length);
        Instantiate(cars[carIndex], spawnPoint);
    }

    IEnumerator Spawner() {
        yield return new WaitForSeconds(5f);
        SpawnCar();
        StartCoroutine(Spawner());
    }

}
