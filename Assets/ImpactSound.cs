using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactSound : MonoBehaviour
{

    public AudioSource source;
    public AudioClip impact;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //float volume = gameObject.GetComponent<Rigidbody>().velocity.magnitude;
        source.PlayOneShot(impact, 0.5f);
    }

}
