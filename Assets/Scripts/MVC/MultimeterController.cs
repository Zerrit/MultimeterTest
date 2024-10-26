using MultimeterTest.MVC.Model;
using MultimeterTest.MVC.Views;

namespace MultimeterTest.MVC
{
    public class MultimeterController
    {
        private readonly IMultimeterModel _model;
        private readonly IMultimeterView _multimeterView;
        private readonly IMultimeterUIView _multimeterUIView;

        public MultimeterController(IMultimeterModel model, IMultimeterView multimeterView, IMultimeterUIView multimeterUIView)
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
