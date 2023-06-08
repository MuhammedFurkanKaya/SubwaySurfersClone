using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kutukYokOl : MonoBehaviour
{

    Transform cocuk;

    // Start is called before the first frame update
    void Start()
    {
        cocuk = GameObject.Find("cocuk").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < (cocuk.position.z - 5.0f))
        {
            gameObject.SetActive(false);
        }
    }
}
