using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private float MoveX;
    private float MoveZ;
    
    public GameObject bala;
    public float limiteX=5;
    public float limiteZ=2;
   // public GameObject prefab;
    public int puntaje;
    public TMP_Text txtpuntaje;
    public int vidas=3;
    public TMP_Text txtvidas;
    private Vector2 _moveInput;
    PlayerInput _playerActions;
    InputAction moveAction;
    InputAction moveAction1;
    bool ismoving;
    // Start is called before the first frame update
    void Start()
    {

        _playerActions = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        //Instantiate(prefab, Vector3.forward, Quaternion.identity);
        moveAction = _playerActions.actions.FindAction("LeftStick");
        moveAction1 = _playerActions.actions.FindAction("Fire");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemigo"))
        {
            collision.gameObject.SetActive(false);
            txtvidas.text = vidas.ToString();
            vidas--;
        }
    }
    
    public void PuntajeAumenta()
    {
        puntaje++;
        txtpuntaje.text = puntaje.ToString();

    }
    // Update is called once per frame
    void Update()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>().normalized;
        float angle = Mathf.Atan2(-direction.y, direction.x) * Mathf.Rad2Deg + 90f;
        ismoving = Convert.ToBoolean(direction.magnitude);
       
        /// transform.position += new Vector3(direction.x, 0, direction.y) *Time.deltaTime *speed;


        //rb.AddForce(new Vector3(direction.x, 0, direction.y) * Time.deltaTime*speed);
        Debug.Log(direction);
        
        if (ismoving)
        {
           
            rb.AddRelativeForce(Vector3.forward *Time.deltaTime* speed);
            rb.rotation = Quaternion.Euler(0, angle, 0);
        }

        //transform.rotation = Quaternion.Euler(0, angle, 0);

        // Debug.Log(angle);

        //if (Input.GetButton("Fire2")){
        //   // print("si");
        //   //// transform.position(Vector3.forward * speed);
        //   // MoveX = Input.GetAxis("Horizontal") * speed;
        //   // MoveZ = Input.GetAxis("Vertical") * speed;

        //   //transform.Translate(Vector3.forward*speed);
        //  rb.AddRelativeForce(Vector3.forward * speed);
        //}
        //else
        //{
        //    print("no");
        //}


        //Vector3 mousePos = Input.mousePosition;
        //Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        //mousePos.x = mousePos.x - objectPos.x;
        //mousePos.y = mousePos.y - objectPos.y;
        //float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(new Vector3(0, -angle + 90, 0));
        //// print(angle);
       // _playerActions.actions.FindAction("Fire").performed += shoot();
      
        

        if (transform.position.x > 9.6f)
        {
            transform.position= new Vector3(9.6f, 0,transform.position.z);
        }
        if (transform.position.x < -9.6f)
        {
            transform.position = new Vector3(-9.6f, 0, transform.position.z);
        }


        if (transform.position.z > 4.7)
        {
            transform.position = new Vector3(transform.position.x,0,4.7f);
        }
        if (transform.position.z < -5.3)
        {
            transform.position = new Vector3(transform.position.x, 0, -5);
        }

    }
   public void onAttackTap()
    {
      
        Instantiate(bala, transform.position, transform.rotation);

    }


}
