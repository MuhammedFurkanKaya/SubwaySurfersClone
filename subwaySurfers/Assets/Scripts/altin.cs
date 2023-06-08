using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class altin : MonoBehaviour
{

    Transform cocuk;
    KarakterKontrol kontrol;
    // Start is called before the first frame update
    void Start()
    {
        cocuk = GameObject.Find("cocuk").transform;
        kontrol = GameObject.Find("cocuk").GetComponent<KarakterKontrol>();
    }

    // Update is called once per frame
    void Update()
    {
        float mesafe = Vector3.Distance(transform.position, cocuk.position);
        if (kontrol.miknatisAlindi == true)
        {
            
            if(mesafe <= 3.0f)
            {
                transform.position = Vector3.MoveTowards(transform.position, cocuk.position, 10f * Time.deltaTime);
            }
            
        }

        if(transform.position.z < (cocuk.position.z - 5.0f))
        {
            gameObject.SetActive(false);
        }
    }

}
