using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onClick : MonoBehaviour
{
    public GameObject numberManagerObject;
    numberManager numberManagerScript;
    void Start(){
        numberManagerScript = numberManagerObject.GetComponent<numberManager>();
    }
    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0)){
            Debug.Log("left click");
            numberManagerScript.showNumberSprite(gameObject);
        }
        else if(Input.GetMouseButtonDown(1)){
            Debug.Log("right click");
            numberManagerScript.putFlag(gameObject);
        }
        
    }

    
}
