using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FigureType { Cube, Sphere, Capsule }
public class FigureInitilizer : MonoBehaviour
{
    public float rangeOfRay;
    public Camera cam;
    RaycastHit hit;
    public GameObject end_Point;
    public Material black_Material;

    float x;
    float y;
    public float z;
    public bool reUse;
    GameObject go3;
    public FigureType figureType;
    //Method called from interface button
    public void Initialize()
    {
        RandomisePoint();
        Shoot();
    }
    //Check posibility to create an object
    void Shoot()
    {
        if (Physics.Raycast(cam.transform.position, end_Point.transform.position, out hit, rangeOfRay))
        {
            if (hit.collider.gameObject.tag == "Plane")
            {
                if(figureType == FigureType.Capsule)
                    CreateCapsule();

                if (figureType == FigureType.Cube)
                    CreateCube();

                if (figureType == FigureType.Sphere)
                    CreateSphere();
            }
        }
    }
    //Randomise point on plane
    void RandomisePoint()
    {
        x = Random.Range((float)-8.8, (float)8.8);
        y = Random.Range((float)-5, (float)5);
        end_Point.transform.localPosition = new Vector3(x, y, z);
    }
    //Creating primitive, add position and other components
    void CreateMesh()
    {
        go3.GetComponent<MeshRenderer>().material = black_Material;
        go3.transform.localScale = new Vector3((float)0.5, (float)0.5, (float)0.5);

        go3.AddComponent<CheckCollision>();
        go3.AddComponent<DragTarget>();

        go3.AddComponent<Rigidbody>();
        go3.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        go3.transform.position = new Vector3(end_Point.transform.position.x - 10, end_Point.transform.position.y + 8, end_Point.transform.position.z - 10);
    }
    void CreateCube()
    {
        go3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        CreateMesh();
    }
    void CreateSphere()
    {
        go3 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        CreateMesh();
    }
    void CreateCapsule()
    {
        go3 = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        CreateMesh();
    }
    public void ChoiceCube() => figureType = FigureType.Cube;
    public void ChoiceSphere() => figureType = FigureType.Sphere;
    public void ChoiceCapsule() => figureType = FigureType.Capsule;
}
