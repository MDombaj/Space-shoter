using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float powerSpeed = 4f;
    private enum PowTypes{Speed,Shield,Triple};
    [SerializeField]
    private PowTypes Moc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * powerSpeed * Time.deltaTime);
        if (transform.position.y<-6){

            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch(other.tag){


            case "Player":
                Player player = other.transform.GetComponent<Player>();
                if (player!= null){
                switch (Moc)
                {
                    case PowTypes.Triple:
                    player.CanTriple();
                    break;
                    case PowTypes.Speed:
                    player.CanSpeed();
                    break;
                    case PowTypes.Shield:
                    player.CanShield();
                    break;
                    
                    default:
                    break;
                }
                

                 }
                Destroy(this.gameObject);
                break;
            default:
            break;
        }
        
    }
}
