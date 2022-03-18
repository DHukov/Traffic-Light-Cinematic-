using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    GameObject OG;
    GameObject localGo;

    public int hours, minute, seconds;
    public int vertexes;
    public string primitiveType;

    public int newHours, newMinute, newSeconds;
    public int newVertexes;
    public string newPrimitiveType;
    //Generate start data of figure
    private void Start()
    {
        OG = GameObject.Find("RayCast_StartPoint");
        StartCoroutine(AddTag());

        hours = System.DateTime.Now.Hour;
        minute = System.DateTime.Now.Minute;
        seconds = System.DateTime.Now.Second;

        if (OG.GetComponent<FigureInitilizer>().figureType == FigureType.Cube)
            primitiveType = "Cube";
        if (OG.GetComponent<FigureInitilizer>().figureType == FigureType.Sphere)
            primitiveType = "Sphere";
        if (OG.GetComponent<FigureInitilizer>().figureType == FigureType.Capsule)
            primitiveType = "Capsule";

        vertexes = GetComponent<MeshFilter>().mesh.vertexCount / 3;
        localGo.gameObject.tag = "New_Figure";
    }
    //Call method with generating new data of figure
    public void NewDataChenger()
    {
        newVertexes = GetComponent<MeshFilter>().mesh.vertexCount / 3;
        newHours = System.DateTime.Now.Hour;
        newMinute = System.DateTime.Now.Minute;
        newSeconds = System.DateTime.Now.Second;

        if (OG.GetComponent<FigureInitilizer>().figureType == FigureType.Cube)
            newPrimitiveType = "Cube";
        if (OG.GetComponent<FigureInitilizer>().figureType == FigureType.Sphere)
            newPrimitiveType = "Sphere";
        if (OG.GetComponent<FigureInitilizer>().figureType == FigureType.Capsule)
            newPrimitiveType = "Capsule";
    }
    //If object at time spawn collided to gameobject with another tag 
    //spawning object will be destroyed and method tried spawning new object until won't succeed
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Figure" && !this.GetComponent<DragTarget>().objectDrag)
        {
            OG.GetComponent<FigureInitilizer>().Initialize();
            Destroy(this.gameObject);
        }
    }
    //Changed tag to prevent a recurrence
    IEnumerator AddTag()
    {
        yield return new WaitForSeconds(.1f);
        this.gameObject.tag = "Figure";
    }
}
