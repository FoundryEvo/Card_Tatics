using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class GridDebugObject : MonoBehaviour
{

    [SerializeField] TextMeshPro textMeshPro;

    private GridObject gridObject;


    public void SetGridObject(GridObject gridObject)
    {
        this.gridObject = gridObject;
    }

    private void Update()
    {
        textMeshPro.text = gridObject.ToString();
    }

}
