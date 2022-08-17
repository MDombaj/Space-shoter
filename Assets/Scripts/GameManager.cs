
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool isOver=false;
    [SerializeField]
    private GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
        if(pauseMenu != null){
            pauseMenu.SetActive(false);
        }
    }
    public void DAaa(){
         SceneManager.LoadScene(1);

    }
    public void EndGame(){
       isOver=true; 
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.R) && isOver){
            SceneManager.LoadScene(1);
        } 
        if(Input.GetKeyDown(KeyCode.P) && !isOver){
            if(pauseMenu != null){
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void GoToMenu(){

        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void Resume() {

        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
