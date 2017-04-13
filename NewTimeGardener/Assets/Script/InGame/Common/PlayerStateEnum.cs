namespace PlayerStateEnum
{
    public enum PlayerState
    {
        Idle    = (1 << 0),
        Walk    = (1 << 1),
        Jump    = (1 << 2),
        Act     = (1 << 3),
        Event   = (1 << 4),
        Die     = (1 << 5)

    }
}