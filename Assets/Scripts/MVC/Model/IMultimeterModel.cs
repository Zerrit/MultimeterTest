using MultimeterTest.Tools;

namespace MultimeterTest.MVC.Model
{
    public interface IMultimeterModel
    {
        ReactiveProperty<MultimeterMode> SelectedMode { get; }
        ReactiveProperty<float> SelectedModeValue { get; }

        void Initialize();
        void ChangeMode(MultimeterMode newMode);
    }
}