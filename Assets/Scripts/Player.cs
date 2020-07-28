using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    float _halfScreenWidthInWorldUnits;
    private void Start()
    {
        float halfPlayerWidth = transform.localScale.x / 2f;
        if (Camera.main != null)
        {
            var main = Camera.main;
            _halfScreenWidthInWorldUnits = main.aspect * main.orthographicSize + halfPlayerWidth;
        }

        // Update is called once per frame
    }

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float moveAmount = inputX * speed * Time.deltaTime;
        transform.Translate(Vector2.right * moveAmount);
        if (Mathf.Abs(transform.position.x) >= _halfScreenWidthInWorldUnits)
        {
            transform.Translate(Vector2.left * (2 * transform.position.x));
        }
    }
    private void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (triggerCollider.CompareTag("Falling Block"))
            Destroy(gameObject);
    }
    
}
