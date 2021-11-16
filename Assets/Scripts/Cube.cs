using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Mesh { get; set; }
    private void Start()
    {
        Mesh = GetComponent<MeshRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag(Tags.Player))
        {
            GameObject target = other.gameObject;
            switch (target.tag)
            {
                case Tags.Enemy:
                    Devide();
                    break;
                case Tags.Neutral:
                    Add(target);
                    break;
                default:
                    break;
            }
        }
    }
    
    private void Devide()
    {
        Player.Instance.DeleteCube();
        Player.Instance.ChangeMaterial(1,Mesh);
        transform.parent = null;
        tag = Tags.Neutral;
    }
    private void Add(GameObject target)
    {
        Player.Instance.SetCube(target.transform);
    }
}
