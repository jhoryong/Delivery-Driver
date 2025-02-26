using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    //[SerializeField] float destroyDelay = 0.5f;
    [SerializeField] Color32 hasPackageColor = new Color32(49, 255, 0, 255);
    [SerializeField] Color32 noPackageColor = new Color32(255, 255, 255, 255);
    bool hasPackage = false;
    SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        string tag = other.tag;

        if (tag == "Package" && !hasPackage) {
            Debug.Log("Package");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject);
        }
        else if (tag == "Customer" && hasPackage) {
            Debug.Log("Delivered package!");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
