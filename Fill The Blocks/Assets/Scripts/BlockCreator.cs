using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCreator : MonoBehaviour
{
    public Block block;
    public bool CheckTouch = false;

    Vector3 creatPoint;
    Vector3 startPos;
    private void Start()
    {
        creatPoint = transform.position;
        creatPoint.y =2.0f;
        startPos = creatPoint;
    }

    private void OnMouseUp()
    {
        creatPoint = startPos;
        if (transform.rotation.y == 0)
        {
            creatPoint.z -= transform.localScale.z / 2;
            creatPoint.z -= 2;
        }
        else if (transform.rotation.y == 1f)
        {
            creatPoint.z += transform.localScale.z / 2;
            creatPoint.z += 2;
        }
        else if (transform.rotation.y <= -0.7071068f)
        {
            creatPoint.x += transform.localScale.z / 2;
            creatPoint.x += 2.0f;
        } 
        else if (transform.rotation.y <= 0.7071068f)
        {
            creatPoint.x -= transform.localScale.z / 2;
            creatPoint.x -= 2.0f;
        }
        Block obj = Instantiate(block, creatPoint, transform.rotation, GridManger.Instance.blocksT) as Block;
    }
 
}
