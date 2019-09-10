using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Standar de Unity para UI
using TMPro;          //Para Text Mesh Pro


public class InventoryItemButton : MonoBehaviour
{
    public Text buttonText;
    private string[] itemTypes = { "Arma", "Armadura", "Hechizo" };
    public int typeIndex;

    // Start is called before the first frame update
    void Awake()
    {
        typeIndex = Random.Range(0, itemTypes.Length); //si el parámetro es int -> int
        buttonText = GetComponentInChildren<Text>();
        buttonText.text = itemTypes[typeIndex];
    }

}
