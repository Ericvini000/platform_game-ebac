using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{

    protected virtual void Collect() {
        OnCollect();
        gameObject.SetActive(false);
    }

    protected virtual void OnCollect() { }
}
