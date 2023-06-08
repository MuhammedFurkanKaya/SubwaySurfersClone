using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class yonetici : MonoBehaviour
{

    public TMPro.TextMeshProUGUI puanTxt;

    public GameObject altin;
    public GameObject miknatis;

    public GameObject kutuk;
    public GameObject tas;
    public GameObject araba;

    List<GameObject> altinlar = new List<GameObject>();
    List<GameObject> digerleri = new List<GameObject>();

    Transform cocuk;

    int puan = 0;

    public GameObject oyunuDurdurPnl;

    // Start is called before the first frame update
    void Start()
    {

        cocuk = GameObject.Find("cocuk").transform;

        uretme(altin, 10, altinlar);
        uretme(miknatis, 3, digerleri);
        uretme(kutuk, 3, digerleri);
        uretme(tas, 3, digerleri);
        uretme(araba, 3, digerleri);


        InvokeRepeating("altinUret", 0.0f, 1.0f);
        InvokeRepeating("engelUret", 1.5f, 3.0f);

        puanTxt.text = "SKOR: " + puan;
    }


    public void puanArttir(int deger)
    {
        puan += deger;
        puanTxt.text = "SKOR: " + puan;
    }

    void engelUret()
    {
        int rast = Random.Range(0, digerleri.Count);
        if (digerleri[rast].activeSelf == false)
        {
            digerleri[rast].SetActive(true);

            int rastgele = Random.Range(0, 2);
            if (rastgele == 0)
            {
                digerleri[rast].transform.position = new Vector3(-5.5f, -5.06f, cocuk.position.z + 10.0f);
            }
            if (rastgele == 1)
            {
                digerleri[rast].transform.position = new Vector3(-7.7f, -5.06f, cocuk.position.z + 10.0f);
            }

           

            if (digerleri[rast].tag == "miknatis")
            {
                if (cocuk.gameObject.GetComponent<KarakterKontrol>().miknatisAlindi == true)
                {
                    digerleri[rast].SetActive(false);
                }
                
            }

            if (digerleri[rast].name == "miknatis(Clone)")
            {
                if (rastgele == 0)
                {
                    digerleri[rast].transform.position = new Vector3(-5.5f, -4.6f, cocuk.position.z + 10.0f);
                }
                if (rastgele == 1)
                {
                    digerleri[rast].transform.position = new Vector3(-7.7f, -4.6f, cocuk.position.z + 10.0f);
                }
            }
        }
        else
        {
            foreach(GameObject nesne in digerleri)
            {
                if(nesne.activeSelf == false)
                {
                    nesne.SetActive(true);

                    int rastgele2 = Random.Range(0, 2);
                    if (rastgele2 == 0)
                    {
                        nesne.transform.position = new Vector3(-5.5f, -5.06f, cocuk.position.z + 10.0f);
                    }
                    if (rastgele2 == 1)
                    {
                        nesne.transform.position = new Vector3(-7.7f, -5.06f, cocuk.position.z + 10.0f);
                    }
                    if (cocuk.gameObject.GetComponent<KarakterKontrol>().miknatisAlindi == true)
                    {
                        if (nesne.tag == "miknatis")
                        {
                            nesne.SetActive(false);
                        }
                    }
                    if (nesne.name == "miknatis(Clone)")
                    {
                        if (rastgele2 == 0)
                        {
                            nesne.transform.position = new Vector3(-5.5f, -4.6f, cocuk.position.z + 10.0f);
                        }
                        if (rastgele2 == 1)
                        {
                            nesne.transform.position = new Vector3(-7.7f, -4.6f, cocuk.position.z + 10.0f);
                        }
                    }
                    return;
                }
            }
        }

    }

    public void tekrarOyna()
    {
        SceneManager.LoadScene("oyun");
        Time.timeScale = 1.0f;
    }

    public void devamEt()
    {
        oyunuDurdurPnl.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void oyunuDurdur()
    {
        oyunuDurdurPnl.SetActive(true);
        Time.timeScale = 0.0f;
    }


    public void oyundanCik()
    {
        Application.Quit();
    }

    void altinUret()
    {
        foreach(GameObject altin in altinlar)
        {
            if(altin.activeSelf == false)
            {
                altin.SetActive(true);
                int rastgele = Random.Range(0, 2);
                if(rastgele == 0)
                {
                    altin.transform.position = new Vector3(-5.5f, -4.5f, cocuk.position.z + 10.0f);
                }
                if (rastgele == 1)
                {
                    altin.transform.position = new Vector3(-7.7f, -4.5f, cocuk.position.z + 10.0f);
                }

                return;
            }
        }
    }

    void uretme(GameObject nesne,int miktar,List<GameObject> liste)
    {
        for(int i=0; i<miktar; i++)
        {
            GameObject yeniNesne = Instantiate(nesne);
            yeniNesne.SetActive(false);
            liste.Add(yeniNesne);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
