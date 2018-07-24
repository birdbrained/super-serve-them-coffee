using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItemOnClick : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnObject;

    // Use this for initialization
    void Start () {
		
    }
	
    // Update is called once per frame
    void Update () {
		
    }

    private void OnMouseDown()
    {
        GameObject spawnedObj = Instantiate(spawnObject, transform.position, transform.rotation);
        DragAndDrop.Instance.SetClickedObject(spawnedObj);
    }
}
