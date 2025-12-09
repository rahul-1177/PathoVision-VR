using UnityEngine;

public class LipSync : MonoBehaviour
{
    public SkinnedMeshRenderer faceMesh;   
    public string blendShapeName = "JawOpen"; 
    public float speed = 4f;  
    public float amplitude = 40f;

    private int blendShapeIndex;

    void Start()
    {
        if (faceMesh != null)
        {
            blendShapeIndex = faceMesh.sharedMesh.GetBlendShapeIndex(blendShapeName);
        }
    }

    void Update()
    {
        if (faceMesh != null && blendShapeIndex >= 0)
        {
            float value = (Mathf.Sin(Time.time * speed) + 1f) / 2f * amplitude;
            faceMesh.SetBlendShapeWeight(blendShapeIndex, value);
        }
    }
}
