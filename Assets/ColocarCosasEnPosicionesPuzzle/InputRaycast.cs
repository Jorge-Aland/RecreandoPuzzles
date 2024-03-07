using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputRaycast : MonoBehaviour
{
    private Camera mainCamera; 
    [SerializeField] private LayerMask clickeableLayer; //Solo los elementos que pertenezcan a esta casa podrán
    //recibir el raycast
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //si hacemos click izquierdo / touch en la pantalla
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); //Lanzamos una rayo desde la cámara hasta la posición
            // del ratón.
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, clickeableLayer);
            //Hacemos un raycast, desde el origen del rayo que sale de la cámara, hacia donde va el rayo de la cámara que es el ratón
            //de longitud infinita y que solo interactua con las capas asignaas en clickeableLayer
            if (hit != false) //Si no es false, es que ha chocado con algo
            {
                hit.collider.gameObject.GetComponent<IClickeable>().OnClick(); //Si implementa la interfaz IClickeable, llamámos
                //al método OnClick()
            }
            
        }
    }
}