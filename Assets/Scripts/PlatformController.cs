using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float distancia = 20f;  
    public float velocidad = 2f;   
    private Vector3 posicionInicial;
    private int direccion = 1;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        mover();
    }

    void mover()
    {

        transform.Translate(Vector3.forward * direccion * velocidad * Time.deltaTime);
        //transform.Translate(0, 0, distancia * direccion * velocidad * Time.deltaTime);

        float distanciaRecorrida = Mathf.Abs(transform.position.z - posicionInicial.z); //coge el absoluto


        if (distanciaRecorrida >= distancia)
        {
            direccion *= -1;  //Invierte la dirección
        }

        //hola luisja si lees esto no seas cruel 
    }
}
