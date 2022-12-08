using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameHandler : MonoBehaviour
{
    public GameObject pantallaInicio;
    public GameObject pantallaGanar;
    public GameObject playInterface;

    public TMPro.TMP_Text username_input;
    public Text username_label;
    public string username;

    //MOVIMIENTO DEL JUGADOR
    public Animator animController;
    public GameObject target;
    public GameObject ground;
    public float velocidad;
    public float velRotation;

    public bool targetFound;
    public float InputX;
    public float InputZ;

    // Start is called before the first frame update
    void Start() {
        targetFound = false;
    }

    void Update()
    {
        if(targetFound){
            PlayerMoveAndRotation();
        }
    }

    void PlayerMoveAndRotation() {
        animController.SetFloat("X",InputX);
        animController.SetFloat("Y",InputZ);

        target.transform.Rotate(0, InputX * Time.deltaTime * velRotation, 0);
        target.transform.Translate(0, 0, InputZ * Time.deltaTime * velocidad);
	}

    public void trakingFound(){
        targetFound = true;
    }


    public void StartTheGame(){
        pantallaInicio.SetActive(false);
        pantallaGanar.SetActive(false);
        username = username_input.text;
        
        enableControls();
        username_label.text = "Jugador: " + username;
    }

    public void enableControls(){
        playInterface.SetActive(true);
    }
}
