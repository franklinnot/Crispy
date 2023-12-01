using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class bala : MonoBehaviour
{
    public float speedBala = 15;
    private Rigidbody rb;

  
    // Start is called before the first frame update
    void Start()
    {


       
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speedBala, ForceMode.Impulse);
    }
    
    // Update is called once per frame
    void Update()
    {
        

       

        if (transform.position.x > 9.6f)
        {
            Destroy(gameObject);
        }
        if (transform.position.x < -9.6f)
        {
            Destroy(gameObject);
        }


        if (transform.position.z > 4.7)
        {
            Destroy(gameObject);
        }
        if (transform.position.z < -5.5)
        {
            Destroy(gameObject);
        }



    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemigo"))
        {
            collision.gameObject.SetActive(false);
            Destroy(gameObject);
  

            GameManager gm = FindObjectOfType<GameManager>();
            gm.PuntajeAumenta();






        }



    }
}
