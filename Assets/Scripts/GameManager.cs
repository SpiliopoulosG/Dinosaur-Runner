using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public float distanceTravelled;
    public TextMeshProUGUI distanceTravelledText;
    public GameObject playButton;
    public GameObject gameOver;
    private bool gameOn = false;


    private void Update() {
        if (gameOn) {
            IncreaseScore();
        } 

        if (Input.GetMouseButtonDown(0))
        {
            if (gameOn) {
                return;
            } 
        
            if (Time.timeScale == 1) {
                Pause();
            } else {
                Play();
            }
        }
    }


    private void Awake() {
        Application.targetFrameRate = 60;
        Time.timeScale = 0;
    }

    public void Play() {
        gameOn = true;
        distanceTravelled = 0;
        distanceTravelledText.text = distanceTravelled.ToString();
        gameOver.SetActive(false);
        playButton.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;

        Rock[] rocks = FindObjectsOfType<Rock>();
        for (int i=0; i < rocks.Length; i++) {
            Destroy(rocks[i].gameObject);
        }
    }

    public void Pause() {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void IncreaseScore() {
        float distanceMultiplier = (float)(distanceTravelled * 0.01f > 0.5f ? 0.5f : distanceTravelled * 0.01f) + 1f;
        distanceTravelled += 5f * Time.deltaTime * distanceMultiplier;
        distanceTravelledText.text = distanceTravelled.ToString("#.00");
    }

    public void GameOver() {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        gameOn = false;
        Pause();
    }
}
