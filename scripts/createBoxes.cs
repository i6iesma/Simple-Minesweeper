using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createBoxes : MonoBehaviour
{
    int counter = 0;
    //Get the reference to the rigidbody in the gameobject of this script

    public Rigidbody2D casilla;
    //Rigidbody casilla = gameObject.GetComponent<Rigidbody>();
    Transform place;
    Vector3 newPosition;
    public GameObject parent;
    public int numberOfRows;
   

    // Start is called before the first frame update
    void Awake()
    {
        
    
        Transform place = gameObject.GetComponent<Transform>();
        newPosition = new Vector3(place.position.x, place.position.y + 20, place.position.z);
        counter = 0;
        
        // Instantiate the casilla prefab 10 times adding 20 units to the y axis
        while (counter <numberOfRows - 1)
        {
            
            
            //Create 10 rows of the casilla prefab and add 20 units to the y axis each time
            //Every box on the down row of the grid has this script
            counter++;
            Rigidbody2D instantiatedObject = Instantiate(casilla, newPosition, place.rotation, transform.parent);
            instantiatedObject.gameObject.tag = "casilla";
            newPosition = new Vector3(newPosition.x, newPosition.y + 20, newPosition.z);
        
        }

       
        
    }

    
}

