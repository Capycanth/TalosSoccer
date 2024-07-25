using TalosSoccer.Core.Containers;

namespace TalosSoccer.Core.TalosRL
{
    public abstract class StateKey
    {
        public string Key { get; private set; }

        public abstract void UpdateStateKey(Match match);
    }
}
