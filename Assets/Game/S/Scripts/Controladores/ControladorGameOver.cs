namespace Game.S.Scripts.Controladores
{
    using System;
    using System.Collections;
    using UnityEngine;
    using UnityEngine.UI;

    public class ControladorGameOver : MonoBehaviour
    {
        [SerializeField] private Text txtPontos;
        [SerializeField] private Text txtHighscore;
        [SerializeField] private Image imgNew;
        [SerializeField] private ControladorIngredientes controladorIngredientes;

        private Animator _animator;
        private bool _encontrouTxtPontos, _encontrouTxtHighscore, _encontrouImgNew, _encontrouControladorIngredientes, _encontrouAnimator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            _encontrouTxtPontos = txtPontos != null;
            _encontrouTxtHighscore = txtHighscore != null;
            _encontrouImgNew = imgNew != null;
            _encontrouControladorIngredientes = controladorIngredientes != null;
            _encontrouAnimator = _animator != null;
            
            StartCoroutine(AtualizarPontos());
        }
        private void OnEnable()
        {

        }

        private IEnumerator AtualizarPontos()
        {
            var pontos = 0;

            if (_encontrouAnimator)
                yield return new WaitForSeconds(_animator.speed);
            
            if (_encontrouControladorIngredientes)
            {
                pontos = controladorIngredientes.Pontos;

                if (controladorIngredientes.Pontos > PlayerPrefs.GetInt("Highscore"))
                {
                    PlayerPrefs.SetInt("Highscore", controladorIngredientes.Pontos);

                    if (_encontrouImgNew)
                        imgNew.gameObject.SetActive(true);
                }
            }
            
            for (var i = 0; i < pontos; i++)
            {
                if (_encontrouTxtPontos)
                    txtPontos.text = (Convert.ToInt32(txtPontos.text) + 1).ToString();
                yield return new WaitForSeconds(0.15f);
            }

            for (var i = 0; i < PlayerPrefs.GetInt("Highscore"); i++)
            {
                if (_encontrouTxtHighscore)
                    txtHighscore.text = (Convert.ToInt32(txtHighscore.text) + 1).ToString();
                
                yield return new WaitForSeconds(0.15f);
            }
        }
    }
}