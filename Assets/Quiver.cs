using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Quiver2 : XRBaseInteractable
{
    [SerializeField] GameObject arrow;

    protected override void OnEnable()
    {
        base.OnEnable();
        selectEntered.AddListener(AttachArrowToHand);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        selectEntered.RemoveListener(AttachArrowToHand);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("I was called!");
    }

    public void AttachArrowToHand(SelectEnterEventArgs args)
    {
        Arrow arrow = SpawnArrow(args.interactorObject.transform);
        interactionManager.SelectEnter(args.interactorObject, arrow);
    }

    public Arrow SpawnArrow(Transform orientation)
    {
        GameObject arrowObj = Instantiate(arrow, orientation.position, orientation.rotation);
        return arrowObj.GetComponent<Arrow>();
    }

}


/**using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Quiver : XRBaseInteractable
{
    public GameObject arrowPrefab = null;

    protected override void OnEnable()
    {
        base.OnEnable();
        selectEntered.AddListener(CreateAndSelectArrow);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        selectEntered.RemoveListener(CreateAndSelectArrow);
    }

    private void CreateAndSelectArrow(SelectEnterEventArgs args)
    {
        // Create arrow, force into interacting hand
        Arrow arrow = CreateArrow(args.interactor.transform);
        interactionManager.ForceSelect(args.interactor, arrow);
    }

    private Arrow CreateArrow(Transform orientation)
    {
        // Create arrow, and get arrow component
        GameObject arrowObject = Instantiate(arrowPrefab, orientation.position, orientation.rotation);
        return arrowObject.GetComponent<Arrow>();
    }
}*/
