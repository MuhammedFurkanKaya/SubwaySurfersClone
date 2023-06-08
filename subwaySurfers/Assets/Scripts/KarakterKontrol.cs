using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterKontrol : MonoBehaviour
{

    Rigidbody rigi;
    float ziplamaGucu = 5.5f;
    float kosmaHizi = 2.0f;

    bool sag;
    bool sol;
    bool zipladi = false;

    public GameObject toz;

    Animator anim;

    Transform yol_1;
    Transform yol_2;

    yonetici yonet;

    public bool miknatisAlindi = false;

    public GameObject oyunBittiPnl;
    // Start is called before the first frame update
    void Start()
    {
        yonet = GameObject.Find("yonetici").GetComponent<yonetici>();

        yol_1 = GameObject.Find("yol_1").transform;
        yol_2 = GameObject.Find("yol_2").transform;

        rigi = gameObject.GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "yol_1")
        {
            yol_2.position = new Vector3(yol_2.position.x, yol_2.position.y, yol_1.position.z + 10.0f);
        }
        if (other.gameObject.name == "yol_2")
        {
            yol_1.position = new Vector3(yol_1.position.x, yol_1.position.y, yol_2.position.z + 10.0f);
        }

        if(other.gameObject.tag == "altin")
        {
            other.gameObject.SetActive(false);
            yonet.puanArttir(10);
        }

        if (other.gameObject.tag == "miknatis")
        {
            other.gameObject.SetActive(false);
            miknatisAlindi = true;
            Invoke("miknatisIptal", 10.0f);
        }
    }

    void miknatisIptal()
    {
        miknatisAlindi = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "engel")
        {
            oyunBittiPnl.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }




    private void OnCollisionStay(Collision collision)
    {
        zipladi = false;
        if(toz.activeSelf == false)
        {
            toz.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        zipladi = true;
        if (toz.activeSelf == true)
        {
            toz.SetActive(false);
        }
    }






    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch parmak = Input.GetTouch(0);
            if(parmak.deltaPosition.x > 50.0f)
            {
                sag = true;
                sol = false;
            }

            if (parmak.deltaPosition.x < -50.0f)
            {
                sag = false;
                sol = true;
            }
        }

        if (sag)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(-5.5f, transform.position.y, transform.position.z), kosmaHizi * Time.deltaTime);
        }

        if (sol)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(-7.7f, transform.position.y, transform.position.z), kosmaHizi * Time.deltaTime);
        }


        transform.Translate(0, 0, kosmaHizi * Time.deltaTime);
    }



    public void zipla()
    {
        if(zipladi == false)
        {
            anim.SetTrigger("zipla");
            rigi.velocity = Vector3.zero;
            rigi.velocity = Vector3.up * ziplamaGucu;
        }
        
    }
}
