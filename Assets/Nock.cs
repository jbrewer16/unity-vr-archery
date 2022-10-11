using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nock : MonoBehaviour
{

    [SerializeField] GameObject _attachPoint;
    [SerializeField] SphereCollider notchTrigger;
    public Transform _prevArrowParent;
    public bool shootingArrow = false;

    // Start is called before the first frame update
    void Start()
    {
        notchTrigger = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Arrow") && !shootingArrow)
        {
            //arrowNocked = true;
            //Debug.Log(arrowNocked);
            //_prevArrowParent = other.transform.parent;
            other.transform.SetParent(_attachPoint.transform);
            other.attachedRigidbody.isKinematic = true;
            other.transform.position = _attachPoint.transform.position;
            other.transform.rotation = _attachPoint.transform.rotation;
            //notchTrigger.enabled = false;
        }
    }

    /**private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Arrow") && arrowNocked)
        {
            //_prevArrowParent = null;
            Debug.Log(arrowNocked);
            other.transform.SetParent(_prevArrowParent);
            other.attachedRigidbody.isKinematic = false;
            //arrowNocked = false;
            //other.transform.position = _attachPoint.transform.position;
            //other.transform.rotation = _attachPoint.transform.rotation;

        }
    }*/

    IEnumerator nockTimer()
    {
        //Debug.Log("TIMER");
        yield return new WaitForSeconds(3);
    }



}
