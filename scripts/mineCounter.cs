using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class mineCounter : MonoBehaviour
{
    
    public TMPro.TextMeshProUGUI text;
    public GameObject numberManagerObject;
    numberManager numberManagerScript;
    public string numberOfFlags;

    // Start is called before the first frame update
    void Start()
    {
        numberManagerScript = numberManagerObject.GetComponent<numberManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Gets the number of flags from the numberManager script
        numberOfFlags = numberManagerScript.numberOfFlags.ToString();
        if(numberOfFlags.Length == 1){
            text.text = "00" + numberOfFlags;
            
        }
        else if (numberOfFlags.Length == 2){
            text.text = "0" + numberOfFlags;
        }
        else{
            text.text = numberOfFlags;
        }
    }
    
}
