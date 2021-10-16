using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CursoOnline.DominioTest._Util
{
    public static class AssertExtension
    {
        // O operador this significa que está criando um método de extensão.
        public static void ComMensagem(this ArgumentException exception, string mensagem)
        {
            if (exception.Message == mensagem)
            {
                Assert.True(true);
            }
            else
            {
                Assert.False(true);
            }
        }
    }
}
