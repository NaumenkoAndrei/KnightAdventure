using UnityEngine;

namespace KnigthAdventure.Utils {
    public static class Utils {
        public static Vector2 GetRandomDirection() {
            return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        }
    }
}
