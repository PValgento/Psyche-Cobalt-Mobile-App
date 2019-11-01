using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sb_Camera : MonoBehaviour
{
    private float zoomAmount = 0f;
	private const float zoomMin = 7f;
	private const float zoomMax = 50f;
	private float currentZoom = 12f;
    void Start()
    {//Start is called before the first frame update
        
    }

    void Update()
    {//Camera Zoom
		zoomAmount = Input.GetAxis("Mouse ScrollWheel") * -150f * Time.deltaTime;
        /*if(zoomAmount > 0.01f || zoomAmount < -0.01f) //Stop super small zooms
        {*/
            currentZoom += zoomAmount;
            if(currentZoom < zoomMin)
                currentZoom = zoomMin;
            else if(currentZoom > zoomMax)
                currentZoom = zoomMax;
            this.transform.localPosition = new Vector3(0f, 0f, -1f * currentZoom);
            //this.transform.GetChild(0).localPosition = new Vector3(0f, currentZoom, 0f);//GetChild(0) is for rotation is decide to add back.
        //}
        /*
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            currentZoom += 2;
            if(currentZoom > zoomMin)
                currentZoom = zoomMin;
            else if(currentZoom < zoomMax)
                currentZoom = zoomMax;
        }
        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            currentZoom -= 2;
            if(currentZoom > zoomMin)
                currentZoom = zoomMin;
            else if(currentZoom < zoomMax)
                currentZoom = zoomMax;
        }
        this.transform.localPosition = new Vector3(0f, currentZoom, 0f);*/
    }
    public void ctl_Reset()
    {
        currentZoom = -1f * 12.0f;
    }
}