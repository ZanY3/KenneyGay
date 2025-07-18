using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public GameObject BlockForChange;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Block"))
        {
            Debug.Log("Wall Changed");
            Instantiate(BlockForChange, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
