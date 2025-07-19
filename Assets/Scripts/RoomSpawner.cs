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
        if (!_spawned && LevelGenerator.Instance.CanSpawnMoreRooms())
        {
            GameObject roomToSpawn = null;

            switch (direction)
            {
                case Direction.Top:
                    _rand = Random.Range(0, _variants.TopRooms.Length);
                    roomToSpawn = _variants.TopRooms[_rand];
                    break;
                case Direction.Bottom:
                    _rand = Random.Range(0, _variants.BottomRooms.Length);
                    roomToSpawn = _variants.BottomRooms[_rand];
                    break;
                case Direction.Left:
                    _rand = Random.Range(0, _variants.LeftRooms.Length);
                    roomToSpawn = _variants.LeftRooms[_rand];
                    break;
                case Direction.Right:
                    _rand = Random.Range(0, _variants.RightRooms.Length);
                    roomToSpawn = _variants.RightRooms[_rand];
                    break;
            }

            if (roomToSpawn != null)
            {
                GameObject newRoom = Instantiate(roomToSpawn, transform.position, roomToSpawn.transform.rotation);
                LevelGenerator.Instance.RegisterRoom(newRoom);
            }

            _spawned = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("RoomPoint") && collision.gameObject.GetComponent<RoomSpawner>()._spawned)
        {
            Destroy(gameObject);
        }
    }

}
