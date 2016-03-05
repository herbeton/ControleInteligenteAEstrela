using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleInteligenteAEstrela.Model.Dominio
{
    class ParametrosFormConfig
    {
        int numeroLinhas{get; set;}
        int numeroColunas { get; set; }
        float custoVertical { get; set; }
        float custoHorizonta { get; set; }
        float custoDiagonal { get; set; }
        int posicaoSaida { get; set; }
        int posicaoEntrada { get; set; }
    }
}
