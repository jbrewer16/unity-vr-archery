using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.XR.Interaction.Toolkit;

public static class ExtensionMethods
{

    /// <summary>
    /// Force deselect the selected interactable.
    ///
    /// This is an extension method for <c>XRBaseInteractable</c>.
    /// </summary>
    /// <param name="interactable">Interactable that has been selected by some interactor</param>
    [System.Obsolete]
    public static void ForceDeselect(this XRBaseInteractable interactable)
    {
        Debug.Log("Called!");
        interactable.interactionManager.CancelInteractableSelection(interactable);
        Assert.IsFalse(interactable.isSelected);
    }

    /// <summary>
    /// Force deselect any selected interactable for given interactor.
    ///
    /// This is an extension method for <c>XRBaseInteractor</c>.
    /// </summary>
    /// <param name="interactor">Interactor that has some interactable selected</param>
    public static void ForceDeselect(this XRBaseInteractor interactor)
    {
        Debug.Log("Called?");
        interactor.interactionManager.CancelInteractorSelection(interactor);
        Assert.IsFalse(interactor.isSelectActive);
    }

    /**public static class XRBaseInteractableExtension
    {
        
    }*/

}
