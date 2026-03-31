using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class Week12Tilechecker : MonoBehaviour
{
    //Array to store tile data 
    public Tilemap tilemap;
    public Tile[] grass;
    public Tile tempTile;

    public bool Grass = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

//fuction that gets tile data on click
    public void grassCheck()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector3Int cellPos = tilemap.WorldToCell(mousePos);
        Vector3 pos = tilemap.GetCellCenterWorld(cellPos);

        tempTile = (Tile)tilemap.GetTile(cellPos);

        Grass = false;
        //for loop to check clicked tile vs array
        for (int i = 0; i < grass.Length; i++)
        {
            if (grass[i] == tempTile)
            {
                Grass = true;
            }
        }
    }
    
    
}
