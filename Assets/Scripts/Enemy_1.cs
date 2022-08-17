using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 : Enemy
{
    // Start is called before the first frame update
     private void OnTriggerEnter2D(Collider2D other)
    {
        switch(other.tag){

            case "Laser":
                Destroy(other.gameObject);
                DamageEnemy();
                if(enemyLife<=0){
                                        player.AddScore(points);
                if (Random.Range(0f,10f)<= chanceTriple){
                    Instantiate (tripleShot,transform.position,Quaternion.identity);
                } else if (Random.Range(0f,15f)<= chanceSpeed){
                    Instantiate (speedBoost,transform.position,Quaternion.identity);
                }else if (Random.Range(0f,11f)<= chanceShield){
                    Instantiate (shield,transform.position,Quaternion.identity);
                }
                StartCoroutine(AnimRoutine());
                }
                

                break;
            case "Player":
                
                if (player!= null){
                player.DamagePlayer();

                 }
                 
                 StartCoroutine(AnimRoutine());
                
                break;
            default:
            break;
        }
        
    }
}
