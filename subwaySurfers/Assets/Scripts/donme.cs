using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class donme : MonoBehaviour
{
    float deger = 300f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag == "miknatis")
        {
            transform.Rotate(deger * Time.deltaTime, 0,0);
        }
        if (gameObject.tag == "altin")
        {
            transform.Rotate(0, 0, deger*Time.deltaTime);
        }

    }
}
