using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo1Controller : MonoBehaviour
{
    public SuperPool pul;
    public float disparo_f = 10.0f;
    public float fire_rate;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Disparar", 0.0f, fire_rate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Disparar() {
        //paso 1: pedir un pato al pool
        GameObject pato = pul.GetPoolObject();

        //paso2: posicionar el pato desactivado a la posicion del jugador al frente
        pato.transform.position = transform.position + transform.right;

        //activar el pato
        pato.SetActive(true);

        //acceder al rigidbody del pato y darle una fuerza aleatoria

        Rigidbody rib = pato.GetComponent<Rigidbody>();
        rib.useGravity = false;
        rib.velocity = transform.right * disparo_f;

        //rib.AddForce(transform.forward * disparo_f, ForceMode.VelocityChange);
        //devolver el pato al pool (EN OTRO SCRIPT) y desactivarlo esto es duckcontroller
        Debug.Log("Lanza pato");
    }
}
