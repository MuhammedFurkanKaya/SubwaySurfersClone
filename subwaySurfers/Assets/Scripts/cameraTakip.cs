using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraTakip : MonoBehaviour
{
    Transform cocukPos;
    Vector3 offset;
    float hiz = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        cocukPos = GameObject.Find("cocuk").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        offset = new Vector3(cocukPos.position.x, transform.position.y, cocukPos.position.z - 2f);

        transform.position = Vector3.Lerp(transform.position, offset,hiz*Time.deltaTime);
    }
}
