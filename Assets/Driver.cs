using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float steerSpeed = 100f;
    [SerializeField] float slowSpeed = 5f;
    [SerializeField] float boostSpeed = 20f;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(0, moveAmount, 0);
        if (moveAmount > 0) {
            transform.Rotate(0, 0, -steerAmount);
        } else if (moveAmount < 0) {
            transform.Rotate(0, 0, steerAmount);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        moveSpeed = slowSpeed;
        StartCoroutine("ResetSpeed");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        string tag = other.tag;

        if (tag == "Booster") {
            moveSpeed = boostSpeed;
            // make move speed go back to normal after 5 seconds
            StartCoroutine("ResetSpeed");
        }
    }

    IEnumerator ResetSpeed() {
        yield return new WaitForSeconds(1);
        moveSpeed = 10f;
    }
}
