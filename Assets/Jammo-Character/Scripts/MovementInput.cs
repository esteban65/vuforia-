
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script requires you to have setup your animator with 3 parameters, "InputMagnitude", "InputX", "InputZ"
//With a blend tree to control the inputmagnitude and allow blending between animations.
[RequireComponent(typeof(CharacterController))]
public class MovementInput : MonoBehaviour {

    public float Velocity;
    [Space]

	public float InputX;
	public float InputZ;
	public Vector3 desiredMoveDirection;
	public bool blockRotationPlayer;
	public float desiredRotationSpeed = 0.1f;
	public Animator anim;
	public float Speed;
	public float allowPlayerRotation = 0.1f;
	public Camera cam;
	public CharacterController controller;
	public bool isGrounded;

    [Header("Animation Smoothing")]
    [Range(0, 1f)]
    public float HorizontalAnimSmoothTime = 0.2f;
    [Range(0, 1f)]
    public float VerticalAnimTime = 0.2f;
    [Range(0,1f)]
    public float StartAnimTime = 0.3f;
    [Range(0, 1f)]
    public float StopAnimTime = 0.15f;

    public float verticalVel;
    public float horizontalVel;
    private Vector3 moveVector;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();
		cam = Camera.main;
		controller = this.GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		InputMagnitude ();

        // isGrounded = controller.isGrounded;
        // if (isGrounded)
        // {
        //     verticalVel -= 0;
        // }
        // else
        // {
        //     verticalVel -= 1;
        // }
        // moveVector = new Vector3(horizontalVel* .2f * Time.deltaTime, verticalVel * .2f * Time.deltaTime, 0);
        // controller.Move(moveVector);
		
		if (Input.GetKey(KeyCode.RightArrow)){
			transform.position += Vector3.right * Speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.LeftArrow)){
			transform.position += Vector3.left* Speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.UpArrow)){
			transform.position += Vector3.forward * Speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.DownArrow)){
			transform.position += Vector3.back* Speed * Time.deltaTime;
		}
		transform.rotation.Set(transform.rotation.x,0f,transform.rotation.z,transform.rotation.w);
		transform.position.Set(transform.position.x,-0.494f,transform.position.z);
		
		// if (Input.GetKey(KeyCode.RightArrow)){
        // float horiz = Input.GetAxisRaw("Horizontal") * Speed * Time.deltaTime;
        // float verti = Input.GetAxisRaw("Vertical") * Speed * Time.deltaTime;
		// Vector3 move = new Vector3(horiz,0f,verti);
        // controller.Move(move);
		// }
		// if (Input.GetKey(KeyCode.LeftArrow)){
        // controller.Move(Vector3.left* Speed * Time.deltaTime);
		// }
		// if (Input.GetKey(KeyCode.UpArrow)){
        // controller.Move(Vector3.forward* Speed * Time.deltaTime);
		// }
		// if (Input.GetKey(KeyCode.DownArrow)){
        // controller.Move(Vector3.back* Speed * Time.deltaTime);
		// }
		
		// PlayerMoveAndRotation();

    }

    void PlayerMoveAndRotation() {
		InputX = Input.GetAxis ("Horizontal");
		InputZ = Input.GetAxis ("Vertical");

		var camera = Camera.main;
		var forward = cam.transform.forward;
		var right = cam.transform.right;

		forward.y = 0f;
		right.y = 0f;

		forward.Normalize ();
		right.Normalize ();

		desiredMoveDirection = forward * InputZ + right * InputX;

		if (blockRotationPlayer == false) {
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (desiredMoveDirection), desiredRotationSpeed);
            controller.Move(desiredMoveDirection * Time.deltaTime * Velocity);
		}
	}

    public void LookAt(Vector3 pos)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(pos), desiredRotationSpeed);
    }

    // public void RotateToCamera(Transform t)
    // {

    //     var camera = Camera.main;
    //     var forward = cam.transform.forward;
    //     var right = cam.transform.right;

    //     desiredMoveDirection = forward;

    //     t.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
    // }

	void InputMagnitude() {
		//Calculate Input Vectors
		InputX = Input.GetAxis ("Horizontal");
		InputZ = Input.GetAxis ("Vertical");

		//anim.SetFloat ("InputZ", InputZ, VerticalAnimTime, Time.deltaTime * 2f);
		//anim.SetFloat ("InputX", InputX, HorizontalAnimSmoothTime, Time.deltaTime * 2f);

		//Calculate the Input Magnitude
		Speed = new Vector2(InputX, InputZ).sqrMagnitude;

        //Physically move player

		if (Speed > allowPlayerRotation) {
			anim.SetFloat ("Blend", Speed, StartAnimTime, Time.deltaTime);
			PlayerMoveAndRotation ();
		} else if (Speed < allowPlayerRotation) {
			anim.SetFloat ("Blend", Speed, StopAnimTime, Time.deltaTime);
		}
	}
}
