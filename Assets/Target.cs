using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    private float _depth = 0.3f;

    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Arrow")
        {
            ArrowStick(other);
        }
    }

    private void ArrowStick(Collision other)
    {
        other.transform.Translate(_depth * -Vector3.up);
        other.transform.parent = this.transform;
        Destroy(other.gameObject.GetComponent<Arrow>());
        Destroy(other.rigidbody);
        Destroy(other.collider);
    }

}
