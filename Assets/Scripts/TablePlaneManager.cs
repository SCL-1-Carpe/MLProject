using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TablePlaneManager : MonoBehaviour
{
    public Vector3[] Points = new Vector3[4];
    public float Height, Width;
    public GameObject pobj, cobj;
    GameObject[] objs = new GameObject[4];
    public List<GameObject> Children;
    // Start is called before the first frame update
    void Start()
    {
        CalcPoints();
        objs[0] = Instantiate(pobj);
        objs[1] = Instantiate(pobj);
        objs[2] = Instantiate(pobj);
        objs[3] = Instantiate(pobj);
    }

    // Update is called once per frame
    void Update()
    {
        CalcPoints();
        objs[0].transform.position = Points[0];
        objs[1].transform.position = Points[1];
        objs[2].transform.position = Points[2];
        objs[3].transform.position = Points[3];
    }

    public void CalcPoints()
    {
        Points[0] = transform.position + (transform.forward * 5 * transform.localScale.z) + (transform.right * -5 * transform.localScale.x);
        Points[1] = transform.position + (transform.forward * 5 * transform.localScale.z) + (transform.right * 5 * transform.localScale.x);
        Points[2] = transform.position + (transform.forward * -5 * transform.localScale.z) + (transform.right * 5 * transform.localScale.x);
        Points[3] = transform.position + (transform.forward * -5 * transform.localScale.z) + (transform.right * -5 * transform.localScale.x);
        Width = 10 * transform.localScale.x;
        Height = 10 * transform.localScale.z;
    }

    public void AttatchCanvas(Transform transform, Vector2 NormalizedAnchor, float y)
    {
        transform.position = new Vector3(Mathf.Lerp(Points[0].x, Points[1].x, NormalizedAnchor.x), y, Mathf.Lerp(Points[0].z, Points[3].z, NormalizedAnchor.y));
    }
}
