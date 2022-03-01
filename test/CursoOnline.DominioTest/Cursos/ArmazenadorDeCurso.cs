using CursoOnline.Dominio.Cursos;
using System;

namespace CursoOnline.DominioTest.Cursos
{

    // Essa é aclasse de serviço apresentação
    internal class ArmazenadorDeCurso
    {
        private ICursoRepository _cursoRepository;

        public ArmazenadorDeCurso(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        internal void Armazenar(CursoDto cursoDto)
        {
            Enum.TryParse(typeof(PublicoAlvo), cursoDto.PublicoAlvo, out var publicoAlvo);

            if (publicoAlvo == null)
            {
                throw new ArgumentException("Publico Alvo inválido");
            }

            var curso = new Curso(cursoDto.Nome, cursoDto.Descricao, cursoDto.CargaHoraria, (PublicoAlvo)publicoAlvo, cursoDto.Valor);

            _cursoRepository.Adicionar(curso);

        }
    }
}