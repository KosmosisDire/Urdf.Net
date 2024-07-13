using System.Numerics;

namespace UrdfToolkit.Extensions
{
    public static class RosExtensions
    {
        public static Vector3 Ros2Unity(this Vector3 vector3)
        {
            return new Vector3(-vector3.Y, vector3.Z, vector3.X);
        }

        public static Vector3 Unity2Ros(this Vector3 vector3)
        {
            return new Vector3(vector3.Z, -vector3.X, vector3.Y);
        }

        public static Quaternion Ros2Unity(this Quaternion quaternion)
        {
            return new Quaternion(quaternion.Y, -quaternion.Z, -quaternion.X, quaternion.X);
        }

        public static Quaternion Unity2Ros(this Quaternion quaternion)
        {
            return new Quaternion(-quaternion.Z, quaternion.X, -quaternion.Y, quaternion.W);
        }

        public static Vector3 Ros2UnityScale(this Vector3 vector3)
        {
            return new Vector3(vector3.Y, vector3.Z, vector3.X);
        }

        public static Vector3 Unity2RosScale(this Vector3 vector3)
        {
            return new Vector3(vector3.Z, vector3.X, vector3.Y);
        }
    }
}