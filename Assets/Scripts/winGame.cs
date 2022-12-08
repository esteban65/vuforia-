using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class winGame : MonoBehaviour
{
    private audioController audioHandler;

    private void Start() {
        audioHandler = GameObject.Find("audioController").GetComponent<audioController>();
    }

    private void OnCollisionEnter(Collision other) {
        if(other.collider.CompareTag("Finish")){
            audioHandler.win();

            SceneManager.LoadScene("SampleScene");
            Time.timeScale = 0;
        }
    }
}
