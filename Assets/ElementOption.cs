using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementOption : MonoBehaviour, IClickeable
{
    [SerializeField] private int value; 
    [SerializeField] private GameObject selector;


    private PuzzleSlot asignedPuzzleSlot;

    public PuzzleSlot AsignedPuzzleSlot
    {
        get => asignedPuzzleSlot;
        set => asignedPuzzleSlot = value;
    }
    
    public void OnClick()
    {
        if (PuzzleHuecosController.sharedInstance.SelectedElementOption != null)
        {
            if (PuzzleHuecosController.sharedInstance.SelectedElementOption != this)
            {
                PuzzleHuecosController.sharedInstance.SwitchElementOption(this);
            }
            else
            {
                PuzzleHuecosController.sharedInstance.DeselectAll();
            }
        }
        else
        {
            PuzzleHuecosController.sharedInstance.ElementOptionSelected(this);
        }
    }
    
    public void Selected()
    {
        selector.gameObject.SetActive(true);
    }
    public void DeSelected()
    {
        selector.gameObject.SetActive(false);
    }
    
    /// <summary>
    /// Método que asigna el hueco donde está ahora mismo este ELmentOption
    /// </summary>
    /// <param name="puzzleSlot">Hueco donde se tiene que asginar</param>
    public void AsignThisToAHueco(PuzzleSlot puzzleSlot)
    {
        asignedPuzzleSlot = puzzleSlot;
    }
    
    public int GetValue()
    {
        return value;
    }
}
