using System.Linq;
using UnityEngine;

public class Mazo : MonoBehaviour
{
    public GameObject cartaPrefab;
    public Transform mesa;
    public Sprite spriteDorso;

    private Sprite[] spritesCartas;

    void Start()
    {
        if (cartaPrefab == null || mesa == null || spriteDorso == null)
        {
            Debug.LogError("Asigna el prefab de la carta, la mesa y el sprite del dorso en el Inspector.");
            enabled = false;
            return;
        }

        spritesCartas = Resources.LoadAll<Sprite>("baraja_completa")
            .Where(sprite => sprite != null && sprite.name != "baraja_completa")
            .ToArray();

        if (spritesCartas.Length == 0)
        {
            Debug.LogError("No se encontraron cartas en Resources/baraja_completa.");
            enabled = false;
            return;
        }

        CrearMazo();
    }

    void CrearMazo()
    {
        const float separacionVertical = 0.02f;

        for (int i = 0; i < spritesCartas.Length; i++)
        {
            GameObject nuevaCarta = Instantiate(cartaPrefab, mesa);
            nuevaCarta.name = "Carta_" + spritesCartas[i].name;
            nuevaCarta.transform.position = mesa.position + new Vector3(0, i * separacionVertical, 0);
            nuevaCarta.transform.rotation = Quaternion.Euler(-90, 180, 0);

            CartaVisual visual = nuevaCarta.GetComponent<CartaVisual>();
            if (visual == null)
                continue;

            visual.SetSprites(spritesCartas[i], spriteDorso);
            visual.MostrarDorso();
        }
    }
}
