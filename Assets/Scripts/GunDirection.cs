using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDirection : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject foreArm;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(foreArm.transform.forward);
    }
}
