using MultimeterTest.MVC.Model;
using MultimeterTest.MVC.Views;

namespace MultimeterTest.MVC
{
    public class MultimeterController
    {
        private readonly IMultimeterModel _model;
        private readonly MultimeterView _multimeterView;
        private readonly MultimeterUIView _multimeterUIView;

        public MultimeterController(IMultimeterModel model, MultimeterView multimeterView, MultimeterUIView multimeterUIView)
        {
            _model = model;
            _multimeterView = multimeterView;
            _multimeterUIView = multimeterUIView;
        }

        public void Initialize()
        {
            _model.Initialize();

            _multimeterView.Initialize(_model);
            _multimeterUIView.Initialize(_model);
        }
    }
}
