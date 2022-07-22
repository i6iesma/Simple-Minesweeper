using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class winScene : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        //Get the static variable of counter
        text.text = numberManager.firstText + " seconds";
    }

}
