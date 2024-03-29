using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 1f;

    private void OnEnable() {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable() {
        CancelInvoke(nameof(Spawn));
    }
    
    private void Spawn() {
        GameObject rocks = Instantiate(prefab, transform.position, Quaternion.identity);
        rocks.transform.position += Vector3.up;
    }
}
