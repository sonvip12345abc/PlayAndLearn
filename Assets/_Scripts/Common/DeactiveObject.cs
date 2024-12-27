using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveObject : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke(nameof(DeActive), 1.25f);
    }

    private void DeActive()
    {
        this.gameObject.SetActive(false);
    }
}
