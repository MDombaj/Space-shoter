using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ufo : MonoBehaviour
{
    private SpawnManager spawnManager;
    // Start is called before the first frame update
    
    
    
    
    
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other){
        switch(other.tag){

            case "Laser":
                Destroy(other.gameObject);
                spawnManager.OnHit();
                Destroy(this.gameObject);
            break;
            default:
            break;
        }
    }
}
