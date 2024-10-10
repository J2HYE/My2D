using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My2D
{
    //�÷��̾� �̵� ���� ����ȿ�� �Ÿ� ���ϱ�
    public class ParallaxEffect : MonoBehaviour
    {
        #region Variables
        public Camera camera;           //ī�޶�
        public Transform followTarget;  //�÷��̾�

        //���� ��ġ
        private Vector2 startingPosition;   //���� ��ġ(���, ī�޶�)
        private float startingZ;            //������ �� ����� z�� ��ġ��

        //�����������κ��� ī�޶� ��ġ������ �Ÿ�
        private Vector2 CamMoveSinceStart => startingPosition - (Vector2)camera.transform.position;

        //
        private float zDistanceFromTarget => transform.position.z - followTarget.position.z;
        //
        private float CllipingPlane => camera.transform.position.z + (zDistanceFromTarget > 0 ? camera.farClipPlane : camera.nearClipPlane);

        private float ParallaxFactor => Mathf.Abs(zDistanceFromTarget) / CllipingPlane;
        #endregion

        private void Start()
        {
            //�ʱ�ȭ
            startingPosition = transform.position;
            startingZ = transform.localPosition.z;
        }

        private void Update()
        {
            Vector2 newPosition = startingPosition + CamMoveSinceStart * ParallaxFactor; //+ B;
            transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);
        }
    }
}
