using System.Collections.Generic;
using UnityEngine;

public class GridObject
{
    private Gridsystem gridSystem;
    private GridPosition gridPosition;
    private List<Player> unitList;

    public GridObject(Gridsystem gridSystem, GridPosition gridPosition)
    {
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
        unitList = new List<Player>();

    }

    public override string ToString()
    {
        string unitString = "";
        foreach (Player unit in unitList) 
        {
            unitString += unit + "\n";
        }
        return gridPosition.ToString() + "\n" + unitString;
    }

    public void AddUnit(Player unit) 
    {
        unitList.Add(unit);
    }
    public void RemoveUnit(Player unit) 
    {
        unitList.Remove(unit);
    }
    public List<Player> GetUnitList()
    {
        return unitList;
    }
}
