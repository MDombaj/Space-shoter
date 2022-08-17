using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : Enemy
{
    // Start is called before the first frame update
        private void OnTriggerEnter2D(Collider2D other)
    {
        switch(other.tag){

            case "Laser":
                Destroy(other.gameObject);
                DamageEnemy();
                if(enemyLife<=0){
                    SetSprite(false,false);
                                        player.AddScore(points);
                if (Random.Range(0f,10f)<= chanceTriple){
                    Instantiate (tripleShot,transform.position,Quaternion.identity);
                } else if (Random.Range(0f,15f)<= chanceSpeed){
                    Instantiate (speedBoost,transform.position,Quaternion.identity);
                }else if (Random.Range(0f,11f)<= chanceShield){
                    Instantiate (shield,transform.position,Quaternion.identity);
                }
                StartCoroutine(AnimRoutine());
                }else{
                    SetSprite(false,true);
                }
                

                break;
            case "Player":
                SetSprite(false,false);
                if (player!= null){
                    
                player.DamagePlayer();

                 }
                 
                 StartCoroutine(AnimRoutine());
                
                break;
            default:
            break;
        }
        
    }
    private void SetSprite(bool sprite1,bool sprite2){  
        transform.GetChild(0).gameObject.SetActive(sprite1);
        transform.GetChild(1).gameObject.SetActive(sprite2);

    }
}
