using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public float speed = 5f;
    private float leftEdge;
    private void Start() {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x -2f;
    }

    void Update()
    {
        float distanceTravelled = FindObjectOfType<GameManager>().distanceTravelled;
        float distanceMultiplier = (float)(distanceTravelled * 0.01f > 0.5f  ? 0.5f : distanceTravelled * 0.01f) + 1f;
        transform.position += Vector3.left * speed * Time.deltaTime * distanceMultiplier;
        if (transform.position.x < leftEdge) {
            Destroy(gameObject);
        }
    }
}
