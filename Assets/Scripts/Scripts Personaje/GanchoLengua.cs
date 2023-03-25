using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GanchoLengua : MonoBehaviour
{
    public Camera mainCamera;
    public LineRenderer DisparoCuerda;
    
    public Rigidbody2D personajeRigidbody;

    public float gravedadModificada = 0f;
    public float distanciaMaxima = 5f;
    private float gravedad;

    public float fuerzaLengua;

    public LayerMask CapaEnganche;

    public float tiempoReutilizacion = 3f; // Tiempo de reutilización en segundos
    private float tiempoUltimoEnganche = -1f; // Tiempo en el que se realizó el último enganche
    // Start is called before the first frame update
    void Start()
    {
        
        CapaEnganche = LayerMask.GetMask("Gancheable");   
        
        gravedad = personajeRigidbody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > tiempoUltimoEnganche + tiempoReutilizacion && Input.GetMouseButtonDown(1)){
            Vector2 posicionMouse = (Vector2) mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, posicionMouse - (Vector2)transform.position, 100f, CapaEnganche);
           if (hit.collider != null){
                Vector2 direccionLengua = (hit.point - (Vector2)transform.position).normalized;

                // Aplica una fuerza en la dirección de la lengua
                Rigidbody2D rigidbodyPersonaje = GetComponent<Rigidbody2D>();
                rigidbodyPersonaje.AddForce(direccionLengua * fuerzaLengua, ForceMode2D.Impulse);
                DisparoCuerda.SetPosition(0,hit.point); // Posición objetivo donde engancharse
                DisparoCuerda.SetPosition(1, transform.position); // Posicion del jugador
                //UnionGancho.enabled = true;
                //UnionGancho.connectedBody = hit.collider.attachedRigidbody;
                //UnionGancho.connectedAnchor = hit.point - (Vector2)hit.collider.transform.position;
                DisparoCuerda.enabled = true;
                tiempoUltimoEnganche = Time.time;
                Invoke("DesactivarCuerda", 0.15f);
                
                
            } 
        } else if (Input.GetKeyUp(KeyCode.Mouse1)){
            DisparoCuerda.enabled = false;
            
            

            //personajeRigidbody.gravityScale = gravedad;
            //personajeRigidbody.bodyType = RigidbodyType2D.Dynamic;

        
        
    }
    }
    void DesactivarCuerda(){
        DisparoCuerda.enabled = false;
    }
}
