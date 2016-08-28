using UnityEngine;
using System.Collections;
using System;

public class TabletRoot : MonoBehaviour
{
    [NonSerialized]
    public Vector3 m_shelvedPosition;
    [NonSerialized]
    public Quaternion m_shelvedRotation;

    void Awake()
    {
        m_shelvedPosition = transform.localPosition;
        m_shelvedRotation = transform.localRotation;
    }

    public void ReturnToShelf()
    {
        transform.localPosition = m_shelvedPosition;
        transform.localRotation = m_shelvedRotation;
    }

    public void Unshelf(Vector3 position, Quaternion rotation)
    {
        transform.localPosition = position;
        transform.localRotation = rotation;
    }
}
