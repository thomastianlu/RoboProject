using UnityEngine;
using System.Collections;

public class TileGeneratorDetector : MonoBehaviour {

    public bool shouldCreateTile;

	void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Tiles") && !shouldCreateTile)
        {
            shouldCreateTile = true;
        }
    }
}
