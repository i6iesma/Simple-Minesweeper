using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using unity scene manager
using UnityEngine.SceneManagement;

public class numberManager : MonoBehaviour
{
    public Sprite minaSprite;
    public int counterOfMines = 0;
    public int mineCounterOfMine = 0;
    public Sprite casillaSprite;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;
    public Sprite sprite6;
    public Sprite flagSprite;
    public Sprite casillaNoRevelada;
    public GameObject createMinesObject;
    public createMines createMinesScript;
    private List<Transform> allChildren;
    public Vector3 placeToInstantiate;
    public GameObject mineCounterObject;
    public mineCounter mineCounterScript;
    public bool clickBlock = false;
    private float counter;
    public int numberOfFlags;
    public int numberOfMines;
    public static string firstText;
    private List<GameObject> objectSurroundingMine;
    
    
    void Start(){
        
       clickBlock = false;
       
        
    }
    
    
    public void showAllNumbers(List<Transform> children, int mineNumber)
    {


        //This function is called from createMines.cs when all the mines have been selected

        Debug.Log("numberManager Start"); 
        allChildren = children;
        createMinesScript = createMinesObject.GetComponent<createMines>();
        numberOfMines = mineNumber;
        numberOfFlags = mineNumber;
        
        //For every gameobject in the list of children of the createMines script
        Debug.Log(children.Count);
        for(int i = 0; i < children.Count; i++){
            counterOfMines = 0;
            
            overlapAllSpheres(children[i].transform.gameObject);
            }
        }


    public void overlapAllSpheres(GameObject _centerGameobject){
        //overlapSphere creates an invisible circle on a given coordinates to obtain the gameobject
        //if the gameobject is a mine, the counterOfMines variable is incremented
        //This allows to know how many mines are around a given gameobject without any other references needed
        counterOfMines = 0;
        Vector3 _center = _centerGameobject.transform.position;
        overlapSphere(new Vector3(_center.x, _center.y + 20, _center.z), _centerGameobject);
        overlapSphere(new Vector3(_center.x + 20, _center.y + 20, _center.z), _centerGameobject);
        overlapSphere(new Vector3(_center.x + 20, _center.y, _center.z), _centerGameobject);
        overlapSphere(new Vector3(_center.x + 20, _center.y - 20, _center.z), _centerGameobject);
        overlapSphere(new Vector3(_center.x, _center.y - 20, _center.z), _centerGameobject);
        overlapSphere(new Vector3(_center.x - 20, _center.y - 20, _center.z), _centerGameobject);
        overlapSphere(new Vector3(_center.x - 20, _center.y, _center.z), _centerGameobject);  
        overlapSphere(new Vector3(_center.x - 20, _center.y + 20, _center.z), _centerGameobject);
        Debug.Log(counterOfMines);
        assignNumberTag(_centerGameobject);

    }

    public void overlapAllSpheresEmptyBox(GameObject _centerGameobject){
        Vector3 _center = _centerGameobject.transform.position;
        overlapSphereEmptyBox(new Vector3(_center.x, _center.y + 20, _center.z), _centerGameobject);
        overlapSphereEmptyBox(new Vector3(_center.x + 20, _center.y + 20, _center.z), _centerGameobject);
        overlapSphereEmptyBox(new Vector3(_center.x + 20, _center.y, _center.z), _centerGameobject);
        overlapSphereEmptyBox(new Vector3(_center.x + 20, _center.y - 20, _center.z), _centerGameobject);
        overlapSphereEmptyBox(new Vector3(_center.x, _center.y - 20, _center.z), _centerGameobject);
        overlapSphereEmptyBox(new Vector3(_center.x - 20, _center.y - 20, _center.z), _centerGameobject);
        overlapSphereEmptyBox(new Vector3(_center.x - 20, _center.y, _center.z), _centerGameobject);  
        overlapSphereEmptyBox(new Vector3(_center.x - 20, _center.y + 20, _center.z), _centerGameobject);

    }

    
    
    
    
    
   
    
   
    
    
    
    
