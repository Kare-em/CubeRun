using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _height;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private Material[] materials;//0-Player, 1-Neutral, 2-Enemy
    private int _cubesCount = 0;

    //singleton
    public static Player Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance == this)
            Destroy(this);
    }
    //
    public void ChangeMaterial(int state,MeshRenderer meshRenderer)
    {
        meshRenderer.material=materials[state];
    }
    public float GetHeight()
    {
        return _height * _cubesCount;
    }
    public void DeleteCube()
    {
        _cubesCount--;
        if (_cubesCount < 0)
            GameController.Instance.ReloadGame();
    }
    public void SetCube(Transform cube)
    {
        _cubesCount++;

        transform.position += Vector3.up * _height;

        cube.tag = Tags.Player;
        cube.parent = transform;
        cube.localPosition = _height * _cubesCount*Vector3.down;

        var mesh = cube.GetComponent<Cube>().Mesh;
        ChangeMaterial(0, mesh);
        
    }
}
