using Microsoft.Xna.Framework.Audio;
using System;

public abstract class Trigger<T>
{
	/* A trigger keeps track of a previous state and a current state, whose TriggerCondition can be customized as a boolean function of the previous state and the current state.
	 * Useful for detecting things like (previous frame doesn't have a debuff, current frame has a debuff).
	 */

	protected T current;
    protected T previous;

	public void Update(T value)
	{
		previous = current;
		current = value;
	}

	public abstract Boolean TriggerCondition();

}
