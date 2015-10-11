using Ninject;

namespace EasyBooks.Domain
{
    public static class IoC
    {
        private static IKernel _kernel;

        public static IKernel Container
        {
            get
            {
                if (_kernel == null)
                    _kernel = new StandardKernel();

                return _kernel;
            }
        }

        public static void Bind<TSource, TDest>()
        {
            Container.Bind<TSource>().To(typeof(TDest));
        }

        public static T Resolve<T>()
        {
            return Container.Get<T>();
        }
    }
}
