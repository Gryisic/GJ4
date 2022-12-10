using UnityEngine;

namespace GJ4.Utils
{
    public static class VectorExtension 
    {
        public static Vector3Int RoundToInt(this Vector3 vector) 
        {
            var x = vector.x.RoundOrFloor();
            var y = vector.y.RoundOrFloor();
            var z = vector.z.RoundOrFloor();

            return new Vector3Int(x, y, z);
        }
    }
}
