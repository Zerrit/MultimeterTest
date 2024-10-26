using MultimeterTest.MVC.Model;

namespace MultimeterTest.MVC.Views
{
    public interface IMultimeterUIView
    {
        void Initialize(IMultimeterModel model);
    }
}