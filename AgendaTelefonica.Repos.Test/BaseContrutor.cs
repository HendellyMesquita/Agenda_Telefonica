using AutoFixture;
using Moq;

namespace AgendaTelefonica.Repos.Test
{
    public class BaseContrutor<T> where T : class
    {
        protected readonly Fixture _fixture;
        protected readonly Mock<T> _mock;

        protected BaseContrutor()
        {
            _fixture = new Fixture();
            _mock = new Mock<T>();
        }

        public T ConverterEmObjeto()
        {
            return _mock.Object;
        }

        public Mock<T> Obter()
        {
            return _mock;
        }
    }
}
