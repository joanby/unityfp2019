using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Character
{
    public bool gender;
    public Archer(string name, int age):base(name, age){

    }

    public Archer(string name, int age, bool gender): base(name, age)
    {
        this.gender = gender;
    }
}
