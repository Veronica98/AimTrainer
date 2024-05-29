using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetButtonsScale : MonoBehaviour
{
   public void OnHover()
    {
        gameObject.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }

    public void NotOnHover()
    {
        gameObject.transform.localScale = Vector3.one;
    }
}
