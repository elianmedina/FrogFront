using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaArmaPrincipal : MonoBehaviour
{
    public LayerMask capaPlataforma;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
         if ((capaPlataforma.value & (1 << other.gameObject.layer)) != 0 )
        {
            Destroy(gameObject);
        }
        

        if (other.gameObject.CompareTag("Player"))
        {
            // Ignorar colisión con el objeto que tenga el tag "Player"
            Physics.IgnoreCollision(other.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }

    
}
