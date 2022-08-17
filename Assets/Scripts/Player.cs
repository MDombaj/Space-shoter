
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
     private int lives = 3;
     private int shieldLives;
     private SpawnManager spawnManager;
     [SerializeField]
     private bool canTriple = false; 
     [SerializeField]
    private GameObject shield1; 
         [SerializeField]
    private GameObject shield2;
         [SerializeField]
    private GameObject shield3; 
   [SerializeField]
    private GameObject triplePrefab;
    [SerializeField]
    private GameObject laserPrefab;
    [SerializeField]
    private float fireRate= laseConfig.fireRate;
    private float canFire=-1f;
         [SerializeField]
     private bool canSpeedBoost = false;
          [SerializeField]
     private bool canShield = false;  
        [SerializeField]
            private int score;
            private UIManager uiManager;
             private GameManager gameManager;
             private AudioSource audSor;
        [SerializeField]
            private AudioClip fireLaserClip;
        [SerializeField]
            private AudioClip fireTripleClip;
        [SerializeField]
            private AudioClip shieldUp;
        [SerializeField]
            private AudioClip shieldDown;
    // Start is called before the first frame update
    void Start()
    {
        uiManager=GameObject.Find("Canvas").GetComponent<UIManager>();
        gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();
        transform.position= new Vector3(playerConfig.startXPosition,playerConfig.startYPosition,playerConfig.startZPosition);
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        audSor = GetComponent<AudioSource>();
        if(audSor != null){
            audSor.clip = fireLaserClip;
        }
    }
     public float speed= playerConfig.speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    void Update() 
    {

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > canFire){
            FireLaser();
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput,verticalInput,0);
        transform.Translate(direction * speed * Time.deltaTime);
        if (transform.position.y >= 6) {

            transform.position = new Vector3(transform.position.x,6,0);
        }
        if (transform.position.y <= -4) {

            transform.position = new Vector3(transform.position.x,-4,0);
        }
        if (transform.position.x >= 10) {

            transform.position = new Vector3(10,transform.position.y,0);
        }
        if (transform.position.x <= -10) {

            transform.position = new Vector3(-10,transform.position.y,0);
        }
    }
    void FireLaser(){

        canFire=Time.time + fireRate;
        audSor.clip = fireLaserClip;
        if (canTriple){
            audSor.clip = fireTripleClip;
             Instantiate(triplePrefab,transform.position ,Quaternion.identity);
             audSor.Play();
             return;
        }

        Instantiate(laserPrefab,transform.position + laseConfig.offsetSpawn,Quaternion.identity);
        audSor.Play();
    }
    public void DamagePlayer(){
        if (canShield){
            shieldLives--;
            audSor.clip = shieldDown;
            audSor.Play();
            switch (shieldLives)
            {
                case 1:
            shield1.SetActive(true);
            shield2.SetActive(false);
            break;
                case 2:
            shield2.SetActive(true);
            shield3.SetActive(false);
            break;
                default:
                shield1.SetActive(false);
                canShield=false;
            break;
            }
            
            return;
        }
        lives--;
        uiManager.LifeUpdate(lives);
        if(lives<=0){

            if(spawnManager!=null){
                gameManager.EndGame();
                spawnManager.OnPlayerDeath();
            }
            Destroy(this.gameObject);
        }
    }
    public void CanTriple(){
        canTriple= true;
        StartCoroutine (PowRoutine());
    }
    public void CanSpeed(){
        canSpeedBoost= true;
        speed *=2;
        StartCoroutine (PowRoutine1());
    }
    public void CanShield(){

        canShield= true;
        if(shieldLives<3){
            shieldLives++;
            audSor.clip = shieldUp;
            audSor.Play();
        }
        switch (shieldLives)
        {
            case 2:
            shield1.SetActive(false);
            shield2.SetActive(true);
            break;
            case 3:
            shield2.SetActive(false);
            shield3.SetActive(true);
            break;
            default:
            shield1.SetActive(true);
            break;
            
        }
        StartCoroutine (PowRoutine());
    }
    public void AddScore(int points){
        score += points;
        uiManager.UpdateScore(score);
    }

    IEnumerator PowRoutine(){
        while (canTriple)
        {
            
            yield return new WaitForSeconds(10.0f);
            canTriple=false;
        }
        
    }
     IEnumerator PowRoutine1(){
        while (canSpeedBoost)
        {
            
            yield return new WaitForSeconds(10.0f);
            canSpeedBoost=false;
            speed /=2;
        }
        
    }
}
