using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetShaderProperty : MonoBehaviour
{
    private static readonly int lightDirID = Shader.PropertyToID("_World_Space_Light_Dir");
    private static readonly int viewDirID = Shader.PropertyToID("_Texture_View_World_Dir");
    private Renderer objectRenderer;
    private Material objectMaterial;
    public Camera mainCamera;
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        objectMaterial = objectRenderer.material;
    }
    
    void Update()
    {
        Vector3 lightDirection = CalculateLightDirection();
        Vector3 viewDirection = (mainCamera.transform.position - transform.position).normalized;
        objectMaterial.SetVector(lightDirID, lightDirection);
        objectMaterial.SetVector(viewDirID, viewDirection);
        Debug.Log("Light Direction: " + lightDirection);
        Debug.Log("View Direction: " + viewDirection);
    }
    
    Vector3 CalculateLightDirection()
    {
        Vector3 lightDirection = new Vector3(0, 0, 0);
        GameObject[] lights = GameObject.FindGameObjectsWithTag("Light");
        foreach (GameObject l in lights)
        {
            lightDirection += l.transform.forward;
        }
        return lightDirection.normalized;
    }
}
