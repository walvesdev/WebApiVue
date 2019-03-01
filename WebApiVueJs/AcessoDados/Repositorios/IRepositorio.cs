﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjetoBase.AcessoDados.Repositorios
{
    public interface IRepositorio<T, TId> where T : class
    {
        List<T> SelecionarTodos();
        Task<List<T>> SelecionarTodosAsync();
        T SelecionarPorId(TId id);
        void Inserir(T etidade);
        void Atualizar(T entidade);
        void Excluir(T entidade);
        

    }
}
