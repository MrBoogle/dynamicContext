using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class context : MonoBehaviour
{   int x = 0;
    int y = 0;
    Vector2[] offsets =
    {
    new Vector2(-1, 1),
    new Vector2(-1, 0),
    new Vector2(-1, -1),
    new Vector2(0, -1),
    new Vector2(0, -2),
    new Vector2(0, -3)
    };
    int numOffsets = 4;
    public GameObject myPrefab;
    GameObject thisFireball;

    int gridSize = 10;
    GameObject[,] grid;
    // Start is called before the first frame update
    void Start()
    {
        //Initialize 2d grid
        
        grid = new GameObject[gridSize, gridSize];
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                
                grid[i,j] = (GameObject)Instantiate(myPrefab, new Vector3(i * 1.2f, j * 1.2f, 0), Quaternion.identity);
                
                grid[i,j].GetComponent<Renderer>().material.color = new Color(0, 0, 0);
            }
        }
        InvokeRepeating("UpdateGrid", 2.0f, 0.5f);

    }
    
    void UpdateGrid() {
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                
                grid[i,j].GetComponent<Renderer>().material.color = new Color(0, 0, 0);
            }
        }
        numOffsets = 4;
        grid[x,y].GetComponent<Renderer>().material.color = new Color(1, 1, 1);//Color.white;
        for (int i = 0; numOffsets > 0 && i < 6; i++) {
            
            int ii = (x + (int)offsets[i].x);
            int ij = (y + (int)offsets[i].y);
            Debug.Log("x: " + ii + " y: " + ij);
            if (ii >= 0 && ii < gridSize && ij >= 0 && ij < gridSize)
            {    
                Debug.Log("x: " + ii + " y: " + ij);
                grid[ii, ij].GetComponent<Renderer>().material.color = new Color(0.93f, 1f, 0.17f);
                numOffsets--;
            }
            //i--;
            
        }
        y++;
        if (y%gridSize == 0) {
            y = 0;
            x++;
        }
        
        x = x%gridSize;
        
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
