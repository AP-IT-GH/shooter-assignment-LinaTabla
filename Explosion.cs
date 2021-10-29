using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Explosion : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    [SerializeField] Rigidbody rigidBody;
    [SerializeField] float laserHitModifier = 100f;

    public void IveBeenHit(Vector3 pos)
    {
        GameObject gObj = Instantiate(explosion, pos, Quaternion.identity, transform) as GameObject;
        Destroy(gObj, 6f);
    }


    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            IveBeenHit(contact.point);
        }
    }

    public void AddForce(Vector3 hitPosition, Transform hitSource)
    {
        if (rigidBody == null)
        {
            return;
        }
        Vector3 forceVector = (hitSource.position - hitPosition).normalized;
        rigidBody.AddForceAtPosition(forceVector * laserHitModifier, hitPosition, ForceMode.Impulse);
    }
}
