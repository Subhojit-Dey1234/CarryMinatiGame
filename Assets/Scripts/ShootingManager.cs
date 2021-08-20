using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject marker;
    public ParticleSystem explosion;
    Ray ray;
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(marker.transform.position);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Debug.Log(hit.transform.tag);
                if (hit.transform.CompareTag("Enemy"))
                {
                    explosion.transform.position = hit.transform.position;
                    if (hit.transform.GetComponent<Life>() != null)
                    {
                        hit.transform.GetComponent<Life>().TakeDamage(1f);
                    }
                    explosion.Play();
                }
            }
        }


    }
}
