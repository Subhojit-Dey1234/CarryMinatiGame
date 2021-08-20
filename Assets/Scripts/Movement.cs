using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    GameObject player;
    [SerializeField]
    AudioSource shootSound;
    [SerializeField]
    AudioClip clip;

    public GameObject gun;
    Vector3 gravity = Vector3.zero;
    CharacterController controller;
   
    private bool shouldFire = true;
    // float fireTimer = 0f;


    void Start()
    {
        player = gameObject.transform.GetChild(0).gameObject;
        animator = player.GetComponent<Animator>();
        controller = gameObject.GetComponent<CharacterController>();
        
    }
    void Update()
    {
        
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");
        Vector3 newRot = new Vector3(0,h,0) * 1500f *  Time.deltaTime;
        transform.Rotate(newRot);
        

        if(controller.isGrounded){
            gravity = Vector3.zero;
        }
        else{
            gravity = new Vector3(0f,-9.8f,0f);
        }
        if(Input.GetKey(KeyCode.W)){
            var forwardMovement = transform.forward + gravity;
            controller.Move(forwardMovement * 6f * Time.deltaTime);
            animator.SetBool("isWalking", true);
        }
        if(Input.GetKeyUp(KeyCode.W)){
            animator.SetBool("isWalking", false);
        }
        if(Input.GetKey(KeyCode.S)){
            var forwardMovement = -transform.forward + gravity;
            controller.Move(forwardMovement * 6f * Time.deltaTime);
            animator.SetBool("isWalking", true);
        }
        if(Input.GetKeyUp(KeyCode.S)){
            animator.SetBool("isWalking", false);
        }

        if(Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)){
            animator.SetBool("isShooting",true);
            animator.SetBool("isShootingIdle",true);


            if(shouldFire){
                shouldFire = false;
                shootSound.PlayOneShot(clip);
            }


        }
        if(Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0)){
            
            animator.SetBool("isShooting",false);
            animator.SetBool("isShootingIdle",false);

        }
        if(Input.GetKey(KeyCode.V)){
            
            animator.SetBool("Victory",true);

        }

        if(Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonDown(0)){
            shouldFire = true; 
        }
    }
    void OnTriggerEnter(Collider col){
        if(col.transform.gameObject.CompareTag("Health")){
            gameObject.GetComponent<PlayerLife>().life += col.transform.gameObject.GetComponent<HealthIncrease>().health;
            Destroy(col.transform.gameObject);
        }
    }
}
