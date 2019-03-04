using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{


    private Vector3 startPosition;

    public Vector3 StartPosition
    {
        get { return startPosition; }
        set { startPosition = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z != -10)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }
    }

    private IEnumerator ResetCamera()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("ResetCamera()");
        transform.position = startPosition;

    }
}
