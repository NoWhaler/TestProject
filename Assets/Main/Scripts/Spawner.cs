using Main.Scripts.Movement;
using UnityEngine;

namespace Main.Scripts
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject _environment;

        [SerializeField] private PlayerController _playerController;

        private void Awake()
        {
            Instantiate(_environment, Vector3.zero, Quaternion.identity);
            Instantiate(_playerController, new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
}