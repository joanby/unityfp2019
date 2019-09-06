using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFirstScript : MonoBehaviour
{
    //[HideInInspector]
    [Range(0, 100)]
    public int iteration = 0;

    public float pi = 3.14f;
    public string firstName = "Jon Snow";
    public bool isDead = true;

    private void Awake()
    {
        Debug.Log("Awake");
    }

    // Start is called before the first frame update
    void Start()
    {

        Character c = new Character("Juan Gabriel", 31);

        Character c2 = c;

        c2.name = "Antonio Banderas";

        //c1 AB
        //c2 AB

        float edad = 31; // 31.0f

        int pi = (int)3.14f;

        //var age ;

        bool hasMoney = true;
        bool hasAge = false;

        if (!hasMoney && hasAge)
        {
            Debug.Log("TRUE");
        }
        else if (hasMoney == false)
        {
            Debug.Log("FALSE");
        }

        int money = 10;

        switch (money)
        {
            case 5:
            case 10:
            case 15:
                Debug.Log("multiplo de 5");
                break;
            default:
                Debug.Log("NADA AQUI");
                break;
        }
        Debug.Log($"El personaje se llama {firstName} y va a hacer su primera partida");

        int[] top5 = new int[5];
        string[] friends = { "Pepe", "Jorge", "Manolo" };

        Debug.Log(friends[5]);


        List<int> numbers = new List<int>() { 1, 2, 3 };
        numbers.Add(5);
        numbers.Remove(2);
        numbers.RemoveAt(1);
        numbers.Insert(5, 2);

        Dictionary<string, int> characterLevels =
            new Dictionary<string, int>()
        {
            {"juangabriel",23},
            {"antonio", 25},

        };

        if(characterLevels.ContainsKey("juangabriel"))
        {
            int leveljg = characterLevels["juangabriel"];
        }
        characterLevels["pedro"] = 5;
        characterLevels.Add("maria", 9);


        foreach(string s in characterLevels.Keys){
            Debug.Log($"{s} : {characterLevels[s]}");
        }


        foreach(KeyValuePair<string, int> kvp in characterLevels){
            Debug.Log(kvp.Key + kvp.Value);
        }

    }

    // Update is called once per frame
    void Update()
    {
        Debug.LogFormat("Update numero {0}", iteration);
    }

    private void LateUpdate()
    {
    
    }

    private void FixedUpdate()
    {
        SayHello("Pedro");

    }

    /// <summary>
    /// Método que devuelve el saludo.
    /// </summary>
    /// <returns>El saludo.</returns>
    /// <param name="name">Nombre de quien saludamos.</param>
    public string SayHello(string name){
        return $"Hola, {name}";
    }
}
