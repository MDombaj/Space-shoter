using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float laserSpeed= laseConfig.speed;
    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    { transform.Translate(Vector3.up * laserSpeed * Time.deltaTime);
    if(transform.position.y >= laseConfig.distanceLimit){
        if(transform.parent != null){
            Destroy(transform.parent.gameObject);
        }
            Destroy(this.gameObject);
        }
        
    }
}
