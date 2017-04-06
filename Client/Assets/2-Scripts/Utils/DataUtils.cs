using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using es.upm.fi.rmi;

public class DataUtils  {


    public static Vector3 ToUPosition(Position rmiPosition)
    {
        return new Vector3(rmiPosition.x, rmiPosition.y, rmiPosition.z);
    }

    public static Quaternion ToURotation(Rotation rmiRotation)
    {
        return new Quaternion(rmiRotation.x, rmiRotation.y, rmiRotation.z, rmiRotation.w);
    }

    public static Position ToRmiPosition(Vector3 uPosition)
    {
        return new Position(uPosition.x, uPosition.y, uPosition.z); 
    }

    public static Rotation ToRmiRotation(Quaternion uRotation)
    {
        return new Rotation(uRotation.x, uRotation.y, uRotation.z, uRotation.w);
    }

}
