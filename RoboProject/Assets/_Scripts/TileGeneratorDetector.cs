using UnityEngine;
using System.Collections;

// Tile Generator Detector
// This script detects that once a tile leaves the collider
// to tell the Tile Generator script to make a new tile in its place

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
