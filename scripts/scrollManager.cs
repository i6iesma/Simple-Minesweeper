using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * Input.GetAxis("Mouse ScrollWheel") * 1000);
        Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
    }
}
