using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 speedMinMax;
    static float _visibleHeightThreshold;
    private void Start()
    {
        if (Camera.main != null) _visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        var speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent()); 
        transform.Translate(Vector2.down * (speed * Time.deltaTime));
        if (transform.position.y < _visibleHeightThreshold)
            Destroy(gameObject);
    }
}
