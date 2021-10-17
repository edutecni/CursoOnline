using CursoOnline.Dominio.Cursos;
using Moq;
using Xunit;

namespace CursoOnline.DominioTest.Cursos
{
    public class ArmazenadorDeCursoTeste
    {
        [Fact]
        public void DeveAdicionarCurso()
        {
            var cursoDto = new CursoDto
            {
                Nome = "Curso A",
                Descricao = "Descricao",
                CargaHoraria = 80,
                PublicoAlvoId = 1,
                Valor = 850.00
            };

            var cursoRepositoryMock = new Mock<ICursoRepository>();

            var armazenadorDeCurso = new ArmazenadorDeCurso(cursoRepositoryMock.Object);

            armazenadorDeCurso.Armazenar(cursoDto);

            cursoRepositoryMock.Verify(r => r.Adicionar(It.IsAny<Curso>()));

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
        public int PublicoAlvoId { get; set; }
        public double Valor { get; set; }
    }
}
