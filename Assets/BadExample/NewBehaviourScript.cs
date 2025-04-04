using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoPlaces : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    public Transform AllPlacespoint;
    Transform[] arrayPlaces;
    private int NumberOfPlaceInArrayPlaces;

    void Start()
    {
        arrayPlaces = new Transform[AllPlacespoint.childCount];

        for (int i = 0; i < AllPlacespoint.childCount; i++)
            arrayPlaces[i] = AllPlacespoint.GetChild(i).GetComponent<Transform>();
    }

    public void Update()
    {
        var _pointByNumberInArray = arrayPlaces[NumberOfPlaceInArrayPlaces];
        transform.position = Vector3.MoveTowards(transform.position, _pointByNumberInArray.position, _movementSpeed * Time.deltaTime);

        if (transform.position == _pointByNumberInArray.position)
            NextPlaceTakerLogic();
    }

    public Vector3 NextPlaceTakerLogic()
    {
        NumberOfPlaceInArrayPlaces++;

        if (NumberOfPlaceInArrayPlaces == arrayPlaces.Length)
            NumberOfPlaceInArrayPlaces = 0;

        var thisPointVector = arrayPlaces[NumberOfPlaceInArrayPlaces].transform.position;
        transform.forward = thisPointVector - transform.position;

        return thisPointVector;
    }
}