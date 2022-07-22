using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverScene : MonoBehaviour
{
    //This just loads the game scene
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene("gameScene");
        }
    }

    public void backToGameScene(){
        SceneManager.LoadScene("gameScene");
    }

    
}
