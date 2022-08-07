using UnityEngine;

public class BallMultiplierPickUp : PickUpBase
{
    #region Variables

    [SerializeField] private int _multiplier;
    [SerializeField] private int _score;

    #endregion


    #region Protected Methods
    protected override void ApplyEffect(Collision2D col)
    {
        foreach (Ball ball in BallsHandler.Instance.AllBalls)
        {
            for (int i = 0; i < _multiplier; i++)
            {
                Ball newBall = Instantiate(ball, ball.transform.position, Quaternion.identity);
                newBall.Copy(ball);
            }
        }
        AudioPlayer.Instance.AddPositivePickUpAudioClip();
        Statistics.Instance.ChangeScore(_score);
    }

    

    #endregion
   
}