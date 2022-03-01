using Bogus;
using CursoOnline.Dominio.Cursos;
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

            _cursoRepositoryMock.Verify(r => r.Adicionar(
                It.Is<Curso>(
                    c => c.Nome == _cursoDto.Nome &&
                    c.Descricao == _cursoDto.Descricao
                    )));

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
