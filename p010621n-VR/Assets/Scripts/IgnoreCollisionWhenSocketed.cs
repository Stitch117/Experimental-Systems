using NUnit.Framework;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class IgnoreCollisionWhenSocketed : MonoBehaviour
{
    XRSocketInteractor _socket;

    [SerializeField] Collider _ourCollider = null;
    Collider _theirCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _socket = GetComponent<XRSocketInteractor>();
        Assert.IsNotNull( _socket );

        if (_ourCollider == null) //checks in inspector
        {
            _ourCollider = GetComponent<Collider>();
        }

        _socket.selectEntered.AddListener(OnSelectEntered);
        _socket.selectExited.AddListener(OnSelectExited);
    }

    void OnSelectEntered(SelectEnterEventArgs args)
    {
        GameObject other = args.interactableObject.transform.gameObject;
        _theirCollider = other.GetComponent<Collider>();

        //ignore on socketed
        Physics.IgnoreCollision(_ourCollider, _theirCollider, true);
    }

    void OnSelectExited(SelectExitEventArgs args)
    {
        Physics.IgnoreCollision(_ourCollider,_theirCollider, false);
    }
}
