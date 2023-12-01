using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaculos : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject player;
    public float speed = 1f;
    public float limiteX = 9;
    public float limiteZ = 6;

    private void Awake()
    {
       // rb.AddRelativeForce(Vector3.forward * Time.deltaTime * speed);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.position = Vector3.forward * Time.deltaTime * speed;
        // rb.AddRelativeForce(Vector3.forward * Time.deltaTime * speed);
        //Vector3 mousePos = Input.mousePosition;
        //Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        //mousePos.x = mousePos.x - objectPos.x;
        //mousePos.y = mousePos.y - objectPos.y;
        //float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(new Vector3(0, -angle + 90, 0));

    }
    private void OnEnable()
    {
        //rb.AddRelativeForce(Vector3.forward * Time.deltaTime * speed);
        transform.position = Vector3.forward * Time.deltaTime * speed;
        transform.LookAt(player.transform.position);
        // rb.AddForce(transform.forward *Time.deltaTime* speed, ForceMode.Impulse);
    }
    private void OnDisable()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
      
        
       // transform.Translate(Vector3.forward * speed * Time.deltaTime);
    
        if (transform.position.x > 15)
        {
            gameObject.SetActive(false);
        }
        if (transform.position.x < -15)
        {
            gameObject.SetActive(false);
        }


        if (transform.position.z > 7)
        {
            gameObject.SetActive(false);
        }
        if (transform.position.z < -7)
        {
            gameObject.SetActive(false);
        }
    }
   


}
