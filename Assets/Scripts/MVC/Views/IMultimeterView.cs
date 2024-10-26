using MultimeterTest.MVC.Model;

namespace MultimeterTest.MVC.Views
{
    public interface IMultimeterView
    {
        void Initialize(IMultimeterModel model);
    }
}