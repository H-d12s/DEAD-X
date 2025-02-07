using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tracker : MonoBehaviour
{
   public Transform breadcrumblocation;
   public GameObject breadcrumbs;

    // Update is called once per frame
    void Update()
    {
        breadcrumbsnew();
    }

    public void breadcrumbsnew()
    {
        Instantiate(breadcrumbs,breadcrumblocation,true);
        DestroyImmediate(breadcrumbs);
    }
}
