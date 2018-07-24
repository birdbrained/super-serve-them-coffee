using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class DragAndDrop2D : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
    void Update ()
    {
		
    }

    private void OnMouseDown()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    private void OnMouseDrag()
    {
        Vector3 currScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 currPos = Camera.main.ScreenToWorldPoint(currScreenPoint) + offset;
        transform.position = currPos;
        rb.velocity = new Vector2(rb.velocity.x, 0.0f);
    }
}
