using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MovingZone : MonoBehaviour
{

    #region Objects

    // Plane object
    [SerializeField]
    private GameObject p_VisualPlane;

    // Bottom Left corner
    [SerializeField]
    private Transform t_BottomLeft;

    public Transform BottomLeft
    {
        get { return t_BottomLeft; }
    }

    // Top Right corner
    [SerializeField]
    private Transform t_TopRight;

    public Transform TopRight
    {
        get { return t_TopRight; }
    }

    #endregion

    #region Settings

    // Force Plane to be a box
    [SerializeField]
    private bool b_ForceBox;

    // Force Plane to be a screen-shaped rectangle
    [SerializeField]
    private bool b_ForceRectangle;

    #endregion

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // Force determination objects to y=0, and BottomLeft at least -1, -1 related to TopRight
        float BottomLeftX = BottomLeft.position.x;
        float BottomLeftZ = BottomLeft.position.z;

        if (TopRight.position.x - BottomLeft.position.x < 5)
        {
            BottomLeftX = TopRight.position.x - 5;
        }

        if (TopRight.position.z - BottomLeft.position.z < 5)
        {
            BottomLeftZ = TopRight.position.z - 5;
        }

        BottomLeft.position = new Vector3(BottomLeftX, transform.position.y, BottomLeftZ);
        TopRight.position = new Vector3(TopRight.position.x, transform.position.y, TopRight.position.z);


        // Measure distance between determination objects
        float xDistance = t_TopRight.position.x - t_BottomLeft.position.x;
        float zDistance = t_TopRight.position.z - t_BottomLeft.position.z;


        // Change Plane size and position
        p_VisualPlane.transform.position = new Vector3(t_BottomLeft.position.x + xDistance / 2, transform.position.y, t_BottomLeft.position.z + zDistance / 2);
        p_VisualPlane.transform.localScale = new Vector3(xDistance / 10, 1, zDistance / 10);


    }

    // Draw BottomLeft and TopRight
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(t_BottomLeft.position, new Vector3(1, 1, 1));
        Gizmos.DrawWireCube(t_TopRight.position, new Vector3(1, 1, 1));
    }

}
