using UnityEngine;
using System.Collections;
using System;
using DG.Tweening;

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
        //transform.localPosition = m_shelvedPosition;
        //transform.localRotation = m_shelvedRotation;
        transform.DOMove(transform.parent.position + m_shelvedPosition, 0.35f);
        transform.DORotate(m_shelvedRotation.eulerAngles, 0.15f);
    }

    public void Unshelf(Vector3 position, Quaternion rotation)
    {
        //transform.localPosition = position;
        //transform.localRotation = rotation;
        transform.DOMove(transform.parent.position + position, 0.35f);
        transform.DORotate(rotation.eulerAngles, 0.35f);
    }
}
