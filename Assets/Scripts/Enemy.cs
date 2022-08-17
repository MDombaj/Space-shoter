

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    protected float enemySpeed=enemyConfig.speed;
    [SerializeField]
    protected float chanceTriple = 3f;
        [SerializeField]
    protected float chanceSpeed = 2f;
            [SerializeField]
    protected float chanceShield = 3.5f;
    [SerializeField]
    protected GameObject tripleShot;
     [SerializeField]
    protected GameObject speedBoost;
      [SerializeField]
    protected GameObject shield;
        [SerializeField]
        protected int points;
    protected Player player;
    protected Animator anim;
    protected Collider2D coll;
    protected AudioSource audSor;
    [SerializeField]
            protected AudioClip explosion;
    [SerializeField]
        protected int enemyLife;


    
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.Find("Player").GetComponent<Player>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        audSor = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * enemySpeed * Time.deltaTime);
        if (transform.position.y<-6){

            transform.position = new Vector3(Random.Range(-4f,5f),7,0);
        }
        
    }
    // protected void OnTriggerEnter2D(Collider2D other)
    // {
    //     switch(other.tag){

    //         case "Laser":
    //             Destroy(other.gameObject);
                
    //             player.AddScore(points);
    //             if (Random.Range(0f,10f)<= chanceTriple){
    //                 Instantiate (tripleShot,transform.position,Quaternion.identity);
    //             } else if (Random.Range(0f,15f)<= chanceSpeed){
    //                 Instantiate (speedBoost,transform.position,Quaternion.identity);
    //             }else if (Random.Range(0f,11f)<= chanceShield){
    //                 Instantiate (shield,transform.position,Quaternion.identity);
    //             }
    //             StartCoroutine(AnimRoutine());
    //             break;
    //         case "Player":
                
    //             if (player!= null){
    //             player.DamagePlayer();

    //              }
                 
    //              StartCoroutine(AnimRoutine());
                
    //             break;
    //         default:
    //         break;
    //     }
        
    // }
    protected void DamageEnemy(){
        enemyLife--;
    }
    protected IEnumerator AnimRoutine(){
        anim.SetTrigger("OnDeath");
        enemySpeed = 0f;
        coll.enabled=false;
        audSor.clip = explosion;
        audSor.Play();
        yield return new WaitForSeconds(4.5f);
        Destroy(this.gameObject);
    }
}
