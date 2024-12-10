using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;

    private BoxCollider2D _collider;

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>(); // Ensure the tile has a 2D collider
        if (gameObject.tag == "startingTile"){
            ClearTile();
        }
        
        
    }

    public void Init(bool isOffset) {
        _renderer.color = isOffset ? _offsetColor : _baseColor;
    }

    void OnMouseEnter() {
        _highlight.SetActive(true);  // Show highlight when mouse enters tile
    }

    void OnMouseExit() {
        _highlight.SetActive(false);  // Hide highlight when mouse exits tile
    }

    void OnMouseDown() {
        // When the tile is clicked, clear it by disabling the collider
        ClearTile();
    }

  public void ClearTile() {
    if (_collider != null)
    {
        _collider.enabled = false; // Disable collider to allow player to pass
    }
     _renderer.color = new Color(0.25f, 0.25f, 0.25f); // Example: Change color to gray when cleared

    // Optionally, you can remove the tag or change the tag to "ClearedTile" if needed
    gameObject.tag = "ClearedTile"; // Or remove the tag entirely if you prefer
}

public void ResetTile() {
    if (_collider != null)
    {
        _collider.enabled = true; // Re-enable collider when tile is reset
    }
    _renderer.color = _baseColor; // Reset color
    gameObject.tag = "UnclearedTile"; // Reset tag to "UnclearedTile"
}

    public bool IsCleared() {
        return _collider == null || !_collider.enabled;
    }
}