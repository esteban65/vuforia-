using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tiempo : MonoBehaviour
{
    [SerializeField] int min, seg;
    [SerializeField] Text tiempo;
    private audioController audioHandler;

    private float restante;
    private bool enMarcha;
    private bool targetFound;
    // public GameObject gameOver;

    private void Start() {
        targetFound = false;
        Time.timeScale = 1;
        audioHandler = GameObject.Find("audioController").GetComponent<audioController>();
    }

    private void Awake() {
        restante = (min * 60) + seg;
    }


    // Update is called once per frame
    void Update() {
        if (enMarcha) {
            if (Time.timeScale != 0) {
                restante -= Time.deltaTime;
                if (restante < 1) {
                    enMarcha = false;
                    // gameOver.SetActive(true);
                    // gameHandler.GetComponent<AudioSource>().loop = false;
                    audioHandler.dead();

                    SceneManager.LoadScene("SampleScene");
                    Time.timeScale = 0;
                }

                int tempMin = Mathf.FloorToInt(restante / 60);
                int tempSeg = Mathf.FloorToInt(restante % 60);
                tiempo.text = string.Format("{00:00}:{01:00}", tempMin, tempSeg);

            }
        }
    }
    
    public void trakingFound() {
        targetFound = true;
        enMarcha = true;
    }
}