using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScene : MonoBehaviour
{
    
    public void exit(){
        Application.Quit();
    }
    public void play(){
        SceneManager.LoadScene("gameScene");
    }
    public void menu(){
        SceneManager.LoadScene("Menu");
    }
}
