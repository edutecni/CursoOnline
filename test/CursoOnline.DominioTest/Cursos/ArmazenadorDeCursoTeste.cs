using Bogus;
using CursoOnline.Dominio.Cursos;
using CursoOnline.DominioTest._Builders;
using CursoOnline.DominioTest._Util;
using Moq;
using System;
using Xunit;

namespace CursoOnline.DominioTest.Cursos
{
    public class ArmazenadorDeCursoTeste
    {
        private readonly CursoDto _cursoDto;        
        private readonly ArmazenadorDeCurso _armazenadorDeCurso;
        private readonly Mock<ICursoRepository> _cursoRepositoryMock;

        public ArmazenadorDeCursoTeste()
        {
            var fake = new Faker();

            _cursoDto = new CursoDto
            {
                Nome = fake.Random.Words(),
                Descricao = fake.Lorem.Paragraph(),
                CargaHoraria = fake.Random.Double(50, 10000),
                PublicoAlvo = "Estudante",
                Valor = fake.Random.Double(1000, 2000)
            };

            _cursoRepositoryMock = new Mock<ICursoRepository>();
            _armazenadorDeCurso = new ArmazenadorDeCurso(_cursoRepositoryMock.Object);
        }

        [Fact]
        public void DeveAdicionarCurso()
        {

            _armazenadorDeCurso.Armazenar(_cursoDto);

            // Mock é o objet que serve para verificar propriedades, estado e comportamentos
            // Verifica algo dele mesmo
            _cursoRepositoryMock.Verify(r => r.Adicionar(
                It.Is<Curso>(
                    c => c.Nome == _cursoDto.Nome &&
                    c.Descricao == _cursoDto.Descricao
                    )));

        }

        [Fact]
        public void NaoDeveAdicionarCursoComMesmoNomeDeoutroJaSalvo()
        {
            // Stub => é quando ele é setupeado  para simular algo externo a ele
            // é utilizado para verificar algo externo ao objeto, por exemplo como se ele estivesse sido retornado de um banco de dados
            // Nesse caso o objeto foi criado somente para simular um retorno de banco de dados
            var cursoJaSalvo = CursoBuilder.Novo().ComNome(_cursoDto.Nome).Build();
            _cursoRepositoryMock.Setup(r => r.ObterPeloNome(_cursoDto.Nome)).Returns(cursoJaSalvo);

            Assert.Throws<ArgumentException>(() => _armazenadorDeCurso.Armazenar(_cursoDto)).ComMensagem("Nome do curso já consta no baanco de dados");
        }

        [Fact]
        public void NaoDeveAdicionarComPublicoAlvoInvalido()
        {
            _cursoDto.PublicoAlvo = "Médico";

            Assert.Throws<ArgumentException>(() => _armazenadorDeCurso.Armazenar(_cursoDto)).ComMensagem("Publico Alvo inválido");
        }        
    }    

    public interface ICursoRepository
    {
        void Adicionar(Curso curso);
        void Atualizar(Curso curso);
        Curso ObterPeloNome(string nome);
    }

    public class CursoDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double CargaHoraria { get; set; }
        public string PublicoAlvo { get; set; }
        public double Valor { get; set; }
    }
}
