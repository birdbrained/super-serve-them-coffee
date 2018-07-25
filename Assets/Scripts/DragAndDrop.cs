using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private static DragAndDrop instance;
    public static DragAndDrop Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DragAndDrop>();
            }
            return instance;
        }
    }

    GameObject target;
    Rigidbody2D targetRB;
    bool isMouseDragging;
    Vector3 offsetValue;
    Vector3 positionOfScreen;

    // Use this for initialization
    void Start()
    {
		
    }
	
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //3D Raycast
            //RaycastHit hit;
            //target = GetClickedObject(out hit);

            //2D Raycast
            target = GetClickedObject2D();

            if (target != null)
            {
                targetRB = target.GetComponent<Rigidbody2D>();
                isMouseDragging = true;
                positionOfScreen = Camera.main.WorldToScreenPoint(target.transform.position);
                offsetValue = target.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z));
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            targetRB = null;
            target = null;
            isMouseDragging = false;
        }

        if (isMouseDragging && target != null)
        {
            Vector3 currScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z);
            Vector3 currPos = Camera.main.ScreenToWorldPoint(currScreenSpace) + offsetValue;
            target.transform.position = currPos;
            targetRB.velocity = new Vector2(targetRB.velocity.x, 0.0f);
        }
    }

    GameObject GetClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            if (hit.collider.gameObject.tag == "Dragable" || 
                hit.collider.gameObject.tag == "Bean" ||
                hit.collider.gameObject.tag == "Sugar" ||
                hit.collider.gameObject.tag == "Milk" ||
                hit.collider.gameObject.tag == "Topping" ||
                hit.collider.gameObject.tag == "Coffee")
            {
                target = hit.collider.gameObject;
            }
        }

        return target;
    }

    GameObject GetClickedObject2D()
    {
        GameObject target = null;
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "Dragable" ||
                hit.collider.gameObject.tag == "Bean" ||
                hit.collider.gameObject.tag == "Sugar" ||
                hit.collider.gameObject.tag == "Milk" ||
                hit.collider.gameObject.tag == "Topping" ||
                hit.collider.gameObject.tag == "Coffee")
            {
                target = hit.collider.gameObject;
            }
        }
        return target;
    }

    public void SetClickedObject(GameObject obj)
    {
        target = obj;
    }
}
