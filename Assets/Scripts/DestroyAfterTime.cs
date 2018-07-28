using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField]
    private float secondsToLive;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(DestroySelf(secondsToLive));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator DestroySelf(float f)
    {
        yield return new WaitForSeconds(f);
        Destroy(gameObject);
    }
}
