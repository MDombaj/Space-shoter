using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
        private Text scoreText;
    [SerializeField]
        private Image livesImage;
    [SerializeField]
        private Sprite[] lifeSprite;
            [SerializeField]
        private GameObject overText;
    [SerializeField]
    private GameObject restart;
        
    
    // Start is called before the first frame update
    void Start()
    {
        overText.SetActive(false);
        scoreText.text= "Score:0";
        restart.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateScore(int score){
        scoreText.text="Score: " + score;
    }
    public void LifeUpdate(int lives){
        livesImage.sprite=lifeSprite[lives];
        if(lives<=0){
            OnEnd();
        }
         

    }
    public void OnEnd(){
        restart.SetActive(true);
        overText.SetActive(true);
    }
}
