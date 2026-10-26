using UnityEngine;

public class CartaVisual : MonoBehaviour
{
    public Sprite spriteFrente;
    public Sprite spriteDorso;

    private SpriteRenderer spriteRendererFrente;
    private SpriteRenderer spriteRendererDorso;

    void Awake()
    {
        spriteRendererFrente = transform.Find("Frente")?.GetComponent<SpriteRenderer>();
        spriteRendererDorso = transform.Find("Dorso")?.GetComponent<SpriteRenderer>();

        // Siempre mostrar dorso
        MostrarDorso();
    }

    public void SetSprites(Sprite frente, Sprite dorso)
    {
        spriteFrente = frente;
        spriteDorso = dorso;

        if (spriteRendererFrente != null)
            spriteRendererFrente.sprite = frente;

        if (spriteRendererDorso != null)
            spriteRendererDorso.sprite = dorso;
    }

    public void MostrarFrente()
    {
        if (spriteRendererFrente != null)
            spriteRendererFrente.enabled = true;
        if (spriteRendererDorso != null)
            spriteRendererDorso.enabled = false;
    }

    public void MostrarDorso()
    {
        if (spriteRendererFrente != null)
            spriteRendererFrente.enabled = false;
        if (spriteRendererDorso != null)
            spriteRendererDorso.enabled = true;
    }
}