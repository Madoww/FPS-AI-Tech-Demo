using System;

public interface IDeinitializable
{
    event Action OnDeinitialized;

    void Deinitialize();
}
