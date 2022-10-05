using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RecordPlayerController : MonoBehaviour
{

    public GameObject platter;
    public GameObject needle;

    public AudioSource source;
    public AudioClip song1;
    public AudioClip song2;

    public XRSocketInteractor socket;

    private bool recordLoaded = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(recordLoaded) platter.transform.Rotate(0, 0.2f, 0);
    }

    public void playSound()
    {
        recordLoaded = true;
        needle.transform.Rotate(0, 50, 0);
        IXRSelectInteractable objName = socket.GetOldestInteractableSelected();
        if (objName.transform.name.Equals("Record_Chopin_Nocturne-no-2"))
        {
            source.clip = song1;
        } else source.clip = song2;
        source.Play();
    }

    public void stopSound()
    {
        needle.transform.Rotate(0, -50, 0);
        recordLoaded = false;
        source.Stop();
    }
}
