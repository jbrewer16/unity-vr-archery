using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketEvents : MonoBehaviour
{
    XRSocketInteractor socket;

    //public Light light;
    //public Color defaultLightColor;

    // Start is called before the first frame update
    void Awake()
    {
        //defaultLightColor = light.color;
        socket = gameObject.GetComponent<XRSocketInteractor>();
        //socket.selectEntered.AddListener(ColorChange);
        socket.hoverEntered.AddListener(attachArrow);
        //socket.onHoverExited.AddListener(detachArrow);
        //socket.onSelectEntered.AddListener();
        //socket.onSelectExited.AddListener(LightsOut);
    }

    private void attachArrow(HoverEnterEventArgs arg0)
    {
        throw new NotImplementedException();
    }

    public void attachArrow(XRBaseInteractable obj)
    {
        //Debug.Log("Starting timer");
        //socket.StartManualInteraction(obj);
        //StartCoroutine(timer());
        obj.ForceDeselect();
    }

    IEnumerator timer()
    {
        Debug.Log("Starting timer");
        yield return new WaitForSeconds(5);
        Debug.Log("Ending timer");
    }

    [System.Obsolete]
    public void detachArrow(XRBaseInteractable obj)
    {
        obj.ForceDeselect();
        //socket.EndManualInteraction();
        //socket.interactionManager.CancelInteractorSelection(obj);
    }

    /**public void ColorChange(XRBaseInteractable obj)
    {
        light.gameObject.SetActive(true);
        ColorChange colorChange = obj.gameObject.GetComponent<ColorChange>();
        if(colorChange != null)
        {
            light.color = colorChange.color;
        } else
        {
            light.color = defaultLightColor;
        }
    }

    public void LightsOut(XRBaseInteractable obj)
    {
        light.color = defaultLightColor;
    }*/

}
