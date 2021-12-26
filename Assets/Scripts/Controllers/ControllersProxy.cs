using System.Collections.Generic;

namespace Birds
{
    public class ControllersProxy : IConfigure, IInitialize, IExecute, IFixedExecute, ILateExecute, ICleanup
    {
        private readonly List<IConfigure> _configureController;
        private readonly List<IInitialize> _initializationControllers;
        private readonly List<IExecute> _executeControllers;
        private readonly List<IFixedExecute> _fixedExecuteControllers;
        private readonly List<ILateExecute> _lateExecuteControllers;
        private readonly List<ICleanup> _cleanupControllers;

        public ControllersProxy()
        {
            _configureController = new List<IConfigure>();
            _initializationControllers = new List<IInitialize>();
            _executeControllers = new List<IExecute>();
            _fixedExecuteControllers = new List<IFixedExecute>();
            _lateExecuteControllers = new List<ILateExecute>();
            _cleanupControllers = new List<ICleanup>();
        }

        public void Add(IController controller)
        {
            if (controller is IConfigure configController)
            {
                _configureController.Add(configController);
            }

            if (controller is IInitialize initController)
            {
                _initializationControllers.Add(initController);
            }

            if (controller is IExecute executeController)
            {
                _executeControllers.Add(executeController);
            }

            if (controller is IFixedExecute fixedExecuteController)
            {
                _fixedExecuteControllers.Add(fixedExecuteController);
            }

            if (controller is ILateExecute lateExecuteController)
            {
                _lateExecuteControllers.Add(lateExecuteController);
            }

            if (controller is ICleanup cleanupController)
            {
                _cleanupControllers.Add(cleanupController);
            }
        }

        public void Configure()
        {
            foreach (IConfigure controller in _configureController)
                controller.Configure();
        }

        public void Initialize()
        {
            foreach (IInitialize controller in _initializationControllers)
                controller.Initialize();
        }

        public void Execute(float deltaTime)
        {
            foreach (IExecute controller in _executeControllers)
                controller.Execute(deltaTime);
        }

        public void FixedExecute()
        {
            foreach (IFixedExecute controller in _fixedExecuteControllers)
                controller.FixedExecute();
        }

        public void LateExecute()
        {
            foreach (ILateExecute controller in _lateExecuteControllers)
                controller.LateExecute();
        }

        public void Cleanup()
        {
            foreach (ICleanup controller in _cleanupControllers)
                controller.Cleanup();
        }


    }
}
