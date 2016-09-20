using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ListSort : MonoBehaviour
{


    List<Person> PersonList;
    void Start()
    {
        PersonList = new List<Person>()
        {
            new Person{Age=10,Name="wu"},
            new Person{Age=32,Name="li"},
            new Person{Age=23,Name="wang"},
            new Person{Age=11,Name="liu"},
            new Person{Age=15,Name="fe"},
        };

        PersonList.Sort((left, right) =>
        {
            if (left.Age > right.Age)
                return 1;
            else if (left.Age == right.Age)
                return 0;
            else
                return -1;
        });

        foreach (Person item in PersonList)
        {
            Debug.LogError(item.Name);
        }
    }

    void Update()
    {

    }
}


public class Person
{
    public int Age { get; set; }

    public string Name { get; set; }
}
