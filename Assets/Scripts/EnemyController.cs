using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public float lookRadius = 10f;

    public List<ParticleSystem> particles;

    public AudioClip zomClip;

    Animator zombieAnim;
    Transform target;
    NavMeshAgent agent;
    bool shouldPlay =  true;
    float time = 0f;
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>(); 
        zombieAnim = gameObject.transform.GetChild(0).GetComponent<Animator>();
    }

    void OnTriggerStay(Collider other){
        PlayerLife energy = other.transform.gameObject.GetComponent<PlayerLife>();
        if(energy){
            foreach(var p in particles){
                p.Play();
            }
            energy.TakeDamage(0.05f);
        }
        if(energy.life <= 0){
            foreach(var p in particles){
                p.Stop();
            }
        }
    }
    void Update()
    {
        time +=  Time.deltaTime;

        if(time >= zomClip.length){
            time = 0f;
            shouldPlay = true;
        }
        float distance = Vector3.Distance(target.position,transform.position);
        if(distance <= lookRadius){
            agent.SetDestination(target.position);
                zombieAnim.SetBool("isWithinRange",true);
                if(shouldPlay){
                    shouldPlay = false;
                    gameObject.GetComponent<AudioSource>().PlayOneShot(zomClip);
                }
            if(distance <= agent.stoppingDistance){
                zombieAnim.SetBool("Attack",true);
                FaceTarget();
            }
        }
    }

    void FaceTarget(){
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime * 5f);
    }
    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,lookRadius);
    }
}
