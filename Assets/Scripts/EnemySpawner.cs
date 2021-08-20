using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame

    float x1 ,x2,z1,z2;
    public GameObject enemy;

    //-63.6 -41
    void Start(){
        x1 = -55.2f;
        z1 = 27.4f;
        x2 = 30.5f;
        z2 =-63.6f;

        for(int i=0 ;i< 25;i++){
            float x = Random.Range(x1,x2);
            float z = Random.Range(z1,z2);
            Instantiate(enemy,new Vector3(x,10,z),Quaternion.identity);
        }
        
    }
    void Update()
    {
        
    }
}
