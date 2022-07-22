using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class createMines : MonoBehaviour
{
    public int mineNumber;
    public Sprite minaSprite;
    public Sprite casillaSprite;
    int counter = 0;
    public GameObject numberManagerObject;
    public numberManager numberManagerScript;
    public int numberOfMines;
    public GameObject counterObject;
    public counter counterScript;
    
    // Start is called before the first frame update
    void Start()
    {
        
        counterScript = counterObject.GetComponent<counter>();
        selectRandomChild();
        List<Transform> children = getAllChilds();
        numberManagerScript = numberManagerObject.GetComponent<numberManager>();
        numberManagerScript.clickBlock = false;
        Debug.Log("from createmines" +mineNumber);
        numberManagerScript.showAllNumbers(children, mineNumber);
        

       

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            clearMines();
            selectRandomChild();
            List<Transform> children = getAllChilds();
            counterScript.startTime = Time.timeSinceLevelLoad;
            numberManagerScript = numberManagerObject.GetComponent<numberManager>();
            numberManagerScript.showAllNumbers(children, mineNumber);
            




        }
        if(Input.GetKeyDown(KeyCode.Tab)){
            numberOfMines = 0;
            foreach(Transform children in transform){
                if(children.tag == "mina" ){
                    numberOfMines++;
                }
            }
            Debug.Log(numberOfMines);
        }

    }

    
    


    
    
    void clearMines(){
         List<Transform> children = new List<Transform>();
        foreach (Transform tr in transform){
         tr.GetComponent<SpriteRenderer>().sprite = casillaSprite;
         tr.tag = "casilla";
        }

    }
    void selectRandomChild(){
        counter = 0;
        //This loop selects a random child containing all the boxes
        while (counter < mineNumber){
           int randomChildNumber = Random.Range(1, gameObject.transform.childCount);
            GameObject returning = gameObject.transform.GetChild(randomChildNumber).gameObject; 
            //if the tag of the gameobject  is equal to casilla
            if(returning.tag == "casilla"){

                
                //set the tag to mina
                returning.tag = "mina";
                counter++;
                Debug.Log("mina puesta");
            }
            else if(returning.tag == "mina"){
                //if the child has already been selected, select another one
                Debug.Log("otro ciclo mas");
            }

           
        }

        }

    public List<Transform> getAllChilds(){
        //this returns a list of all the children of the gameobject
        List<Transform> children = new List<Transform>();
        for(int i = 0; i < gameObject.transform.childCount; i++){
            children.Add(gameObject.transform.GetChild(i));
            }
        //Return children as a list of gameobjects

        return children;
    }

    
        

    }
        
        

        

        
   
        



        
    
    
    

