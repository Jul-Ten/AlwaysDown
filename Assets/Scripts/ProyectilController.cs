using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilController : MonoBehaviour
{
    public float lifetime_;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        StartCoroutine(ReturnToPool());
    }

    private void OnDisable()
    {
        StopCoroutine(ReturnToPool());
    }

    private void OnTriggerEnter(Collider collision)
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        gameObject.SetActive(false);
    }

    IEnumerator ReturnToPool()
    {
        yield return new WaitForSeconds(lifetime_);
        gameObject.SetActive(false);
    }
}
