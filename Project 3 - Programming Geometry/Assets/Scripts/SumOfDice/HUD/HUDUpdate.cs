using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDUpdate : MonoBehaviour
{
    [SerializeField] private Text txtTetrahedralDieValue;
    [SerializeField] private Text txtOctahedralDieValue;
    [SerializeField] private Text txtCubicDieValue;
    [SerializeField] private Text txtTotalValue;

    [SerializeField] private GameObject tetrahedralDie;
    [SerializeField] private GameObject octahedralDie;
    [SerializeField] private GameObject cubicDie;

    // Update is called once per frame
    void Update()
    {
        int tetrahedralDieValue = tetrahedralDie.GetComponent<Tetrahedron>().DiceValue;
        int octahedralDieValue = octahedralDie.GetComponent<Octahedron>().DiceValue;
        int cubicDieValue = cubicDie.GetComponent<Cube>().DiceValue;
        int totalValue = tetrahedralDieValue + octahedralDieValue + cubicDieValue;

        txtTetrahedralDieValue.text = "Tetrahedral Die: " + tetrahedralDieValue;
        txtOctahedralDieValue.text = "Octahedral Die: " + octahedralDieValue;
        txtCubicDieValue.text = "Cubic Die: " + cubicDieValue;
        txtTotalValue.text = "Total Value: " + totalValue;
    }
}
