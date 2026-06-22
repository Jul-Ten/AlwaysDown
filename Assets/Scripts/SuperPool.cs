using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPool : MonoBehaviour
{
    public GameObject goPrefab;
    public int poolMaxSize;
    List<GameObject> elementPoolList;
    // Start is called before the first frame update
    void Start()
    {
        elementPoolList = new List<GameObject>();
        for (int i = 0; i < poolMaxSize; ++i)
        { //hacer poolMaxSize veces
            GameObject obj = (GameObject)Instantiate(goPrefab); //instantiate crea un clon del objeto pasado si se lo pones a un cubo se clona
            obj.SetActive(false); //lo desactiva
            elementPoolList.Add(obj); //y lo añade a la lista
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject GetPoolObject()
    {
        for (int i = 0; i < elementPoolList.Count; ++i)
        {
            if (!elementPoolList[i].activeInHierarchy)
            { //si está inactivo en la jerarquia 
                return elementPoolList[i]; //devuelve un gameobject
            }
        }
        return null;
    }

}

