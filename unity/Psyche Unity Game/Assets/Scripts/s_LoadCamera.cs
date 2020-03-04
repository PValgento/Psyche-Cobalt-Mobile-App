using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_LoadCamera : MonoBehaviour
{
    protected Vector3 rotateSpeed = new Vector3(0f, 0f, -16f);
    void Start()
    {//Start is called before the first frame update

    }

    void Update()
    {//Update is called once per frame
        this.transform.Rotate(rotateSpeed*Time.deltaTime);
    }
}
