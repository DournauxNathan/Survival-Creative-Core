using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControl : MonoBehaviour
{
    public Camera MainCamera;
    public GameObject Marker;
    public LayerMask mask;

    private Unit m_Selected;
    private Vector3 m_newPosition;

    // Start is called before the first frame update
    void Awake()
    {
        m_Selected = GameObject.Find("Player").GetComponent<Unit>();
        Marker.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = MainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, mask))
            {
                if (m_Selected != null)
                {
                    m_Selected.GoTo(hit.point);
                    m_newPosition = hit.point;
                }
            }
        }
        else if (m_Selected != null && Input.GetMouseButtonDown(1))
        {
            var ray = MainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //the Collider could be a children of an interable or the ground so check if its one of this is true

            }
        }

        MarkerHandling();
    }

    //Handle displaying the marker above the mouse position that was selected (or hiding it)
    void MarkerHandling()
    {
        if (m_Selected == null && Marker.activeInHierarchy)
        {
            Marker.SetActive(false);
            Marker.transform.SetParent(null);
        }
        else if (m_Selected != null && Marker.transform.parent != m_Selected.transform)
        {
            Marker.SetActive(true);
            //Marker.transform.SetParent(m_newPosition, false);
            Marker.transform.localPosition = new Vector3(m_newPosition.x, 0f, m_newPosition.z);
        }
    }
}
