using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SelectTarget : MonoBehaviour
{
    public Camera cam;
    public GameObject figureInit;
    public GameObject dataInterface;
    public GameObject timeInterface;
    public GameObject vertexInterface;
    public GameObject primitiveType;
    public List<GameObject> primitives;

    public GameObject newFigureInit;
    public GameObject newDataInterface;
    public GameObject newTimeInterface;
    public GameObject newVertexInterface;
    public GameObject newPrimitiveType;

    public Mesh cubeMesh;
    public Mesh sphereMesh;
    public Mesh capsuleMesh;

    RaycastHit hitInfo;
    private void Start()
    {
        figureInit = this.gameObject;
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        timeInterface = GameObject.Find("TimeInterface");
        vertexInterface = GameObject.Find("VertexInterface");
        primitiveType = GameObject.Find("PrimitiveInterface");
        dataInterface = GameObject.Find("PrimitiveData");

        newTimeInterface = GameObject.Find("New_TimeInterface");
        newVertexInterface = GameObject.Find("New_VertexInterface");
        newPrimitiveType = GameObject.Find("New_PrimitiveInterface");
        newDataInterface = GameObject.Find("New_PrimitiveData");

        dataInterface.SetActive(false);
        newDataInterface.SetActive(false);
    }

    //In Update method, includes the corresponding interface and the selected figure changed color
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.gameObject.tag == "Figure")
                {
                    SetDataToInterface();
                    SetNewDataToInterface();
                    for (int i = 0; i <= primitives.Count - 1; i++)
                        primitives[i].GetComponent<MeshRenderer>().material.color = Color.black;

                    hitInfo.transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                    primitives.Add(hitInfo.transform.gameObject);
                }
                else if (hitInfo.collider.gameObject.tag == "Plane")
                {
                    dataInterface.SetActive(false);
                    newDataInterface.SetActive(false);
                    for (int i = 0; i <= primitives.Count-1; i++)
                        primitives[i].GetComponent<MeshRenderer>().material.color = Color.black;
                }
            }
        }
    }

    //Method "SetDataToInterface" set the data to interface with start data 
    void SetDataToInterface()
    {
        dataInterface.SetActive(true);
        timeInterface.GetComponent<Text>().text = 
            hitInfo.collider.gameObject.GetComponent<CheckCollision>().hours.ToString()
            + ":" + hitInfo.collider.gameObject.GetComponent<CheckCollision>().minute.ToString()
            + ":" + hitInfo.collider.gameObject.GetComponent<CheckCollision>().seconds.ToString();
        vertexInterface.GetComponent<Text>().text = hitInfo.collider.gameObject.GetComponent<CheckCollision>().vertexes.ToString();
        primitiveType.GetComponent<Text>().text = hitInfo.collider.gameObject.GetComponent<CheckCollision>().primitiveType;

    }
    //"SetNewDataToInterface" set the new data to antoher interface

    void SetNewDataToInterface()
    {
        newDataInterface.SetActive(true);
        newTimeInterface.GetComponent<Text>().text =
            hitInfo.collider.gameObject.GetComponent<CheckCollision>().newHours.ToString()
            + ":" + hitInfo.collider.gameObject.GetComponent<CheckCollision>().newMinute.ToString()
            + ":" + hitInfo.collider.gameObject.GetComponent<CheckCollision>().newSeconds.ToString();
        newVertexInterface.GetComponent<Text>().text = hitInfo.collider.gameObject.GetComponent<CheckCollision>().newVertexes.ToString();
        newPrimitiveType.GetComponent<Text>().text = hitInfo.collider.gameObject.GetComponent<CheckCollision>().newPrimitiveType;

    }
    //Set another primitive and refresh data in concrete object
    public void ChangePrimitive()
    {
        if(figureInit.GetComponent<FigureInitilizer>().figureType == FigureType.Cube)
            primitives[primitives.Count-1].gameObject.GetComponent<MeshFilter>().sharedMesh = cubeMesh;
        if (figureInit.GetComponent<FigureInitilizer>().figureType == FigureType.Sphere)
            primitives[primitives.Count - 1].gameObject.GetComponent<MeshFilter>().sharedMesh = sphereMesh;
        if (figureInit.GetComponent<FigureInitilizer>().figureType == FigureType.Capsule)
            primitives[primitives.Count - 1].gameObject.GetComponent<MeshFilter>().sharedMesh = capsuleMesh;
        primitives[primitives.Count - 1].GetComponent<CheckCollision>().NewDataChenger();
    }
    
}
