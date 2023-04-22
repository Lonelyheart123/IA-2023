using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chances : MonoBehaviour
{
    public float min = 50;
    public float max = 100;
    public GameObject cajita;
    public Transform poscajita;
    public Transform posllave;
    public GameObject llave;
    public bool onRange;
    public bool isBoxOpen;
    public float count;
    Dictionary<string, float> _dic = new Dictionary<string, float>();

    public List<Chances> cajas = new List<Chances>();
    private void Start()
    {
        _dic["Absolutamente nada"] = 90;
        //_dic["Nada"] = 80;
        _dic["Llave"] = 10;

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && onRange == true && isBoxOpen == false)
        {
            isBoxOpen = true;

            if (isBoxOpen)
            {
                cajita.SetActive(false);
                //count = _dic["Absolutamente nada"];
                for (int i = 0; i < 1; i++)
                {
                    var item = CajitaRandom.Roulette(_dic);
                    print(item);

                    if (item == "Llave")
                    {
                        llave.SetActive(true);
                        posllave.transform.position = poscajita.transform.position;
                        print("Un lindo circulo");

                    }
                    else
                    {

                        _dic["Absolutamente nada"] = _dic["Absolutamente nada"] - 5;
                        count = _dic["Absolutamente nada"];
                        print(_dic["Absolutamente nada"]);
                    }
                    /*if (item == "Absolutamente nada" || item == "Nada")
                    {
                        _dic["Absolutamente nada"]-=5;
                        Debug.Log(_dic["Absolutamente nada"]);
                    }*/
                }

            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onRange = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onRange = false;
        }

    }
}
