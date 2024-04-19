using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Vector3[] wayPoints;
    private Vector3 mousePos;
    [SerializeField] private Transform _spawner;
    [SerializeField] private Rigidbody2D _rbSpawner;
    private void Start()
    {
        _spawner.position = new Vector3(_spawner.position.x, wayPoints[0].y, _spawner.position.z);
        mousePos = (Vector3)Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }

    private void Update()
    {
        mousePos = (Vector3)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePos.x != _spawner.position.x)
        {
            _spawner.position = new Vector3(mousePos.x, _spawner.position.y, _spawner.position.z);

            if (mousePos.x < wayPoints[0].x)
            {
                _spawner.position = new Vector3(wayPoints[0].x, _spawner.position.y, _spawner.position.z);
            }
            if (mousePos.x > wayPoints[wayPoints.Length - 1].x)
            {
                _spawner.position = new Vector3(wayPoints[wayPoints.Length - 1].x, _spawner.position.y, _spawner.position.z);
            }

        }
    }
    void OnDrawGizmos()
    {
        if (wayPoints == null) return;

        Gizmos.color = Color.red;
        foreach (Vector3 wayPoint in wayPoints)
        {
            Gizmos.DrawCube(wayPoint, new Vector3(0.5f, 0.5f, 0.5f));
        }
    }

}