    public void overlapSphere(Vector3 _center, GameObject _centerGameobject){
        //Set the center
        //Set the position to the given center
        Vector3 _position = _center;
        //Set the radius to a very little value in order to prevent the sphere touching multiple objects
        float _radius = 0.1f;
        //Create the sphere with the previus parameters
        Collider2D[] _colliders = Physics2D.OverlapCircleAll(_position, _radius);
        //if the colliders in collider2d are more than one
        //If the colliders list is empty

        
        
        if(_colliders.Length == 1){
            
            //Return the values in collider2D
            checkIfMine(_colliders);

            }
            
        }
    public void overlapSphereEmptyBox(Vector3 _center, GameObject _centerGameobject){
        //Set the center
        //Set the position to the given center
        Vector3 _position = _center;
        //Set the radius to a very little value in order to prevent the sphere touching multiple objects
        float _radius = 0.1f;
        //Create the sphere with the previus parameters
        Collider2D[] _colliders = Physics2D.OverlapCircleAll(_position, _radius);
        //if the colliders in collider2d are more than one
        //If the colliders list is empty

        
        
        if(_colliders.Length == 1){
            if(_colliders[0].tag == "casillaRevelada"){
                Debug.Log("Es casilla");
                
                showNumberSprite(_colliders[0].gameObject);
            }
            else if(_colliders[0].tag == "casillaNoSeguir"){
                Debug.Log("Es casilla no seguir");
               
            }
            else{
                showNumberSprite(_colliders[0].gameObject);
            }
            
        }

    
        
    
        
    //Reset the colliders list
    _colliders = new Collider2D[0];
    }
    

    public void checkIfMine(Collider2D[] _colliders){
        //If the tag of the collider is equal to mina
       
        if(_colliders.Length != 0){

        
        if(_colliders[0].tag == "mina"){
            counterOfMines++;
            }
        }
    } 
        
            
    

    public void showNumberSprite(GameObject clickedObject){
       
        
        
        //This function is called from the clickManager.cs when a gameobject is clicked
        //Depending of the tag of the gameobject, the sprite is changed to the correct number
        
        if(clickBlock == false){
            Debug.Log("clickBlock == false");
        if(clickedObject.tag == "casillaRevelada"){
            //if the clickedObject doesn't contain any surrounding mines, it checks all the surrounding
            //gameobjects and, if they are also empty, it also returns to this function until it finds a 
            //box with a number
            clickedObject.GetComponent<SpriteRenderer>().sprite = casillaSprite;
            //Check all of the surrounding objects to check if they should become visible
            //Assign the tag "casillaNoSeguir" in order to prevent a stack overflow because of the recursive function
            clickedObject.tag = "casillaNoSeguir";
            overlapAllSpheresEmptyBox(clickedObject);
        }
        if(clickedObject.tag == "1"){
            clickedObject.GetComponent<SpriteRenderer>().sprite = sprite1;
            clickedObject.tag = "numeroRevelado";
        }
        if(clickedObject.tag == "2"){
            clickedObject.GetComponent<SpriteRenderer>().sprite = sprite2;
            clickedObject.tag = "numeroRevelado";
        }
        if(clickedObject.tag == "3"){
            clickedObject.GetComponent<SpriteRenderer>().sprite = sprite3;
            clickedObject.tag = "numeroRevelado";
        }
        if(clickedObject.tag == "4"){
            clickedObject.GetComponent<SpriteRenderer>().sprite = sprite4;
            clickedObject.tag = "numeroRevelado";
        }
        if(clickedObject.tag == "5"){
            clickedObject.GetComponent<SpriteRenderer>().sprite = sprite5;
            clickedObject.tag = "numeroRevelado";
        }
        if(clickedObject.tag == "6"){
            clickedObject.GetComponent<SpriteRenderer>().sprite = sprite6;
            clickedObject.tag = "numeroRevelado";
        }
        if(clickedObject.tag == "mina"){
            //trigger the game over
            gameOver();
        }
        if(clickedObject.tag == "flag"){
            //if the object is a flag, it is removed
            numberOfFlags++;
            clickedObject.GetComponent<SpriteRenderer>().sprite = casillaNoRevelada;
            overlapAllSpheres(clickedObject);
            
            
        }
        if(clickedObject.tag == "mineFlag"){
            //if the object has been selected as a flag by the user but it is a mine, it disappears but it
            //is given the tag mina again
            clickedObject.tag = "mina";
            clickedObject.GetComponent<SpriteRenderer>().sprite = casillaNoRevelada;
            numberOfMines++;
            numberOfFlags++;


        }
        } 

    }



