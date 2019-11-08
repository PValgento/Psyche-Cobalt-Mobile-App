using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_MenuCamera : MonoBehaviour
{
    protected Vector3 rotateSpeed = new Vector3(1f, 2f, -1f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(rotateSpeed*Time.deltaTime);
    }
}
