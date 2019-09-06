using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct Weapon{
    public string name;
    public int damage;

    public Weapon(string name, int damage)
    {
        this.name = name;
        this.damage = damage;
    }
}


public class Character
{

    public string name;
    public int age;
    public Weapon w;

    public Character(){
        w = new Weapon("Espada", 25);
        Debug.Log(w.name); //Espada

        Weapon w2 = w;
        w2.name = "Bastón";
        //w1 = Espada
        //w2 = Bastón
    }

    public Character(string name){
        this.name = name;
        age = -1;
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Character"/> class.
    /// </summary>
    /// <param name="name">Name.</param>
    /// <param name="age">Age.</param>
    public Character(string name, int age){
        this.name = name;
        this.age = age;
    }

}

