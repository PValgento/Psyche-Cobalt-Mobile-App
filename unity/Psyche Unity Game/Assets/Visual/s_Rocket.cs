using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_Rocket : MonoBehaviour
{
    public GameObject coreBooster;
    public GameObject lSideBooster;
    public GameObject rSideBooster;
    public GameObject lFairing;
    public GameObject rFairing;
    public GameObject probe; private float delay = 0.01f;

    public bool isSideDetached = false;
    public bool isFairingDetached = false;
    public bool isCoreDetached = false;

    void Start()
    {// Start is called before the first frame update
        //StartCoroutine("DetachBoosters");
        //StartCoroutine("DetachFairings");
        //StartCoroutine("DetachCore");

    }
    void Awake()
    {

    }
    void Update()
    {
        if(delay > 0f) { delay -= Time.deltaTime; }
        else
        {//Have to add a delay and do in update, because the object doesn't exist correctly yet or something to do this is Awake()
            Transform temp = this.transform.parent;
            probe = temp.GetChild(0).gameObject; //Get the probe object.
            probe.SetActive(false);
        }
        if(this.transform.position.y > 200f)
            StartCoroutine("DetachBoosters");
        if(this.transform.position.y > 240f)
            StartCoroutine("DetachFairings");
        if(this.transform.position.y > 300f)
            StartCoroutine("DetachCore");
    }

    IEnumerator DetachBoosters()
    {
        Debug.Log("Side boosters detached!");
        float timer = 10f;
        float detachSpeed = 2f;
        isSideDetached = true;
        //Shutdown particle system here..
        //lSideBooster.transform.parent = null;
        //rSideBooster.transform.parent = null;
        while(isSideDetached)
        {
            timer -= Time.deltaTime;
            if (timer > 9.9f)
            {//Only move off to side at first.
                lSideBooster.transform.localPosition = new Vector3(lSideBooster.transform.localPosition.x, lSideBooster.transform.localPosition.y - (detachSpeed * 0.45f) * Time.deltaTime, lSideBooster.transform.localPosition.z - (detachSpeed * 1f) * Time.deltaTime);
                rSideBooster.transform.localPosition = new Vector3(rSideBooster.transform.localPosition.x, rSideBooster.transform.localPosition.y - (detachSpeed * 0.45f) * Time.deltaTime, rSideBooster.transform.localPosition.z + (detachSpeed * 1f) * Time.deltaTime);
            }
            else
            {//Z is move away horizontal, y is move away vertical.
                lSideBooster.transform.localPosition = new Vector3(lSideBooster.transform.localPosition.x, lSideBooster.transform.localPosition.y - (detachSpeed * 0.45f) * Time.deltaTime, lSideBooster.transform.localPosition.z);
                rSideBooster.transform.localPosition = new Vector3(rSideBooster.transform.localPosition.x, rSideBooster.transform.localPosition.y - (detachSpeed * 0.45f) * Time.deltaTime, rSideBooster.transform.localPosition.z);
            }
            if(timer > 0f)
                yield return new WaitForSeconds(0);
            else
                isSideDetached = false;
        }
    }
    IEnumerator DetachFairings()
    {
        Debug.Log("Fairings detached!");
        float timer = 10f;
        float detachSpeed = 0.5f;
        isFairingDetached = true;
        probe.SetActive(true);
        //lFairing.transform.parent = null;
        //rFairing.transform.parent = null;
        while(isFairingDetached)
        {
            timer -= Time.deltaTime;
            if (timer > 9.9f)
            {//Only move off to side at first.
                lFairing.transform.localPosition = new Vector3(lFairing.transform.localPosition.x, lFairing.transform.localPosition.y + (detachSpeed * 0.01f) * Time.deltaTime, lFairing.transform.localPosition.z - (detachSpeed * 0.01f) * Time.deltaTime);
                rFairing.transform.localPosition = new Vector3(rFairing.transform.localPosition.x, rFairing.transform.localPosition.y - (detachSpeed * 0.01f) * Time.deltaTime, rFairing.transform.localPosition.z - (detachSpeed * 0.01f) * Time.deltaTime);
            }
            else
            {//Y is move away horizontal, z is move away vertical.
                lFairing.transform.localPosition = new Vector3(lFairing.transform.localPosition.x, lFairing.transform.localPosition.y, lFairing.transform.localPosition.z - (detachSpeed * 0.05f) * Time.deltaTime);
                rFairing.transform.localPosition = new Vector3(rFairing.transform.localPosition.x, rFairing.transform.localPosition.y, rFairing.transform.localPosition.z - (detachSpeed * 0.05f) * Time.deltaTime);
            }
            if(timer > 0f)
                yield return new WaitForSeconds(0);
            else
                isFairingDetached = false;
        }
    }
    IEnumerator DetachCore()
    {
        Debug.Log("Core detached!");
        float timer = 10f;
        float detachSpeed = 2f;//0.5f;
        isCoreDetached = true;
        //coreBooster.transform.parent = null;
        while(isCoreDetached)
        {
            timer -= Time.deltaTime;
            coreBooster.transform.localPosition = new Vector3(coreBooster.transform.localPosition.x, coreBooster.transform.localPosition.y - (detachSpeed * 0.45f) * Time.deltaTime, coreBooster.transform.localPosition.z);
            if(timer > 0f)
                yield return new WaitForSeconds(0);
            else
                isCoreDetached = false;
        }
    }
}
