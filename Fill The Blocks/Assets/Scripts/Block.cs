using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 5f;
    public Transform rayPoint;
    float check;
    bool canRepat = true;
   
    public float rayLong = 50f;
    public void MoveBlock()
    {
        if (canRepat)
        {
            canRepat = false;
            if (check >= transform.localScale.z -1 )
            {
                rb.velocity = rb.transform.forward * speed;
            }
            else
            {
                rb.velocity = rb.transform.forward * -speed;
                Destroy(gameObject, .3f);
            }
        }
    } 
   
    private void Start()
    {
        SetBlockSize();

        
    }
    private void FixedUpdate()
    {
        RaycastHit hit;
        Ray blockRay = new Ray(rayPoint.position, transform.forward);
        if(Physics.Raycast(blockRay,out hit))
        {
            if(hit.collider.gameObject.tag == "Block" || hit.collider.gameObject.tag == "BtnBlock")
            {
                Debug.Log(hit.collider.gameObject.name);
                float dis = Vector3.Distance(rayPoint.position, hit.point);
                check = dis;
                if(dis <= 0.1f)
                {
                    StopMoving();
                }
                else
                {
                    MoveBlock();
                }
                
            }
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(rayPoint.position, transform.forward * rayLong);
    }
    void SetBlockSize()
    {
        if (BlockUIScript.Instance.blocks == BlockUIScript.Blocks.block2)
        {
            transform.localScale = new Vector3(5f, 1, GridManger.Instance.size2);
        }
        else if (BlockUIScript.Instance.blocks == BlockUIScript.Blocks.block3)
        {
            transform.localScale = new Vector3(5f, 1, GridManger.Instance.size3);
        }
        else
        {
            transform.localScale = new Vector3(5f, 1, GridManger.Instance.size4);
        }
    }
    void StopMoving()
    {
        //rb.isKinematic = true;
        speed = 0;
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
  
}
