using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class Testing : MonoBehaviour
{
    private Gridsystem gridsystem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        new Gridsystem(10, 10, 1f);

        Debug.Log(new GridPosition(5,7));
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gridsystem.GetGridPosition(MouseWorld.get));
    }
}