    public void putFlag(GameObject clickedObject){
        //this function is called from the clickManager.cs when a gameobject is clicked with right click
        if(clickBlock == false){
        if( clickedObject.tag != "numeroRevelado"){
            if(clickedObject.tag != "casillaNoSeguir"){
                if(clickedObject.tag != "flag"){
                    //if the objects is a not revealed box, it is changed to a flag
                    //because the number tag is needed, it is checked everything with !=
                    if(clickedObject.tag != "mineFlag"){
            
        
        
        //a flag is placed
        numberOfFlags--; 
        Debug.Log("flags = " + numberOfFlags);
        clickedObject.GetComponent<SpriteRenderer>().sprite = flagSprite; //Change the sprite of the clicked object to the flag sprite
        Debug.Log("mines = "+numberOfMines);
        //if the flag is also a mine, the number of mines is decreased
        if(clickedObject.tag == "mina"){
            numberOfMines--;
            Debug.Log("numberofmines = " +numberOfMines);
        }
        //Win condition
        if(numberOfMines == 0){
            
            Debug.Log("mines = 0");
            if(numberOfFlags == 0){
                Debug.Log("flags = 0");
                win();
            }
        }
        if(clickedObject.tag == "mina"){
            //this makes able to store the information that the flag is also a mine in order to be checked in
            //showNumberSprite()
            clickedObject.tag = "mineFlag";
        }
        else{

        clickedObject.tag = "flag";
        }
            }
            }
            }
        }
        }
        }
        

    
    

    void assignNumberTag(GameObject clickedObject){
        //This is called from overlapSphere function to assign the tag depending of the mines surrounding it
        if(clickedObject.tag != "mina"){
        
        if(counterOfMines == 0){
            clickedObject.tag = "casillaRevelada";
        }
        if(counterOfMines == 1){
            clickedObject.tag = "1";
        }
        if(counterOfMines == 2){
            clickedObject.tag = "2";
        }
        if(counterOfMines == 3){
            clickedObject.tag = "3";
        }
        if(counterOfMines == 4){
            clickedObject.tag = "4";
        }
        if(counterOfMines == 5){
            clickedObject.tag = "5";
        }
        if(counterOfMines == 6){
            clickedObject.tag = "6";
        }
        }
        else{
            clickedObject.tag = "mina";
        }

    }

    public void win(){
        //reveals all the mines, then, loads the scene with the win screen
        Debug.Log("You win");
        firstText = Mathf.Floor(Time.timeSinceLevelLoad).ToString();
        for(int i = 0;i < allChildren.Count; i++){
            showNumberSprite(allChildren[1].gameObject);
        }
        wait(100);
        SceneManager.LoadScene("youWin");
    }
    
    public void gameOver(){
    

        clickBlock = true;
        for(int i = 0; i < allChildren.Count; i++){
            if(allChildren[i].tag == "mina"){
                allChildren[i].GetComponent<SpriteRenderer>().sprite = minaSprite;
            }
            
            }
        wait(100);
        SceneManager.LoadScene("gameOver");

        
    }   

    public void wait(float timeToWait){
        counter = 0.0f;
        while(timeToWait > counter){
            counter+=Time.deltaTime;
            
        }
    }
    
}


