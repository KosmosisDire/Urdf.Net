using System;
using System.Numerics;
using System.Xml;
using UrdfToolkit.Extensions;

namespace UrdfToolkit.Urdf
{

public struct UrdfOriginDef
{
    /// <summary>
    /// Right, Up, Forward <br/>
    /// Used in the Unity coordinate system.
    /// </summary>
    public Vector3 xyzRUF;

    /// <summary>
    /// Right, Up, Forward <br/>
    /// Used in the Unity coordinate system.
    /// </summary>
    public Quaternion rotationRUF;

    public Vector3 xyz;
    public Vector3 rpy;


    public UrdfOriginDef(XmlNode source)
    {
        var xyzValues = source.Attributes?["xyz"]?.Value.Split(' ');
        var rpyValues = source.Attributes?["rpy"]?.Value.Split(' ');

        if (xyzValues?.Length != 3)
        {
            xyz = Vector3.Zero;
            xyzRUF = Vector3.Zero;
        }
        else
        {
            xyz = new Vector3(
                    xyzValues[0].ParseFloatOrDefault(0),
                    xyzValues[1].ParseFloatOrDefault(0),
                    xyzValues[2].ParseFloatOrDefault(0));

            xyzRUF = xyz.Ros2Unity();
        }

        if (rpyValues?.Length != 3)
        {
            rpy = Vector3.Zero;
            rotationRUF = Quaternion.Identity;
        }
        else
        {
            rpy = new Vector3(
                    rpyValues[0].ParseFloatOrDefault(0),
                    rpyValues[1].ParseFloatOrDefault(0),
                    rpyValues[2].ParseFloatOrDefault(0));
            
            rotationRUF = Quaternion.CreateFromYawPitchRoll(-rpy.Z, rpy.Y, -rpy.X);
        }
    }

    public readonly string Stringify(int indentation)
    {
        return $"xyz: {xyz}  rpy: {rpy}".Indent(indentation);
    }
}

}