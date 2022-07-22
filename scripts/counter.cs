using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class counter : MonoBehaviour
{
    public TMPro.TextMeshProUGUI text;
    public static string firstText;
    public float startTime;
    
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.timeSinceLevelLoad;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Time.timeSinceLevelLoad returns the time in a float so here I round it to a whole number
        irstText = "";
        firstText = Mathf.Floor(Time.timeSinceLevelLoad - startTime).ToString();
       
        //Depending of the length of the string, the correct number of zeros are added to the front of the string
        if(firstText.Length == 1){
            text.text = "00" + firstText;
            firstText = "";
        }
        else if (firstText.Length == 2){
            text.text = "0" + firstText;
            firstText = "";
        }
        else{
            text.text = firstText;
            firstText = "";
        }
    }
    
}
