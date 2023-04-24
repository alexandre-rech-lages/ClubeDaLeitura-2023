﻿using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo
{
    public class RepositorioAmigo : RepositorioBase
    {       
        public RepositorioAmigo(ArrayList lista)
        {
            listaRegistros = lista;
        }     

        public override Amigo SelecionarPorId(int id)
        {
            return (Amigo)base.SelecionarPorId(id);
        }
    }
}
