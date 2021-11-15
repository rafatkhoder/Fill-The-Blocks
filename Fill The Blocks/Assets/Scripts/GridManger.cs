using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManger : MonoBehaviour
{
    public static GridManger Instance;

    [SerializeField]
    private int rows = 5;
    [SerializeField]
    private int cols = 5;
    [SerializeField]
    private float tilesize = 1;

    public GameObject backgroungBlock;
    public GameObject btnBlock;
    public Transform blocksT;

    private GameObject myBlock;
   
    private int height = 0;

    
    public int size2 = 10;
    public int size3 = 15;
    public int size4 = 20;
    //float[] wayPoint;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if( row == 0)
                {
                    GameObject tile1 = (GameObject)Instantiate(btnBlock, transform);
                    tile1.transform.Rotate(0, 180f, 0);
                    height = 1;
                    myBlock = tile1;
                }
                else if (row == rows - 1)
                {
                    GameObject tile1 = (GameObject)Instantiate(btnBlock, transform);
                    myBlock = tile1;
                }
                else if (col == 0)
                {
                    GameObject tile1 = (GameObject)Instantiate(btnBlock, transform);
                    tile1.transform.Rotate(0, 90f, 0);
                    height = 1;
                    myBlock = tile1;
                }
                else if (col == cols - 1)
                {
                    GameObject tile1 = (GameObject)Instantiate(btnBlock, transform);
                    tile1.transform.Rotate(0, -90f, 0);
                    height = 1;
                    myBlock = tile1;
                }
                else
                {
                    GameObject tile = (GameObject)Instantiate(backgroungBlock, transform);
                    height = 0;
                    myBlock = tile;
                }
                float posX = col * tilesize;
                float posY = row * -tilesize;
                if ((row == 0 && col == 0) || (row == 0 && col == cols -1) ||(row == rows-1 && col == 0) ||((row == rows - 1 && col == cols-1)))
                {
                    Destroy(myBlock);
                }
                myBlock.transform.position = new Vector3(posX, height, posY);
            }
        }
       
        float gridW = cols * tilesize;
        float gridH = rows * tilesize;

        transform.position = new Vector3(-gridW / 2 + tilesize / 2,0, gridH / 2 - tilesize / 2);
    }

   
}
