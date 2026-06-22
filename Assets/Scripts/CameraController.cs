using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target_;
    public float height = 10f;
    public float diferenciaz = -2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
      
        
    }

    private void LateUpdate() //he cambiado de update a lateupdate para que primero se actualice el movimiento del jugador y luego se actualice la camara, si no se desincronizaba
    {
        if (target_ != null)
        {
            Vector3 targetPosition = target_.transform.position;
            transform.position = new Vector3(targetPosition.x, targetPosition.y + height, targetPosition.z + diferenciaz);
        }
    }
}
