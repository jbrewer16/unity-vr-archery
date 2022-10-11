using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BowString : MonoBehaviour
{

    private LineRenderer _lineRenderer;
    [SerializeField] private Transform[] _points;
    [SerializeField] private GameObject parentString;
    [SerializeField] private GameObject nock;
    [SerializeField] private GameObject nockAttach;
    [SerializeField] private XRGrabInteractable middleXRGrabScript;
    [SerializeField] private XRGrabInteractable bowXRGrabScript;
    [SerializeField] private float transitionSpeed = 30;

    private float startingPosX = 0;
    private float startingPosY = 0.072f;
    private float startingPosZ = 0.071f;
    private float minPosY = -0.4f;
    private float maxPosY = 0.072f;
    private bool isGrabbed = false;
    private bool pullEventStarted = false;
    private Nock nockScript;

    // Start is called before the first frame update
    void Start()
    {
        
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.startWidth = 0.02f;
        _lineRenderer.endWidth = 0.02f;
        nockScript = nock.GetComponent<Nock>();

    }

    // Update is called once per frame
    void Update()
    {

        Transform endPosition = nock.transform;

        if (bowXRGrabScript.isGrabbed && middleXRGrabScript.isGrabbed)
        {
            pullEventStarted = true;
            _points[1].transform.localRotation = Quaternion.identity;
            _points[1].transform.localPosition = new Vector3(
                Mathf.Clamp(_points[1].transform.localPosition.x, startingPosX, startingPosX),
                Mathf.Clamp(_points[1].transform.localPosition.y, minPosY, maxPosY),
                Mathf.Clamp(_points[1].transform.localPosition.z, startingPosZ, startingPosZ)
            );
            nock.transform.localPosition = _points[1].transform.localPosition;
        } else if(bowXRGrabScript.isGrabbed && pullEventStarted && !middleXRGrabScript.isGrabbed)
        {

            if (hasArrow())
            {
                float arrowForce = calculateForce(endPosition.localPosition.y);
                //Debug.Log("There's an arrow!");
                nockScript.shootingArrow = true;
                Transform childArrow = nockAttach.transform.GetChild(0);
                Rigidbody childRigid = childArrow.GetComponent<Rigidbody>();
                childRigid.isKinematic = false;
                childArrow.SetParent(nockScript._prevArrowParent);
                childRigid.AddForce((-childArrow.up)*arrowForce, ForceMode.Impulse);
            }
            //_points[1].transform.localPosition = new Vector3(startingPosX, maxPosY, startingPosZ);
            Vector3 newPosition = new Vector3(startingPosX, maxPosY, startingPosZ);
            _points[1].transform.localPosition = Vector3.Lerp(_points[1].transform.localPosition, newPosition, Time.deltaTime * transitionSpeed);
            nock.transform.localPosition = Vector3.Lerp(_points[1].transform.localPosition, newPosition, Time.deltaTime * transitionSpeed);
            StartCoroutine(waitForShoot());
        }

        _lineRenderer.positionCount = _points.Length;
        for(int i = 0; i < _points.Length; i++)
        {
            _lineRenderer.SetPosition(i, _points[i].position);
        }

    }

    private float calculateForce(float endPosition)
    {
        return Mathf.Abs((endPosition / 0.472f) * 20);
    }

    IEnumerator waitForShoot()
    {
        yield return new WaitForSeconds(1);
        pullEventStarted = false;
        nockScript.shootingArrow = false;
    }

    private bool hasArrow()
    {
        return (nockAttach.transform.childCount > 0);
    }

}
