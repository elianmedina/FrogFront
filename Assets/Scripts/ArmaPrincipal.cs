using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaPrincipal : MonoBehaviour
{
    public Transform Arma;
    public SpriteRenderer ArmaSR;
    public int velocidadProyectil;
    private Vector3 targetRotation;

    public GameObject Proyectil;

    private Vector3 objetivo;

    public MovimientoPersonaje MovimientoPersonaje;

    public GameObject Pivote;

    // Start is called before the first frame update
    void Start()
    {
        MovimientoPersonaje = GetComponent<MovimientoPersonaje>();
        MovimientoPersonaje = FindObjectOfType<MovimientoPersonaje>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Pivote.transform.rotation = Quaternion.Euler(0, 0, 0);
        targetRotation = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(targetRotation.y, targetRotation.x) * Mathf.Rad2Deg;
        Arma.rotation = Quaternion.Euler(new Vector3(0,0,angle));
        

        if(Input.GetKeyDown(KeyCode.Mouse0)){
            Disparo_Pium_Pium();
        }

    if(MovimientoPersonaje.mirandoDerecha == false){
        
        ArmaSR.flipX = true;
        ArmaSR.flipY = true;
        
    }
    if(MovimientoPersonaje.mirandoDerecha == true){
        
        ArmaSR.flipX = false;
        ArmaSR.flipY = false;
        
    }

       
    }
    void Disparo_Pium_Pium(){
        var proyectilInstanciado = Instantiate (Proyectil, Arma.position, transform.rotation);
        targetRotation.z = 0;
        objetivo = (targetRotation - transform.position).normalized;
        proyectilInstanciado.GetComponent<Rigidbody2D>().AddForce(objetivo * velocidadProyectil, ForceMode2D.Impulse);
    }
}

    
