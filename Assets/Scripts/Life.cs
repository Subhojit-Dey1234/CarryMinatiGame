using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    // Start is called before the first frame update

    public float life = 5f;
    public List<GameObject> health;

    
    Transform pos;

    void Awake(){
        pos = gameObject.transform;
    }

    public void TakeDamage(float amount){
        life -= amount;
        if (life <= 0f){
            var index = Random.Range(0,health.Count -1);
            Destroy(gameObject);
            GameObject h = Instantiate(health[index],pos.position,Quaternion.identity);
            h.SetActive(true);
        }
    }
}
