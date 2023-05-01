using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;





public class player : MonoBehaviour
{
    //basico
    float velocidad = 10f;
    public bool verifyTeleport= false;

    public GameObject[] lista; 
    //puntos
    public Text pts;
    public int contador = 0;

    public float timer = 2;
    public bool puedeactivar = false;
    //animacion
    public Animator animator;
    public int i=0;
    // Start is called before the first frame update
    void Start()
    {
        pts.text= contador.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movimiento = new Vector3();
        movimiento.x = Input.GetAxis("Horizontal");
        movimiento.z = Input.GetAxis("Vertical");
        movimiento *= velocidad * Time.deltaTime;
        transform.Translate(movimiento);

        //verificar inout del espacio y activar teletransporte
        if (Input.GetKey(KeyCode.Space)){
            verifyTeleport = true;
        }            
             
    }
    void OnTriggerStay(Collider other)
    {       
        //Codigo de verificar la etiqueta y activar la teletransportacion
        if (other.tag=="origin"&&verifyTeleport==true) {

           
           GameObject destination = GameObject.FindGameObjectWithTag("destination");
           gameObject.transform.position = destination.transform.position;
           verifyTeleport = false;     
                     
        }
        //Codigo de activar la animacion
        if (other.CompareTag("meta"))
        {
            timer -= Time.deltaTime;
            //animator.SetBool("activado", true);
            if (timer<0)
            {
                puedeactivar = true; 
            }else
            {
                puedeactivar=false;
            }
            if (puedeactivar == true)
            {
                if(i<=3) {
                    lista[i].SetActive(true);
                    i++;
                    timer = 2;
                }                
            }        
                   
            
        }
        
    }
    
 

    
}
