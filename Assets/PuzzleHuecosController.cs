using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleHuecosController : MonoBehaviour
{

    public static PuzzleHuecosController sharedInstance; //Singleton
    
    //Array de Huecos y de ElementOption
    [SerializeField] private PuzzleSlot[] huecos;
    [SerializeField] private ElementOption[] elementOptions;

    private ElementOption selectedElementOption; //ElementOption que tenemos seleccionado.
    public ElementOption SelectedElementOption
    {
        get => selectedElementOption;
        set => selectedElementOption = value;
    }
    
    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }

    /// <summary>
    /// Método que recibe un ElementOption y lo almacena como seleccionado, activando el visual de este y desactivando el del resto
    /// </summary>
    /// <param name="elementOption"></param>
    public void ElementOptionSelected(ElementOption elementOption)
    {
        selectedElementOption = elementOption;
        VisualDeselectAllElement();
        elementOption.Selected();
    }
    
    /// <summary>
    /// Método que desactiva el visual de selección de cada elemento
    /// </summary>
    public void VisualDeselectAllElement()
    {
        foreach (var ElementOption in elementOptions)
        {
            ElementOption.DeSelected();
        }
    }

    /// <summary>
    /// Método que mueve el ElementOption al hueco seleccionado
    /// </summary>
    /// <param name="puzzleSlot"></param>
    public void MoveElementOptionToPosition(PuzzleSlot puzzleSlot)
    {
        selectedElementOption.transform.position = 
            new Vector3(puzzleSlot.transform.position.x, puzzleSlot.transform.position.y, selectedElementOption.transform.position.z);
        //Hacemos que no adquiera el eje z, o habra problemas para ver cual va antes a la hora de seleccionar
        SelectedElementOption.AsignThisToAHueco(puzzleSlot);
        DeselectAll();
    }
    
    /// <summary>
    /// Método que deselecciona tódo
    /// </summary>
    public void DeselectAll()
    {
        VisualDeselectAllElement();
        selectedElementOption = null;
        CheckIfPuzzleIsComplete();
    }

    public void SwitchElementOption(ElementOption elementOption)
    {
        Vector3 selectedPosition = selectedElementOption.transform.position;
        selectedElementOption.transform.position = elementOption.transform.position;
        PuzzleSlot asignedPuzzleSlot = selectedElementOption.AsignedPuzzleSlot;
        PuzzleSlot reciberPuzzleSlot = elementOption.AsignedPuzzleSlot;

        if (asignedPuzzleSlot != null)
        {
            elementOption.AsignedPuzzleSlot = asignedPuzzleSlot;
            asignedPuzzleSlot.AsignValue(elementOption.GetValue());
        }

        if (reciberPuzzleSlot != null)
        {
            selectedElementOption.AsignedPuzzleSlot = reciberPuzzleSlot;
            reciberPuzzleSlot.AsignValue(selectedElementOption.GetValue());
        }
        
        
        elementOption.transform.position = selectedPosition;
        DeselectAll();
        
    }

    /// <summary>
    /// Método que comprueba que todos los elementos estén en su posición
    /// </summary>
    public void CheckIfPuzzleIsComplete()
    {
        foreach (var hueco in huecos) //por cada hueco
        {
            Debug.Log(hueco.IsTheValueCorrect());
            if (hueco.IsTheValueCorrect()) //si el valor asignado es el valor buscado 
            {
                Debug.Log("es correcto la posicion");
                continue; //seguimos el foreach
            }
            else //en caso de que no sea el valor buscado
            {
                Debug.Log("estamos saliendo");
                return; //salimos del método
            }
        }
        
        
        //Solo llegamos aqui si el foreach se ha completado
        Debug.Log("el valor es correcto");
    }
}
