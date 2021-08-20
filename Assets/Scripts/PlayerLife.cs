using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    // Start is called before the first frame update

    public float life = 5f;
    public GameObject object_Carry;

    public Slider health_slider;
    public Text health_Text;

    void Awake(){
        // pos = gameObject.transform;
        health_slider.minValue = 0f;
        health_slider.maxValue = 20f;
    }

    void Update(){
        health_slider.value = life;
        health_Text.text = life.ToString();
    }


    public void TakeDamage(float amount){
        life -= amount;
        if (life <= 0f){
            gameObject.transform.GetChild(0).GetComponent<Animator>().SetBool("Dead",true);

            // life = 5f;
            // Instantiate(object_Carry,transform.position,Quaternion.identity);

            Destroy(gameObject);
            
        }

        if(life>=20f){
            life = 20f;
        }
    }
}
