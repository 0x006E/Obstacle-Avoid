using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fallingBlockPrefab;
    public Vector2 spawnSizeMinMax;
    public float spawnAngle;
    GameObject _newFallingObject;
    Vector2 _screenHalfSizeWorldUnits;
    public Vector2 secondsBetweenSpawnsMinMax;
    float _nextSpawnTime;
    void Start()
    {
        _screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > _nextSpawnTime)
        {
            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
            float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.x, secondsBetweenSpawnsMinMax.y, Difficulty.GetDifficultyPercent());
            _nextSpawnTime = Time.time + secondsBetweenSpawns;
            Vector2 spawnPosition = new Vector2(Random.Range(-_screenHalfSizeWorldUnits.x, _screenHalfSizeWorldUnits.x), _screenHalfSizeWorldUnits.y + spawnSize);
            _newFallingObject = (GameObject)Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(0, 0, Random.Range(-spawnAngle, spawnAngle)));
            _newFallingObject.transform.localScale = Vector2.one * spawnSize;
        }
        /* if (newFallingObject != null)
        {
            if ((Mathf.Abs(newFallingObject.transform.position.x) > screenHalfSizeWorldUnits.x) || (Mathf.Abs(newFallingObject.transform.position.y) > screenHalfSizeWorldUnits.y))
            {
                Destroy(newFallingObject);
            }
        } */
    }
}
