using UnityEngine;

public class Gridsystem
{
    private int width;
    private int height;
    private float cellSize;
    private GridObject[,] gridObjectArray ;

    public Gridsystem(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridObjectArray = new GridObject[width, height];

        for(int x = 0; x < width; x++) 
        {
            for(int z = 0; z < height; z++) 
            {
                //Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x, z) + Vector3.right * 0.2f, Color.white, 1000);

                GridPosition gridPosition = new GridPosition(x, z);
                gridObjectArray[x, z] =  new GridObject(this, gridPosition);
            }
        }
    }

    public Vector3 GetWorldPosition(GridPosition gridPosition)
    {
        return new Vector3(gridPosition.x, 0, gridPosition.z) * cellSize;
    }


    public GridPosition GetGridPosition(Vector3 worldPosition)
    {
        return new GridPosition(
            Mathf.RoundToInt(worldPosition.x -0.5f / cellSize),
            Mathf.RoundToInt(worldPosition.z -0.5f / cellSize)
            );

    }

    public void CreateDebugObject(Transform debugPrefab)
    {
        for (int x = 0 ; x < width; x++)
        {
            for (int z = 0 ; z < height; z++)
            {
                GridPosition gridPosition = new GridPosition(x, z);

                Transform debugTransform = GameObject.Instantiate(debugPrefab, (GetWorldPosition(gridPosition)) + new Vector3(0.5f,0,0.5f) , Quaternion.identity);
                GridDebugObject gridDebugObject = debugTransform.transform.GetComponent<GridDebugObject>();
                gridDebugObject.SetGridObject(GetGridObject(gridPosition));

            }
        }


    }

    public GridObject GetGridObject(GridPosition gridPosition)
    {
        return gridObjectArray[gridPosition.x, gridPosition.z];
    }

}
