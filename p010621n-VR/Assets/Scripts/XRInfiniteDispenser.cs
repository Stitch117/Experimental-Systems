using NUnit.Framework;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class XRInfiniteDispenser : MonoBehaviour
{
    [SerializeField] XRBaseInteractable m_InteractablePrefab;

    XRBaseInteractor m_Socket;

    private void Awake()
    {
        m_Socket = GetComponent<XRBaseInteractor>();
        Assert.IsNotNull(m_InteractablePrefab);
    }

    private void OnEnable()
    {
        m_Socket.selectExited.AddListener(OnSelectEntered);
    }
    private void OnDisable()
    {
        m_Socket.selectExited.RemoveListener(OnSelectEntered);
    }

    void OnSelectEntered(SelectExitEventArgs selectExitEventArgs)
    {
        Transform socketTransform = m_Socket.transform;
        XRBaseInteractable interactable = Instantiate(m_InteractablePrefab,socketTransform.position, socketTransform.rotation);

        m_Socket.interactionManager.SelectEnter((IXRSelectInteractor)m_Socket, interactable);
    }
}
