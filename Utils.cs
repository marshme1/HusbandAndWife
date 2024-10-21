using UnityEngine;

namespace KnightAdventure.Util {
    public static class Util{
        public static Vector3 GetRandomDir(){
            return new Vector3(Random.Range(-1f,1f), Random.Range(-1f, 1f)).normalized;
        }
    }
}

