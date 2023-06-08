using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class araba : MonoBehaviour
{
    public float deger;

   

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, deger * Time.deltaTime);
    }
}
