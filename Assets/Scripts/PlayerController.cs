using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    public PlatformController platmove;
    private Vector3 movimiento;
    public Transform spawn;
    public AudioSource musica_fondo;

    [Header("Movimiento")]
    public float speed;
    float horizontal;
    float vertical;

    [Header("Salto")]
    public float gravity;
    public float fuerzaSalto;
    public bool enSuelo;
    public AudioSource sonido_salto;

    [Header("Pausa")]
    public GameObject menu;
    public Button seguir;
    public Button siguiente;
    public TMP_Text pausa_mensaje; 
    bool enmeta;
    bool pausado;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        enmeta = false;
        pausado = false;
        continuar();
        spawnear();

        menu.SetActive(false);
        musica_fondo.Play();
    }

    void Update()
    {  
        movement();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausado) { //se puede hacer con menupausa.activeself
                continuar();
                pausado=false;
            }
            else
            {
                pausar();
                pausado = true;
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Muerte") || other.CompareTag("Proyectil")) //other.CompareTag("Muerte") pues puede haber mas de un elemento
        {
            spawnear();
        }
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) //controllercolider porque colission enter no funciona bien con charactercontroller
    {
        if (hit.gameObject.CompareTag("Muerte"))
        {
            spawnear();
        }

        if (hit.gameObject.name == "Meta")
        {
            enmeta = true;
            pausar();
        }


    }

    void movement()
    {
        //Verificar si el jugador está en el suelo
        enSuelo = controller.isGrounded;
        if (enSuelo && movimiento.y < 0)
        {
            movimiento.y = -2f; //si lo dejo en 0 no detecta en todos los frames que es is_grounded
        }


        //Movimiento en X y Z
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontal, 0, vertical);
        controller.Move(move * speed * Time.deltaTime);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }


        //Salto
        if (Input.GetButtonDown("Jump") && enSuelo)
        {
            movimiento.y = Mathf.Sqrt(fuerzaSalto * -2f * gravity);
            sonido_salto.Play();
        }

        //Aplicar gravedad
        movimiento.y += gravity * Time.deltaTime;
        controller.Move(movimiento * Time.deltaTime);
    }

    void spawnear()
    {
        if (controller != null) //Asegura que el controller no es null
        {
            movimiento.y = 0; //almacenaba velocidad de caida y producia errores
            controller.enabled = false;
            transform.position = spawn.position;
            controller.enabled = true; //mira, esto lo he tenido que mirar ya que character controller no es fan de transform
            Debug.Log("Debería respawnear");
        }
        else
        {
            Debug.LogWarning("El CharacterController no está asignado.");
        }
    }

    public void continuar()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void pausar()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        menu.SetActive(true);
        if (enmeta)
        {
            seguir.enabled = false;
            seguir.gameObject.SetActive(false);
            siguiente.enabled = true;
            siguiente.gameObject.SetActive(true);
            pausa_mensaje.text = "Has ganado";
        }
        else
        {
            seguir.enabled = true;
            seguir.gameObject.SetActive(true);
            siguiente.enabled = false;
            siguiente.gameObject.SetActive(false);
            pausa_mensaje.text = "Pausa";
        }
    }

    public void reintentar()
    {
        SceneManager.LoadScene("Juego"); //en el futuro hacer que sea nivel actual  
    }
    public void salir() {
        SceneManager.LoadScene("Menu");
    }
}
