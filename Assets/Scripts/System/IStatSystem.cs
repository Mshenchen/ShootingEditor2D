using FrameworkDesign;
namespace ShootingEditor2D
{

    public interface IStatSystem : ISystem
    {
        BindableProperty<int> killCount { get; }
    }
    public class StatSystem : AbstractSystem, IStatSystem
    {
        public BindableProperty<int> killCount { get; } = new BindableProperty<int>()
        {
            Value = 0
        };

        protected override void OnInit()
        {

        }
    }
}
