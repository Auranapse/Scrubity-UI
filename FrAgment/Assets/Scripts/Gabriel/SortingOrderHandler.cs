using UnityEngine;
using System.Collections;

public class SortingOrderHandler : MonoBehaviour
{
    public enum type
    {
        MeshRenderer,
        Mesh,
    }

    public type ObjectType;
    public string SortingLayerName = "Default";
    public int SortingOrder = 0;

    // Use this for initialization
    void Start()
    {
        switch(ObjectType)
        {
            case type.Mesh:
                
                break;
            case type.MeshRenderer:
                gameObject.GetComponent<MeshRenderer>().sortingLayerName = SortingLayerName;
                gameObject.GetComponent<MeshRenderer>().sortingOrder = SortingOrder;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
