using Projeto_Orientado_a_Objeto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoOrientadoObjeto
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            DateBase dateBase = new DateBase("SerializedDateBase.xml");
            GraphicInterface begin = new GraphicInterface(dateBase);
            begin.initialization();
        }
    }
}