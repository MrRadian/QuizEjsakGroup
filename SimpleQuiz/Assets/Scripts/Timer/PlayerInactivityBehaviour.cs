using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Timer
{
    public class PlayerInactivityBehaviour : MonoBehaviour
    {
        [Min(20)]
        [SerializeField] private int playerInactivityTime = 180;

        private WaitForSeconds _waitForSeconds;
        private const string _mainScene = "SplashView";

        private void Start()
        {
            _waitForSeconds = new WaitForSeconds(playerInactivityTime);
            StartCoroutine(PlayerInactivityCounter());
        }

        private void Update()
        {
            if (Input.anyKeyDown || Input.GetMouseButtonDown(0) || Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                StopAllCoroutines();
                StartCoroutine(PlayerInactivityCounter());
            }
        }

        private IEnumerator PlayerInactivityCounter()
        {
            yield return _waitForSeconds;
            SceneManager.LoadScene(_mainScene);
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}