
namespace MultimeterTest.MVC
{
    public class MultimeterController
    {
        private MultimeterModel _model;
        private MultimeterView _multimeterView;
        private MultimeterUIView _multimeterUIView;

        public MultimeterController(MultimeterModel model, MultimeterView multimeterView, MultimeterUIView multimeterUIView)
        {
            _model = model;
            _multimeterView = multimeterView;
            _multimeterUIView = multimeterUIView;
        }
    }
}
