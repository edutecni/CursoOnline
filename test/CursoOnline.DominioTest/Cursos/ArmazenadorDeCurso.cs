using CursoOnline.Dominio.Cursos;
using System;

namespace CursoOnline.DominioTest.Cursos
{
    internal class ArmazenadorDeCurso
    {
        private ICursoRepository _cursoRepository;

        public ArmazenadorDeCurso(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        internal void Armazenar(CursoDto cursoDto)
        {
            var curso = new Curso(cursoDto.Nome, cursoDto.Descricao, cursoDto.CargaHoraria, PublicoAlvo.Estudante, cursoDto.Valor);

            _cursoRepository.Adicionar(curso);

        }
    }
}