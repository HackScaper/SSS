using System;

static class Ohjelma
{
#if WINDOWS || XBOX
    static void Main(string[] args)
    {
        using (SSS game = new SSS())
        {
#if !DEBUG
            game.IsFullScreen = true;
#endif
            game.Run();
        }
    }
#endif
}
