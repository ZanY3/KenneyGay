using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator Instance;

    public int MinRooms = 5;
    public int MaxRooms = 10;
    public int CurrentRoomCount = 0;

    public List<GameObject> SpawnedRooms = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void RegisterRoom(GameObject room)
    {
        CurrentRoomCount++;
        SpawnedRooms.Add(room);
    }

    public bool CanSpawnMoreRooms()
    {
        return CurrentRoomCount < MaxRooms;
    }
}
