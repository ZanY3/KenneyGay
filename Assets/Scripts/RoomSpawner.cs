using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public Direction direction;
    public enum Direction
    {
        Top, Bottom, Left, Right, None
    };

    private RoomVariants _variants;
    private int _rand;
    private bool _spawned = false;
    private float _waitTime = 3f;

    private void Start()
    {
        _variants = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomVariants>();
        Destroy(gameObject, _waitTime);
        Invoke("Spawn", Random.Range(0.1f, 0.2f));
    }
    public void Spawn()
    {
        if(!_spawned)
        {
            if(direction == Direction.Top)
            {
                _rand = Random.Range(0, _variants.TopRooms.Length);
                Instantiate(_variants.TopRooms[_rand], transform.position, _variants.TopRooms[_rand].transform.rotation);
            }
            else if (direction == Direction.Bottom)
            {
                _rand = Random.Range(0, _variants.BottomRooms.Length);
                Instantiate(_variants.BottomRooms[_rand], transform.position, _variants.BottomRooms[_rand].transform.rotation);
            }
            else if (direction == Direction.Left)
            {
                _rand = Random.Range(0, _variants.LeftRooms.Length);
                Instantiate(_variants.LeftRooms[_rand], transform.position, _variants.LeftRooms[_rand].transform.rotation);
            }
            else if (direction == Direction.Right)
            {
                _rand = Random.Range(0, _variants.RightRooms.Length);
                Instantiate(_variants.RightRooms[_rand], transform.position, _variants.RightRooms[_rand].transform.rotation);
            }
        }
        _spawned = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("RoomPoint") && collision.gameObject.GetComponent<RoomSpawner>()._spawned)
        {
            Destroy(gameObject);
        }
    }

}
